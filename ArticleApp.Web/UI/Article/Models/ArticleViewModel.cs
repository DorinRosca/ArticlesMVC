using System.ComponentModel.DataAnnotations;

namespace ArticleApp.Web.UI.Article.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        [Required]
        public DateTime TimeCreated { get; set; }

        [Required, StringLength(50)]
        public string Author { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; }

        public int PaymentId { get; set; }

    }
}
