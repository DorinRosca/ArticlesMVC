using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleApp.EntityFramework.Entities
{
     public class Payment
     {
          [Key]
          [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
          public int PaymentId { get; set; }
          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string CardName { get; set; }
          [Required, StringLength(16), Column(TypeName = "nvarchar(16)")]
          public string CardNumber { get; set; }


          [Required, StringLength(3), Column(TypeName = "nvarchar(3)")]
          public string CVVNumber { get; set; }
          
          [Required, StringLength(4), Column(TypeName = "nvarchar(4)")]
          public string ExpirationDate { get; set; }
           public Article Article { get; set; }
      }
}
