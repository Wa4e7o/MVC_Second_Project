namespace MovieSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Actior;

    public class Actior
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        [Display(Name = "Biography")]
        public string Biography { get; set; }

        [Display(Name="Profil Picture Url")]
        public string ImageURL { get; set; }

        public List<ConnectionTable> ConnectionTables { get; set; }
    }
}
