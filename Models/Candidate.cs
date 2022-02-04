using System;
using System.ComponentModel.DataAnnotations;

namespace Api_UrnaEletronica.Models
{
    public class Candidate
    {
        [Key]

        public int id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(200, ErrorMessage = "This field must contain a maximum of 200 characters.")]
        [MinLength(5, ErrorMessage = "This field must contain at least 5 characters.")]
        public string candidateName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(200, ErrorMessage = "This field must contain a maximum of 200 characters.")]
        [MinLength(5, ErrorMessage = "This field must contain at least 5 characters.")]
        public string deputyName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime registrationDate { get; set; }

        public string subtitle { get; set; }

        public Candidate(){
            this.registrationDate = DateTime.UtcNow;
        }
    }
}