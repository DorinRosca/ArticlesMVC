using MediatR;
using System.ComponentModel.DataAnnotations;
using ArticleApp.Web.UI.Article.Models;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Create
{
    public record CreateArticleCommand(ArticleViewModel Model) : IRequest<bool>
    {
        [Required]
        public DateTime TimeCreated;

        [Required, StringLength(50)]
        public string Author = Model.Author;

        [Required, StringLength(50)]
        public string Title = Model.Title;

        [Required, StringLength(500)]
        public string Message = Model.Message;

        [Required] public int PaymentId = Model.PaymentId;
    }
}
