namespace MovieSystem.Models.Movies
{

    using MovieSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Movie;

    public class NewMoviesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Movie title")]
        [Required(ErrorMessage = " Movie title is required .")]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Display(Description = "Information about the movie")]
        [Required(ErrorMessage = "It is required to write some words . ")]
        [MinLength(DescrMingLength)]
        public string Description { get; set; }

        [Display(Description = "Price in $")]
        [Required(ErrorMessage = "Price is in range from 5 $ to  1000 $ .")]
        [Range(MinPrice, MaxPrice)]
        public double Price { get; set; }

        [Display(Description = "Movie poster")]
        [Required(ErrorMessage = "Put vallid Image URL .")]
        public string ImgUrl { get; set; }

        [Display(Description = "Movie start date")]
        [Required(ErrorMessage = "Put vallid relise date of the movie screening .")]
        public DateTime StartDate { get; set; }

        [Display(Description = "Movie end date")]
        [Required(ErrorMessage = "Put vallid end date of the movie screening .")]
        public DateTime EndDate { get; set; }

        [Display(Description = "Select category")]
        [Required(ErrorMessage = "Select some category from downfall menue .")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Description = "Select movie theater")]
        [Required(ErrorMessage = "Select cinema .")]
        public int CinemaId { get; set; }

        [Display(Description = "Select creator of the movie")]
        [Required(ErrorMessage = "Author is required !")]
        public int ProducerId { get; set; }

        [Display(Description = "Select the actors in the movie")]
        [Required(ErrorMessage = "Actor(s) is/are required !")]
        public List<int> ActiorIds { get; set; }

    }
}
