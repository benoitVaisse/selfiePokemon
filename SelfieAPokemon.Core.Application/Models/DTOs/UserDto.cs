﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.DTOs
{
    public class UserDto
    {
        public string Email{ get; set; }
        public string Name{ get; set; }
        public string Token{ get; set; }
    }
}
