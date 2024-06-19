using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSale.Domain.Interfaces;

namespace AppSale.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityID> : IAdd<TEntity>, IDelete<TEntityID>, IEdit<TEntity>, IList<TEntity, TEntityID>, ITransaction
    {

    }
}
