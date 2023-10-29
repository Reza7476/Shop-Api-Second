using Common.Application;
using Shop.Domaion.CategoryAggreagate;
using Shop.Domaion.CategoryAggreagate.Sevices;

namespace Shop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {

        ICategoryRepository _repository;
        ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async  Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult.NotFound();
            category.AddChaild(request.Title, request.Slug, request.SeoData, _domainService);

            await _repository.Save();
            return OperationResult.Success();
        }
    }
    
}
