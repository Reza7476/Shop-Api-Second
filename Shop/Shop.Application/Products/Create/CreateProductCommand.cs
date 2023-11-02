using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommand : IBaseCommand
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
        public Dictionary<string, string> Specifications { get; private set; }
    }
}
