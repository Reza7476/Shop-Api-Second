using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAggregate.Repository;
using Shop.Domain.UserAggregate.Services;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {

        IUserRepository _repository;
        IDomainUserService _domainService;
        IFileService _localFileService;
        public EditUserCommandHandler(IUserRepository repository, IDomainUserService domainService, IFileService localFileService = null)
        {
            _repository = repository;
            _domainService = domainService;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainService);
            var oldAvatar = user.AvatarName;
            if (request.Avatar != null)
            {
                var imageName = await _localFileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatarImages);
                user.SetAvatar(imageName);
            }
            DeleteOldAvatar(request.Avatar, oldAvatar);
            await _repository.Save();
            return OperationResult.Success();
        }

        private void DeleteOldAvatar(IFormFile? avatarFile, string oldImage)
        {
            if(avatarFile == null|| oldImage== "Avatar.png") return;

            _localFileService.DeleteFile(Directories.UserAvatarImages, oldImage);
        }
    }
}
