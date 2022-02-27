using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.DTOs
{
    public class SelfieSaveDto
    {
        #region Properties
        public string Title { get; set; }
        public IFormFile ImagePath { get; set; }

        public Guid PokemonId { get; set; }
        #endregion
    }
}
