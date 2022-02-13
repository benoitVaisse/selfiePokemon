using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SelfieAPokemon.Core.Domain
{
    public class Pokemon
    {
        #region Properties

        //[Key]
        //public Guid Id { get; set; }


        [Key]
        public int Id { get; set; }

        [JsonIgnore] // ou alors convertir en dto
        public List<Selfie> Selfies { get; set; }        
        
        #endregion
    }
}
