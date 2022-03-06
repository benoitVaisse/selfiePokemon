using SelfieAPokemon.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Services.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateJwtToken(User user);
    }
}
