using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Product.AddImage
{
    public class AddProductImageCommand : IBaseCommand
    {
        public AddProductImageCommand(long productId, string imageName, int sequence, IFormFile imageFile)
        {
            ProductId = productId;

            Sequence = sequence;
            ImageFile = imageFile;
        }

        public long ProductId { get; internal set; }
       
        public int Sequence { get; private set; }

        public IFormFile   ImageFile{ get; private set; }
    }

}
