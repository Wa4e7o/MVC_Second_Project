namespace MovieSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Actior;

    public class Actior
    {
        [Key]
        public int Id { get; init; }

        [Display(Name = "Full Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }

        [Display(Name="Profil Picture Url")]
        public string ImageURL { get; set; }

        public List<ConnectionTable> ConnectionTables { get; set; }
    }
}
