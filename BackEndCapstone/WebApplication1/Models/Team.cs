using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCapstone.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        
        //File name for the photo in the file system
        [StringLength(255)]
        public string PhotoName { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}
