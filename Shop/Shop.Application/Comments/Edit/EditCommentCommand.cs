using Common.Application;
using Shop.Application.Comments.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long CommentId,string Text,long UserId,long ProductId):IBaseCommand;
}
