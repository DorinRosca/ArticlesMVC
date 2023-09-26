using ArticleApp.EntityFramework.Context;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Update
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, bool>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The model parameter cannot be null.");
            }

            var entity = _mapper.Map<EntityFramework.Entities.Article>(request);
            _context.Entry(entity).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
