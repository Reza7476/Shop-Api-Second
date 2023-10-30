using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAggregate;
using Shop.Domain.ProductAggregate.Repository;
using Shop.Domain.ProductAggregate.Services;

namespace Shop.Application.Product.AddImage
{
    public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {

        private readonly IProductRepository _repository;
        private readonly IProductDomainService _domainService;
        private readonly IFileService _localFileService;

        public AddProductImageCommandHandler(IProductRepository repository, IProductDomainService domainService, IFileService localFileService)
        {
            _repository = repository;
            _domainService = domainService;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {

            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

            var productImage = new ProductImages(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();
            return OperationResult.Success();

        }
    }

}
