using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using SelfieAPokemon.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Infrastructures.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly SelfiesContext _context;

        public PokemonRepository(SelfiesContext context)
        {
            this._context = context;
        }
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
        public async Task<Pokemon> Get(int Id)
        {
            return await this._context.Pokemon.Include(p => p.Selfies ).Where(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Pokemon>> GetAll()
        {
            return await this._context.Pokemon
                .Include(p => p.Selfies).ToListAsync();
        }
    }
}
