namespace MovieSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Producer;

    public class Producer
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }
    }
}
