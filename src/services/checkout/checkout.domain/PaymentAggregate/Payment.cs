using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkout.domain.core;

namespace checkout.domain.PaymentAggregate
{
    public class Payment : BaseEntity, IAggregateRoot
    {
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int InvoiceAddressId { get; set; }

        public InvoiceAddress InvoiceAddress;
      


    }
}