using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.DTOs
{
    public class BadRequestDto
    {
        public string Title { get; set; }
        public int status { get; set; }

        public List<string> Errors { get; set; }
    }
}
