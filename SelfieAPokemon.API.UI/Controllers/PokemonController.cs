using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAPokemon.Core.Application.Mappers;
using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Domain;
using SelfieAPokemon.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAPokemon.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository PokemonRepository)
        {
            this._pokemonRepository = PokemonRepository;
        }

        [HttpPost]
        public async Task<ActionResult<PokemonDto>> AddPokemon([FromBody]PokemonDto dto)
        {
            ActionResult result = BadRequest();
            Pokemon addedPokemon = await this._pokemonRepository.Add(dto.MapDtoToEntityRegister());
            this._pokemonRepository.UnitOfWork.SaveChanges();
            if(addedPokemon.Id != Guid.Empty)
            {
                dto.Id = addedPokemon.Id;
                result = Ok(dto);
            }

            return result;
        }
    }
}
