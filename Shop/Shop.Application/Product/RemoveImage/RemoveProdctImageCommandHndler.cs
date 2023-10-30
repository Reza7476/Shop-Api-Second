using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAggregate.Repository;

namespace Shop.Application.Product.RemoveImage
{
    public class RemoveProdctImageCommandHndler : IBaseCommandHandler<RemoveProdctImageCommand>
    {


        IProductRepository _repository;
        IFileService _localFileService;

        public RemoveProdctImageCommandHndler(IProductRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(RemoveProdctImageCommand request, CancellationToken cancellationToken)
        {


            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            await _repository.Save();
            _localFileService.DeleteFile(Directories.ProductGalleryImage, imageName);
            return OperationResult.Success();
        }
    }

}
