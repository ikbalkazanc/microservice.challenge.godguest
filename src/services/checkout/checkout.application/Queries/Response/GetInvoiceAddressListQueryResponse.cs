using checkout.application.Dto;

namespace checkout.application.Queries.Response;

public class GetInvoiceAddressListQueryResponse
{
    public GetInvoiceAddressListQueryResponse()
    {
        Addresses = new List<InvoiceAddressListItem>();
    }
    public List<InvoiceAddressListItem> Addresses { get; set; }
}