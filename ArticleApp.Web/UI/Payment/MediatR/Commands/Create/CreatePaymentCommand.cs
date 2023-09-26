using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArticleApp.Web.UI.Payment.Models;

namespace ArticleApp.Web.UI.Payment.MediatR.Commands.Create
{
    public record CreatePaymentCommand(PaymentViewModel Model) : IRequest<int?>
    {
        [Required, StringLength(16), Column(TypeName = "nvarchar(16)")]
        public string CardNumber = Model.CardNumber;


        [Required, StringLength(3), Column(TypeName = "nvarchar(3)")]
        public string CVVNumber = Model.CVVNumber;

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string CardName = Model.CardName;

        [Required, StringLength(4), Column(TypeName = "nvarchar(4)")]
        public string ExpirationDate = Model.ExpirationDate;
    }
}
