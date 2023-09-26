using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Delete
{
    public record DeleteArticleCommand(int ArticleId) : IRequest<bool>
    {
        [Required]
        public int ArticleId = ArticleId;

    }
}
