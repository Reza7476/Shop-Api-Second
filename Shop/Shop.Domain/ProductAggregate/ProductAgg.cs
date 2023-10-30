using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAggregate
{
    public class ProductAgg : AggregateRoot
    {



        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondrySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImages> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        private ProductAgg() { }


        public ProductAgg(string title, string imageName, string description,
            long categoryId, long subCategoryId, long secondrySubCategoryId, string slug,
            IProductDomainService domainService, SeoData seoData)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondrySubCategoryId = secondrySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }


        public void Edit(string title,  string description,
            long categoryId, long subCategoryId, 
            long secondrySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {

            Guard(title,  description, slug, domainService);
            Title = title;
           
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondrySubCategoryId = secondrySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;

        }




        public void AddImage(ProductImages image)
        {

            image.ProductId = Id;
            Images.Add(image);
        }


        public void RemoveImage(long Id)
        {
            var image = Images.FirstOrDefault(f => f.Id == Id);
            if (image == null)
                return;
            Images.Remove(image);
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);

            Specifications = specifications;
        }


        public void Guard(string title,  string description, string slug,
            IProductDomainService productDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
          
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));

            if (slug != Slug)
                if (productDomainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDublicatedException("");






        }
    }
}
