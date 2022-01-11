using checkout.application.Commands;
using checkout.application.Commands.Request;
using checkout.application.Dto.BaseReponse;
using checkout.domain.PaymentAggregate;
using checkout.infrastructure;
using MediatR;

namespace checkout.application.Handlers;

public class AddInvoiceAddressHandler : IRequestHandler<AddInvoiceAddressCommandRequest, BaseResponse<NoContent>>
{
    private DatabaseContext _context;

    public AddInvoiceAddressHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<BaseResponse<NoContent>> Handle(AddInvoiceAddressCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<NoContent>();

        //user id valid with mqtt
        if (false)
            return response.AddError(0,"User cannot found.");
        

        await _context.InvoiceAddresses.AddAsync(new InvoiceAddress()
        {
            UserId = request.UserId,
            City = request.Address.City,
            District = request.Address.District,
            Country = request.Address.Country
        });

        await _context.SaveChangesAsync();
        
        return response;
    }
}