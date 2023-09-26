using ArticleApp.EntityFramework.Context;
using ArticleApp.Web.UI.Article.Models;
using AutoMapper;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Queries.GetById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleViewModel>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetArticleByIdQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArticleViewModel> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.ArticleId == 0)
            {
                throw new ArgumentNullException(nameof(request.ArticleId), "The Id parameter cannot be zero.");

            }

            var entity = await _context.Articles.FindAsync(request.ArticleId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.ArticleId), "There is no entity with such Id.");

            }

            var model = _mapper.Map<ArticleViewModel>(entity);
            return model;
        }
    }
}
