using ArticleApp.Web.UI.Article.MediatR.Commands.Create;
using ArticleApp.Web.UI.Article.MediatR.Commands.Delete;
using ArticleApp.Web.UI.Article.MediatR.Commands.Update;
using ArticleApp.Web.UI.Article.MediatR.Queries.GetAll;
using ArticleApp.Web.UI.Article.MediatR.Queries.GetById;
using ArticleApp.Web.UI.Article.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.Web.UI.Article
{
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var articleList = await _mediator.Send(new GetAllArticlesQuery());
            return View(articleList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Add", "Payment", model);
            }
            return View();
        }

        public async Task<IActionResult> Save(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateArticleCommand(model));

                if (result)
                {
                    return RedirectToAction("Success", "Home");
                }
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int ArticleId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteArticleCommand(ArticleId));

                if (result)
                {
                    return RedirectToAction("Success", "Home");
                }
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<ActionResult> Update(int id)
        {
            if (ModelState.IsValid)
            {
                var model = await _mediator.Send(new GetArticleByIdQuery(id));

                return View(model);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _mediator.Send(new UpdateArticleCommand(model));
            if (result)
            {
                return RedirectToAction("Success", "Home");
            }

            return View(model);
        }
    }
}
