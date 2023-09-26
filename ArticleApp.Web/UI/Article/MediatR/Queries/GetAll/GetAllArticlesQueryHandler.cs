using ArticleApp.EntityFramework.Context;
using ArticleApp.Web.UI.Article.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Web.UI.Article.MediatR.Queries.GetAll
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<ArticleViewModel>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllArticlesQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleViewModel>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {

            var dataList = await _context.Articles.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<ArticleViewModel>(entity));
            return result;
        }
    }
}
