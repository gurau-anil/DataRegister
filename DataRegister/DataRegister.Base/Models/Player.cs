using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRegister.Base.Models
{
    public class Player
    {
        public string PlayerId { get; set; }


        [Display(Name ="First Name")]
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }


        [Required]
        public string Club { get; set; }


        [Required]
        public string Phone { get; set; }


        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email doesn't look like a valid email address.")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }


        public string Image { get; set; }
        public Player()
        {
            this.PlayerId = Guid.NewGuid().ToString();
        }
    }
}
