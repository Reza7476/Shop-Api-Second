using Common.Application;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveProdctImageCommand(long ProductId, long ImageId) : IBaseCommand;

}
