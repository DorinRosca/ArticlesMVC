using ArticleApp.Web.UI.Article.Models;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Queries.GetAll
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<ArticleViewModel>>
    {
    }
}
