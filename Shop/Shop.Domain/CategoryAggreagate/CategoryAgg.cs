using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAggreagate.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAggreagate
{
    public class CategoryAgg : AggregateRoot
    {
        public CategoryAgg(string title, string slug, SeoData seoData,
           ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);

            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; set; }// it is main category if has null value

        public List<CategoryAgg> Childs { get; private set; }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Guard(title, slug, domainService);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Guard(string title, string slug, ICategoryDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));



            if (slug != Slug)
                if (domainService.SlugIsExist(slug))
                    throw new SlugIsDublicatedException();

        }


        public void AddChaild(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
        {
            Childs.Add(new CategoryAgg(title, slug, seoData, domainService)
            {
                ParentId = Id
            });
        }
    }
}
