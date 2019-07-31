using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Movie
    {
        public Movie()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Name")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Please Enter Year of Release")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Year of Release")]
        public DateTime YearOfRelease { get; set; }

        [Required(ErrorMessage = "Please add Plot of Movie")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Plot")]
        public string Plot { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster Image")]
        public string PosterImage { get; set; }

        public virtual List<Actor> Actors { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? DateUpdated { get; set; }
    }
}