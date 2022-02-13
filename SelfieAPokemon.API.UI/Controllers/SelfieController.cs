using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAPokemon.API.UI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SelfieController : ControllerBase
    {
        private readonly SelfiesContext _context;

        public SelfieController(SelfiesContext context)
        {
            this._context = context;
        }


        #region public methods

        [HttpGet]
        public async Task<ActionResult<List<Selfie>>> TestAMoi()
        {
            //return Ok(Enumerable.Range(1, 10).Select(i => new Selfie() { Id =  Guid.NewGuid() }).ToList());
            List<Selfie> selfies = await this._context.Selfie
                .Include(s=>s.Pokemon).ToListAsync();

            return Ok(selfies);
        }
        #endregion

    }
}
