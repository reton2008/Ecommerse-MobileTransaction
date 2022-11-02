using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.MobileFinance
{
    public class ServiceCashWallet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [Display(Name = "Service Wallet Account")]
        public int WalletId { get; set; }

        [ForeignKey("WalletAccoutId")]
        public WalletAccount WalletAccount { get; set; }

        [Required]
        [Display(Name = "Cash Wallet")]
        public int CashId { get; set; }

        [ForeignKey("CashWallettId")]
        public CashWallet CashWallet { get; set; }

        public bool Active { get; set; }
    }
}
