using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Frequency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Frequency Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Display Order")]
        public int FrequencyCount { get; set; }

    }
}
