using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArticleApp.Web.UI.Article.Models;

namespace ArticleApp.Web.UI.Payment.Models
{
    public class PaymentViewModel
    {

        [Required, StringLength(16), Column(TypeName = "nvarchar(16)")]
        [MinLength(16)]
        public string CardNumber { get; set; }


        [Required, StringLength(3), Column(TypeName = "nvarchar(3)")]
        [MinLength(3)]
        public string CVVNumber { get; set; }
        public ArticleViewModel Article { get; set; }
        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string CardName { get; set; }

        [Required, StringLength(4), Column(TypeName = "nvarchar(4)")]
        public string ExpirationDate { get; set; }
        public string SerilizedArticle { get; set; }
    }
}
