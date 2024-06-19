using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        void Edit(TEntity entity);
    }
}
