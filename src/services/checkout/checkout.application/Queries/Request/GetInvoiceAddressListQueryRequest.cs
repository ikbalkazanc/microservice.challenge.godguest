using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using checkout.application.Queries.Response;
using MediatR;

namespace checkout.application.Queries.Request;

public class GetInvoiceAddressListQueryRequest : IRequest<BaseResponse<GetInvoiceAddressListQueryResponse>>
{
    public int UserId { get; set; }

}