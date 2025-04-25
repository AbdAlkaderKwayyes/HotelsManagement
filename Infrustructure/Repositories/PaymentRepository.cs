using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;

namespace Infrustructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }

}
