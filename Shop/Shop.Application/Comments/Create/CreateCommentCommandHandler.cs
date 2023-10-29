using Common.Application;
using Shop.Domaion.CommentAggregate;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {

       private readonly ICommentRepositoey _repository;

        public CreateCommentCommandHandler(ICommentRepositoey repository)
        {
            _repository = repository;
        }

        public async  Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment=new CommentAgg(request.userId,request.productId,request.text);
             await _repository.AddAsync(comment);
            await _repository.Save();
            return OperationResult.Success();

        }
    }
}
