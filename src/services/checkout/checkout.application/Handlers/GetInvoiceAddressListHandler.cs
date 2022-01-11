using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using checkout.application.Queries;
using checkout.application.Queries.Request;
using checkout.application.Queries.Response;
using checkout.infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace checkout.application.Handlers;

public class GetInvoiceAddressListHandler : IRequestHandler<GetInvoiceAddressListQueryRequest, BaseResponse<GetInvoiceAddressListQueryResponse>>
{
    private DatabaseContext _context;

    public GetInvoiceAddressListHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<BaseResponse<GetInvoiceAddressListQueryResponse>> Handle(GetInvoiceAddressListQueryRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetInvoiceAddressListQueryResponse>();

        //user id valid with mqtt
        if (false)
            return response.AddError(0, "User cannot found.");

        var addresses = await _context.InvoiceAddresses.Where(x => x.UserId == request.UserId).ToListAsync();

        response.Data = new GetInvoiceAddressListQueryResponse();

        foreach (var item in addresses)
        {
            response.Data.Addresses.Add(new InvoiceAddressListItem(item.City,item.Country,item.District));
        }

        return response;
    }
}