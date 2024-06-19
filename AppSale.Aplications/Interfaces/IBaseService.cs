using AppSale.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Aplications.Interfaces
{
    public interface IBaseService<TEntity, TEntityID> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>
    {

    }
}
