namespace MovieSystem.Data.Models
{
    using MovieSystem.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Cinema;

    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Display(Name="Commercial Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescrpMaxLength)]
        [Display(Name="Saloon description")]
        public string Description { get; set; }

        [Display(Name="Cinema Logo")]
        public string Logo { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
