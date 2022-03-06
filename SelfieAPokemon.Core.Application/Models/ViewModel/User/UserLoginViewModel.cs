using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.ViewModel.User
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email{ get; set; }

        [Required]
        public string Password{ get; set; }
    }
}
