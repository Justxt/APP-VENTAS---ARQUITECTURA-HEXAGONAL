using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Interfaces.Repositories
{
    public interface IDetailRepository<TEntity, TMotionID> : IAdd<TEntity> , ITransaction
    {

    }
}
