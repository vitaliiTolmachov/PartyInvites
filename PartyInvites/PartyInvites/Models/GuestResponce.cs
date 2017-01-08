using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponce
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please enter U'r name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Please enter U'r e-mail")]
        [RegularExpression(pattern: "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone 2 contact")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Plese specify whether you'll be attend")]
        public bool? WillAttend { get; set; }
    }
}