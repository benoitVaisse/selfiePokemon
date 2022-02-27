using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Mappers
{
    public static class SelfieMapper
    {
        public static SelfieDto MapEntityToDto(this Selfie selfie)
        {
            SelfieDto dto = new SelfieDto()
            {
                Id = selfie.Id,
                Title = selfie.Title,
                ImagePath = selfie.ImagePath,
                PokemonDto = new PokemonDto()
                {
                    Id = selfie.Pokemon != null ? selfie.Pokemon.Id : selfie.PokemonId
                }
            };

            return dto;
        }
    }
}
