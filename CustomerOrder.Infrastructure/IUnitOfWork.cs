using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<bool> Completed();
    }
}
