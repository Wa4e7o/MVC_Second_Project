namespace MovieSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Actior;

    public class Actior
    {
        [Key]
        public int Id { get; init; }

        [Required(ErrorMessage = "Full Name is Required")]
        [MaxLength(NameMaxLength)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bio is Required")]
        [MaxLength(BiographyMaxLength)]
        [Display(Name = "Biography")]
        public string Biography { get; set; }

        [Required(ErrorMessage ="Profil Picture is Required")]
        [Display(Name="Profil Picture")]
        public string ImageURL { get; set; }

        public List<ConnectionTable> ConnectionTables { get; set; }
    }
}
