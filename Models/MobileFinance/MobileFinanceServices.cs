using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class MobileFinanceServices
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Activation Date")]
        public DateTime ActivationDate { get; set; }

        public bool Active { get; set; }
    }
}
