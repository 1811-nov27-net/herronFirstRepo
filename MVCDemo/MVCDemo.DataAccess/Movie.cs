using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.DataAccess
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)] // max 50 chars
        public string Title { get; set; }

        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        
        public virtual ICollection<CasteMember> CastMembers { get; set; }
    }
}