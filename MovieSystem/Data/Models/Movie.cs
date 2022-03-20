namespace MovieSystem.Data.Models
{
    using MovieSystem.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.;
    public class Movie
    {
        [Key]
        public int Id { get; init; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImgUrl {get; set;}

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }
    }
}
