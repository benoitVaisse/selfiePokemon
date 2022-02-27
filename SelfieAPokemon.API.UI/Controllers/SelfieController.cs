using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAPokemon.Core.Application.Mappers;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Application.Services;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using SelfieAPokemon.Core.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAPokemon.API.UI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SelfieController : ControllerBase
    {
        private readonly IRegisterImageToServerService _registerImageToServerService;
        private readonly ISelfieRepository _selfieRepository;
        private readonly IWebHostEnvironment _webHost;

        public SelfieController(ISelfieRepository selfieRepository, 
            IRegisterImageToServerService RegisterImageToServerService,
            IWebHostEnvironment WebHost)
        {
            this._selfieRepository = selfieRepository;
            this._registerImageToServerService = RegisterImageToServerService;
            this._webHost = WebHost;
        }


        #region public methods

        [HttpGet]
        public async Task<ActionResult<List<SelfieDto>>> GetAll()
        {
            //return Ok(Enumerable.Range(1, 10).Select(i => new Selfie() { Id =  Guid.NewGuid() }).ToList());
            ICollection<SelfieDto> selfies = (await this._selfieRepository.GetAll()).Select(e => e.MapEntityToDto()).ToList();

            return Ok(selfies);
        }

        [HttpGet]
        [Route("{id:Guid}", Name ="get_one_selfie")]
        public async Task<ActionResult<SelfieDto>> Get([FromRoute]Guid id)
        {
            SelfieDto dto = (await this._selfieRepository.Get(id)).MapEntityToDto();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<SelfieDto>> AddOne([FromForm]SelfieSaveDto dto)
        {
            ActionResult result = BadRequest();
            string ImagePath = string.Empty;
            ImagePath = await this._registerImageToServerService.SaveImage(Path.Combine(this._webHost.ContentRootPath, $"Images\\Selfies\\{dto.PokemonId}"), dto.ImagePath);
            Selfie addSelfie = await this._selfieRepository.Add(new Selfie()
            {
                PokemonId = dto.PokemonId,
                ImagePath = ImagePath,
                Title = dto.Title
            });
            this._selfieRepository.UnitOfWork.SaveChanges();
            if(addSelfie.Id != Guid.Empty)
            {
                SelfieDto selfieDto = addSelfie.MapEntityToDto();
                result = Ok(selfieDto);
            }
            return result;
        }
        #endregion

    }
}
