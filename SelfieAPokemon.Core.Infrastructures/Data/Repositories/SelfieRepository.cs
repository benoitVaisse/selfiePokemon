using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Infrastructures.Data.Repositories
{
    public class SelfieRepository : ISelfieRepository
    {
        private readonly SelfiesContext _context;

        #region contrustor
        public SelfieRepository(SelfiesContext context)
        {
            this._context = context;
        }
        #endregion
        public async Task<Selfie> Get(int Id)
        {
            return await  this._context.Selfie.Include(s => s.Pokemon).Where(s => s.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Selfie>> GetAll()
        {
            return await this._context.Selfie
                .Include(s => s.Pokemon).ToListAsync();
        }
    }
}
