using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCapstone.Models
{
    public class PlayerAttribute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Stat { get; set; }
        public int Value { get; set; }

        [Display(Name = "Player")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
