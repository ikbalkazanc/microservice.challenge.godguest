using checkout.application.Dto;

namespace checkout.application.Queries.Response;

public class PaymentHistoryQueryResponse
{
    public List<PaymentHistoryListItem> Payments { get; set; }
}