using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
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

namespace Shop.Application.Product.Create
{
    public class CreateProductCommand:IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageFile,
            string description, long categoryId, long subCategoryId, long secondrySubCategoryId, string slug, SeoData seoData,
            Dictionary<string, string> specifications)
        {
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

        public string Title { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondrySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        //public List<ProductImages> Images { get; private set; }
        public Dictionary<string,string> Specifications { get; private set; }
    }

    public class CreateProductCommandHandler:IBaseCommandHandler<CreateProductCommand>  
    {
        IProductDomainService _domainService;
        IProductRepository _repository;
        IFileService _localFileService;

        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService localFileService)
        {
            _domainService = domainService;
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName =  await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product=new ProductAgg(request.Title,imageName,request.Description,
                request.CategoryId,  request.SubCategoryId,
                request.SecondrySubCategoryId,request.Slug,_domainService,request.SeoData);

            var specifications = new List<ProductSpecification>();

            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key,specification.Value));
            });
            product.SetSpecification(specifications);
            _repository.Save();
            return OperationResult.Success();
        }
    }

    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand> 
    {
        public CreateProductCommandValidator()
        {
            RuleFor(f => f.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(f => f.Description)
               .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));



            RuleFor(f => f.Slug)
               .NotEmpty().WithMessage(ValidationMessages.required("slug"));


            RuleFor(f => f.ImageFile)
            .JustImageFile();


           
        }
    }
}
