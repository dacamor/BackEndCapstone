using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCapstone.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        //File name for the photo in the file system
        [StringLength(255)]
        public string PhotoName { get; set; }
        
        public virtual ICollection<PlayerAttribute> PlayerAttributes { get; set; }
    }
}
