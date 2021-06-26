using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _ctx;

        public UnitOfWork(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Completed()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
