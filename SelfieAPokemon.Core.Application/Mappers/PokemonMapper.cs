using SelfieAPokemon.Core.Application.Models.DTOs;
using SelfieAPokemon.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Mappers
{
    public static class PokemonMapper
    {

        public static Pokemon MapDtoToEntityRegister(this PokemonDto dto)
        {
            return new Pokemon()
            {
                Name = dto.Name
            };
        }
    }
}
