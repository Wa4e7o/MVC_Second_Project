namespace MovieSystem.Data.Models
{
    using MovieSystem.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Producer;

    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Display(Name="Full Name")]
        public string Name { get; set; }

        [Display(Name ="Profil Picture")]
        public string ImageURL { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        [Display(Name ="Biography")]
        public string Biography { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
