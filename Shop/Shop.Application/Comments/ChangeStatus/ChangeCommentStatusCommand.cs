using Common.Application;
using Shop.Domaion.CommentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(long Id,CommentStatus status):IBaseCommand;
}
