namespace MovieSystem.Data.Models
{
    using MovieSystem.Models.Base;
    using MovieSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants.Movie;
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Display(Name ="Title")]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescrMaxLength)]
        [Display(Name ="Movie Intro")]
        public string Description { get; set; }

        public double Price { get; set; }

        public string ImgUrl {get; set;}

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        public List<ConnectionTable> ConnectionTables { get; set; }

    }
}
