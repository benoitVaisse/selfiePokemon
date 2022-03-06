using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAPokemon.Core.Application.Models.ViewModel.User
{
    public class UserRegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email{ get; set; }
        
        public string Name{ get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password{ get; set; }
        [Required]
        public string ConfirmPassword{ get; set; }
    }
}
