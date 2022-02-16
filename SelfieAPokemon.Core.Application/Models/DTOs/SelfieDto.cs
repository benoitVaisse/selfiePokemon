using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.DTOs
{
    public class SelfieDto
    {
        #region Properties
        public int Id{ get; set; }
        public string Title{ get; set; }
        public string ImagePath{ get; set; }
        #endregion
    }
}
