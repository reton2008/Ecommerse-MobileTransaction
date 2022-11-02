using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.MobileFinance
{
    public class WalletAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Finance Service")]
        public int MobFinSerId { get; set; }

        [ForeignKey("MobFinSerId")]
        public MobileFinanceServices MobileFinanceServices { get; set; }

        [Required]
        [Display(Name = "Operator")]
        public int MobOperatorId { get; set; }

        [ForeignKey("MobOperatorId")]
        public MobileOperator MobileOperator { get; set; }

        [Column(TypeName = "decimal(17,2)")]
        public decimal Balance { get; set; }

        public bool Active { get; set; }
    }
}
