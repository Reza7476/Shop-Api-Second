using Common.Application;
using Shop.Domaion.CategoryAggreagate;
using Shop.Domaion.CategoryAggreagate.Sevices;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {

        ICategoryRepository _repository;
        ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();
            category.Edit(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.Save();
            return OperationResult.Success();


        }
    }
}
