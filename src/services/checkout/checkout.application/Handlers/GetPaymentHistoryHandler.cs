using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkout.application.Dto;
using checkout.application.Dto.BaseReponse;
using checkout.application.Queries;
using checkout.application.Queries.Request;
using checkout.application.Queries.Response;
using checkout.infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace checkout.application.Handlers
{
    public class GetPaymentHistoryHandler : IRequestHandler<PaymentHistoryQueryRequest,BaseResponse<PaymentHistoryQueryResponse>>
    {
        private DatabaseContext _context;

        public GetPaymentHistoryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<PaymentHistoryQueryResponse>> Handle(PaymentHistoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaymentHistoryQueryResponse>();

            //user id valid with mqtt
            if (false)
                return response.AddError(0, "User cannot found.");


            var payments = await _context.Payments.Where(x => x.UserId == request.UserId).Join(
                _context.InvoiceAddresses.Where(x => x.UserId == request.UserId), x => x.UserId, y => y.UserId,
                (payment, address) =>
                    new PaymentHistoryListItem
                    {
                        Address = new InvoiceAddressDto()
                        {
                            City = address.City,
                            Country = address.Country,
                            District = address.District
                        },
                        Payment = new PaymentDto()
                        {
                            RoomId = payment.RoomId,
                            Amount = payment.Amount,
                            InvoiceType = payment.IsIncome ? "invoice" : "expense"
                        }
                    }).ToListAsync();


            response.Data = new PaymentHistoryQueryResponse() { Payments = payments };

            return response;
        }
    }
}
