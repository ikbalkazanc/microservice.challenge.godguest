namespace checkout.application.Dto;

public class PaymentDto
{
    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public decimal Amount { get; set; }
    public string InvoiceType  { get; set; }
}