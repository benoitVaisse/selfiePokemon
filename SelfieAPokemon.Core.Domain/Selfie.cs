using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfieAPokemon.Core.Domain
{

    /// <summary>
    /// represente un selfie
    /// </summary>
    public class Selfie
    {
        #region properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        //[Key]
        //public int Id { get; set; }

        public Guid PokemonId { get; set; }
        public Pokemon Pokemon {get;set;}

        public string ImagePath { get; set; }

        public string Title { get; set; }
        #endregion
    }
}
