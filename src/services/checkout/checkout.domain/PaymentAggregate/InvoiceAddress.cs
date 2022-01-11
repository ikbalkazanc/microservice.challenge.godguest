using System.ComponentModel.DataAnnotations;
using checkout.domain.core;

namespace checkout.domain.PaymentAggregate;

public class InvoiceAddress : BaseEntity
{
    public int UserId { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)]
    public string Country { get; set; }
    [MaxLength(50)]
    public string District { get; set; }
}