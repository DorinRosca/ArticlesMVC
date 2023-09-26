using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArticleApp.EntityFramework.Entities
{
     public class Article
     {
          [Key]
          [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
          public int ArticleId { get; set; }
          
          [Required, Column(TypeName = "Datetime")]
          public DateTime TimeCreated { get; set; }
          
          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Author { get; set; }

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Title { get; set; }

          [Required, StringLength(500), Column(TypeName = "nvarchar(500)")]
          public string Message { get; set; }

           [Required]
           [ForeignKey("Payment")]
          public int PaymentId { get; set; }
     }
}
