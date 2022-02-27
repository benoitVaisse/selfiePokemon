using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.DTOs
{
    public class PokemonDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public List<SelfieDto>? Selfies { get; set; }
    }
}
