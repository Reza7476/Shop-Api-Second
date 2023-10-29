using Common.Application;
using Shop.Domaion.CategoryAggreagate;
using Shop.Domaion.CategoryAggreagate.Sevices;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {

       private readonly ICategoryRepository _repository;
       private readonly ICategoryDomainService _domainService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public  async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryAgg(request.Title, request.Slug, request.SeoData, _domainService);

             _repository.Add(category);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
