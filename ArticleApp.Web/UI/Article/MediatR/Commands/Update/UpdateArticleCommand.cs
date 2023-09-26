using ArticleApp.Web.UI.Article.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Update
{
    public record UpdateArticleCommand(ArticleViewModel Model) : IRequest<bool>
    {
        [Required]
        public int ArticleId = Model.ArticleId;
        [Required]
        public DateTime TimeCreated = Model.TimeCreated;

        [Required, StringLength(50)]
        public string Author = Model.Author;

        [Required, StringLength(50)]
        public string Title = Model.Title;

        [Required, StringLength(500)]
        public string Message = Model.Message;

        [Required]
        public int PaymentId = Model.PaymentId;
    }
}
