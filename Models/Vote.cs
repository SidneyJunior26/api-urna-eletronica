using System;
using System.ComponentModel.DataAnnotations;

namespace Api_UrnaEletronica.Models
{
    public class Vote
    {
        [Key]
        public int id { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "Invalid Candidate")]
        public int candidateId { get; set; }
        
        public Candidate candidate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime voteDate { get; set; }

        public int candidateVotes { get; set; }

        public Vote(){
            this.voteDate = DateTime.UtcNow;
        }
    }
}