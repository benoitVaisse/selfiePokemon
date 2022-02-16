using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
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
        private readonly ISelfieRepository _selfieRepository;

        public SelfieController(ISelfieRepository selfieRepository)
        {
            this._selfieRepository = selfieRepository;
        }


        #region public methods

        [HttpGet]
        public async Task<ActionResult<List<Selfie>>> TestAMoi()
        {
            //return Ok(Enumerable.Range(1, 10).Select(i => new Selfie() { Id =  Guid.NewGuid() }).ToList());
            ICollection<Selfie> selfies = await this._selfieRepository.GetAll();

            return Ok(selfies);
        }

        [HttpPost]
        public async Task<IActionResult> AddOne(SelfieDto selfieDto)
        {
            IActionResult result = BadRequest();
            Selfie addSelfie = await this._selfieRepository.Add(new Selfie()
            {
                ImagePath = selfieDto.ImagePath,
                Title = selfieDto.Title
            });
            this._selfieRepository.UnitOfWork.SaveChanges();
            if(addSelfie.Id > 0)
            {
                selfieDto.Id = addSelfie.Id;
                result = Ok(selfieDto);
            }
            return result;
        }
        #endregion

    }
}
