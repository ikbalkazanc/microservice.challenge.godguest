using System.ComponentModel.DataAnnotations;
using checkout.application.Commands;
using checkout.application.Commands.Request;
using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using checkout.application.Queries;
using checkout.application.Queries.Request;
using checkout.application.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checkout.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("{userId}")]
        public async Task<BaseResponse<PaymentHistoryQueryResponse>> PaymentHistory(PaymentHistoryQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost]
        public async Task<BaseResponse<GetInvoiceAddressListQueryResponse>> InvoiceAddressList(GetInvoiceAddressListQueryRequest request, [FromQuery] int page = 0)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        [HttpPost]
        public async Task<BaseResponse<NoContent>> AddInvoiceAddress(AddInvoiceAddressCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }


}
