using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.MobileFinance
{
    public class CashWallet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cash Wallet Name")]
        public string CashWalletName { get; set; }

        [Required]
        [Display(Name = "Wallet Short Name")]
        public string CashShortName { get; set; }

        [Column(TypeName = "decimal(17,2)")]
        public decimal Balance { get; set; }

        public bool Active { get; set; }
    }
}
