namespace MovieSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Actior;

    public class Actior
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }
    }
}
