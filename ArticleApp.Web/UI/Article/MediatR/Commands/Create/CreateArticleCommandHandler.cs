using ArticleApp.EntityFramework.Context;
using AutoMapper;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, bool>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            SetTime(request);
            var Article = _mapper.Map<EntityFramework.Entities.Article>(request);
            await _context.Articles.AddAsync(Article, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        private void SetTime(CreateArticleCommand model)
        {
            model.TimeCreated = DateTime.Now;
        }
    }
}
