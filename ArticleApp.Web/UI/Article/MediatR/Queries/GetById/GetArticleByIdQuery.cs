using ArticleApp.Web.UI.Article.Models;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Queries.GetById
{
    public record GetArticleByIdQuery(int ArticleId) : IRequest<ArticleViewModel>
    {
        public int ArticleId = ArticleId;
    }
}
