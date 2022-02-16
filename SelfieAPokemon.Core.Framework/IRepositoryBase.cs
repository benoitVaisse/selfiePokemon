using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Framework
{
    public interface IRepositoryBase
    {

        IUnitOfWork UnitOfWork { get; }

    }
}
