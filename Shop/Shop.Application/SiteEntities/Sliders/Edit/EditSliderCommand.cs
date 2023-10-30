using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand:IBaseCommand
    {
        public EditSliderCommand(long id, string title, string link, IFormFile? imageFile)
        {
            Id = id;
            Title = title;
            Link = link;
            ImageFile = imageFile;
        }

        public long  Id { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
    }

    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
      private readonly  ISliderRepository _repository;
      private readonly  IFileService _localFileService;

        public EditSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.Id);
            if (slider == null)
                return OperationResult.NotFound();
            var imageName = slider.ImageName;

            var oldImage = slider.ImageName;
            if (request.ImageFile != null)
                imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            slider.Edit(request.Title,request.Link, imageName);

            await _repository.Save();
            DeletOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();   
        }

        private void DeletOldImage(IFormFile? imageFile,string OldImage)
        {
            if (imageFile != null)
            {
                _localFileService.DeleteFile(Directories.SliderImages, OldImage);
            }
        }

    }

    public class EditSliderCommandValidato:AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidato()
        {
            RuleFor(r => r.Title)
                .NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(r => r.Link)
                .NotNull().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(f => f.ImageFile)
                .JustImageFile();
        }
    }
}
