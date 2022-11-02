using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Models.MobileFinance
{
    public class MobileOperator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Operator Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Operetor Short Name")]
        public string OpShortName { get; set; }

        public bool Active { get; set; }
    }
}
