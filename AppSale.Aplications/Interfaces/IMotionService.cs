using AppSale.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Aplications.Interfaces
{
    public interface IMotionService<TEntity, TEntityID> : IAdd<TEntity>, IList<TEntity, TEntityID>
    {
        void Cancel(TEntityID entityID);
    }
}
