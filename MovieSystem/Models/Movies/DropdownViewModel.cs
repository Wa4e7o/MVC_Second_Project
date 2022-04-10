namespace MovieSystem.Models.Movies
{
    using MovieSystem.Data.Models;
    using System;
    using System.Collections.Generic;

    public class DropdownViewModel
    {
        // We don't have prop here, because they will be enums for dorpdown menu;
        public DropdownViewModel()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actiors = new List<Actior>();
        }
        public List<Producer> Producers { get; set; }
        
        public List<Cinema> Cinemas { get; set; }

        public List<Actior> Actiors { get; set; }

    }
}
