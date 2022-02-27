using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SelfieAPokemon.Core.Domain
{
    public class Pokemon
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        //[Key]
        //public int Id { get; set; }

        public List<Selfie> Selfies { get; set; }        
        
        #endregion
    }
}
