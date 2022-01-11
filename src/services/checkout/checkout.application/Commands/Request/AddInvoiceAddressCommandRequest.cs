using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using MediatR;

namespace checkout.application.Commands.Request
{
    public class AddInvoiceAddressCommandRequest : IRequest<BaseResponse<NoContent>>
    {
        public int UserId { get; set; }
        public InvoiceAddressDto Address { get; set; }
    }
}
