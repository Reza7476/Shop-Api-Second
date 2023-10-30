using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repositories;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {

        private readonly ISliderRepository _repository;
        private readonly IFileService _localFileService;
        public CreateSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {

            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Title, request.Link, imageName);
            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
