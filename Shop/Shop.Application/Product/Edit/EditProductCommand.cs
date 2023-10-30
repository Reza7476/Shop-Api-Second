using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.Validation;
using Common.Domain.Repository;
using Common.Domain.ValueObjects;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAggregate;
using Shop.Domain.ProductAggregate.Repository;
using Shop.Domain.ProductAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Product.Edit
{
    public class EditProductCommand : IBaseCommand
    {
        public EditProductCommand(long productId, string title, IFormFile? imageFile, string description, long categoryId, long subCategoryId, long secondrySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            ProductId = productId;
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondrySubCategoryId = secondrySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }

        public long ProductId { get; set; }
        public string Title { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondrySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        //public List<ProductImages> Images { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }
    }
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IProductDomainService _domainService;
        private readonly IFileService _locaFileService;
        public EditProductCommandHandler(IProductRepository repository, IProductDomainService domainService, IFileService locaFileService)
        {
            _repository = repository;
            _domainService = domainService;
            _locaFileService = locaFileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _repository.GetTracking(request.ProductId);

            if (oldProduct == null)
                return OperationResult.NotFound();
            oldProduct.Edit(request.Title, request.Description,
                request.CategoryId,
                request.SubCategoryId, request.SecondrySubCategoryId,
                request.Slug, request.SeoData, _domainService);


            //const string oldImage = oldProduct.ImageName;
           var  oldImage = oldProduct.ImageName; 
            if (request.ImageFile != null)
            {
                var imageName = await _locaFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                oldProduct.SetProductImage(imageName);
            }
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            oldProduct.SetSpecification(specifications);
            await _repository.Save();
            RemoveOldImage(request.ImageFile,oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageName,string oldImageName)
        {
            if (imageName != null)
            {
                _locaFileService.DeleteFile(Directories.ProductImages, oldImageName);
            }
        }
    }
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(f => f.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));


            RuleFor(f => f.Slug)
              .NotEmpty().WithMessage(ValidationMessages.required("slug"));

            RuleFor(f => f.Description)
              .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));
        }
    }
}
