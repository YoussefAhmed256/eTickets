using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer> , IProducersService
    {
        public ProducersService(AppDbContext _context):base(_context){}
    }
}
