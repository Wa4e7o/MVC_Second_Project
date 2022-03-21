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
        public string Name { get; set; }

        public string ImageURL { get; set; }

        [Required]
        [MaxLength(BiographyMaxLength)]
        public string Biography { get; set; }

        public List<ConnectionTable> ConnectionTables { get; set; }
    }
}
