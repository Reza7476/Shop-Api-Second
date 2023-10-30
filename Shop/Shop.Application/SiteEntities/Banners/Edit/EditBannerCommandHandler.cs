using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {

        IBannerRepository _repository;
        IFileService _localFileService;
        public EditBannerCommandHandler(IBannerRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {

            var banner = await _repository.GetTracking(request.Id);
            if (banner == null)
                return OperationResult.NotFound();

            var imageName = banner.ImageName;

            var oldImage = banner.ImageName;
            if (request.ImageFile != null)
                imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);


            banner.Edit(request.Link, imageName, request.Position);

            await _repository.Save();
            deletOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();

        }


        private void deletOldImage(IFormFile? imageFile,string OldImage)
        {
            if (imageFile != null)

                _localFileService.DeleteFile(Directories.BannerImages, OldImage);
        }
    }


}
