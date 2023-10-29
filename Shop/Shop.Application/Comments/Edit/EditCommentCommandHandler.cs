using Common.Application;
using Shop.Domaion.CommentAggregate;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandHandler:IBaseCommandHandler<EditCommentCommand>
    {

        ICommentRepositoey _repository;

        public EditCommentCommandHandler(ICommentRepositoey repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null||comment.UserId!=request.UserId)
                return OperationResult.NotFound();
            comment.Edit(request.Text);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
