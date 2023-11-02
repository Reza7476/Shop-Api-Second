using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAggregate;
using Shop.Domain.ProductAggregate.Repository;
using Shop.Domain.ProductAggregate.Services;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly IFileService _localFileService;

        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService localFileService)
        {
            _domainService = domainService;
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new ProductAgg(request.Title, imageName, request.Description,
                request.CategoryId, request.SubCategoryId,
                request.SecondrySubCategoryId, request.Slug, _domainService, request.SeoData);

            var specifications = new List<ProductSpecification>();
            await _repository.AddAsync(product);
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            product.SetSpecification(specifications);

            _repository.Save();
            return OperationResult.Success();
        }
    }
}
