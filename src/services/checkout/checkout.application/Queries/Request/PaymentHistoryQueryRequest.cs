using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using checkout.application.Queries.Response;
using MediatR;

namespace checkout.application.Queries.Request
{
    public class PaymentHistoryQueryRequest : IRequest<BaseResponse<PaymentHistoryQueryResponse>>
    {
        public int UserId { get; set; }
        public int Page { get; set; } = 0;

    }
}
