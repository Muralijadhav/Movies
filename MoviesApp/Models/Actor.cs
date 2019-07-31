using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Models
{
    public class Actor
    {
        public Actor()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int ActorId { get; set; }

        [Required(ErrorMessage = "Please Enter Actor Name")]
        [Display(Name = "Actor Name")]
        public string ActorName { get; set; }

        [Required(ErrorMessage = "Please Select Male/Female")]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Add Biography")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateUpdated { get; set; }

        [NotMapped]
        public bool Selected { get; set; }
    }
}