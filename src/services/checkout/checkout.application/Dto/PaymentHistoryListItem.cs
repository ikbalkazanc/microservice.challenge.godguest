namespace checkout.application.Dto;

public class PaymentHistoryListItem
{
    public InvoiceAddressDto Address { get; set; }

    public PaymentDto Payment { get; set; }
}