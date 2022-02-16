using SelfieAPokemon.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Domain.Interfaces
{
    public interface IRepostoryBaseDomain<T>: IRepositoryBase where T : class
    {

        Task<ICollection<T>> GetAll();

        Task<T> Get(int Id);

        Task<T> Add(T selfie);
    }
}
