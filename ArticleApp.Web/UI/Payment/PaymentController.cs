using ArticleApp.Web.UI.Article.Models;
using ArticleApp.Web.UI.Payment.MediatR.Commands.Create;
using ArticleApp.Web.UI.Payment.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ArticleApp.Web.UI.Payment
{
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Add(ArticleViewModel model)
        {
            HttpContext.Session.SetString("ArticleData", JsonConvert.SerializeObject(model));
            var json = JsonConvert.SerializeObject(model);
            var payment = new PaymentViewModel
            {
                SerilizedArticle = json,
                Article = model
            };
            return View(payment);
        }

        public async Task<IActionResult> Save(PaymentViewModel model)
        {
            var result = await _mediator.Send(new CreatePaymentCommand(model));
            if (result > 0 || result != null)
            {
                var article = JsonConvert.DeserializeObject<ArticleViewModel>(model.SerilizedArticle);
                article.PaymentId = (int)result;
                return RedirectToAction("Save", "Article", article);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
