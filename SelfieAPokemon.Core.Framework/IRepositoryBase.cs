﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Framework
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> Get(int Id);

        IUnitOfWork UnitOfWork { get; }

    }
}
