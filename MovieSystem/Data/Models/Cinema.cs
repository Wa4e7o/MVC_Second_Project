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
        public string Name { get; set; }

        [Required]
        [MaxLength(DescrpMaxLength)]
        public string Description { get; set; }

        public string Logo { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
