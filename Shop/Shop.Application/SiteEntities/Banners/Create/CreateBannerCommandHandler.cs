using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {

        private readonly IBannerRepository _repository;
        private readonly IFileService _localFileService;
        public CreateBannerCommandHandler(IBannerRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {

            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

            var banner = new Banner(request.Link, imageName, request.Position);
            _repository.Add(banner);
            await _repository.Save();
            return OperationResult.Success();
        }
    }


}
