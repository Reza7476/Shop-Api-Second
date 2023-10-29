using Common.Application;
using Shop.Domaion.CommentAggregate;

namespace Shop.Application.Comments.ChangeStatus
{
    public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
    {

        ICommentRepositoey _repository;
        public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
        {


            var comment=  await _repository.GetTracking(request.Id);
            if (comment == null)
                return OperationResult.NotFound();
            comment.ChangeStatus(request.status);
            await _repository.Save();

            return OperationResult.Success();


        }
    }
}
