﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Interfaces.Repositories
{
    public interface IMotionRepository<TEntity, TEntityID> : IAdd<TEntity>, IList<TEntity, TEntityID>, ITransaction
    {
        void Cancel(TEntityID entityID);
    }
}
