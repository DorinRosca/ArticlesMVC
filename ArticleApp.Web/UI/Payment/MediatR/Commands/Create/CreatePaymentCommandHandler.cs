using ArticleApp.EntityFramework.Context;
using AutoMapper;
using MediatR;

namespace ArticleApp.Web.UI.Payment.MediatR.Commands.Create
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int?>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CreatePaymentCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int?> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<EntityFramework.Entities.Payment>(request);
            await _context.Payments.AddAsync(payment, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return payment.PaymentId;
            }
            return null;
        }

    }
}
