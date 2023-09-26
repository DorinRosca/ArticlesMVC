using ArticleApp.EntityFramework.Context;
using MediatR;

namespace ArticleApp.Web.UI.Article.MediatR.Commands.Delete
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, bool>
    {
        private readonly DataContext _context;


        public DeleteArticleCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {

            if (request.ArticleId == 0)
            {
                throw new ArgumentNullException(nameof(request.ArticleId), "The Id parameter cannot be zero.");
            }

            var entity = await _context.Articles.FindAsync(request.ArticleId, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.ArticleId), "There is no entity with such Id.");

            }

            _context.Articles.Remove(entity);

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
