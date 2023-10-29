using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domaion.ProductAggregate
{
    public class ProductImages : BaseEntity
    {
        public ProductImages(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
            Sequence = sequence;
        }

        public long  ProductId { get; internal set; }

        public string  ImageName { get; private set; }
        public int Sequence { get; private set; }




    }
}
