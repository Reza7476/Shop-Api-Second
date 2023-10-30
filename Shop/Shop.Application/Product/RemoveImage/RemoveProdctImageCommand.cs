using Common.Application;

namespace Shop.Application.Product.RemoveImage
{
    public record RemoveProdctImageCommand(long ProductId, long ImageId) : IBaseCommand;

}
