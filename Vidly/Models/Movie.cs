﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public byte Stock { get; set; }
        public Genre Genre { get; set; }
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}