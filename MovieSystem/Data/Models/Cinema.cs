namespace MovieSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Cinema;

    public class Cinema
    {
        [Key]
        public int Id { get; init; }

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
