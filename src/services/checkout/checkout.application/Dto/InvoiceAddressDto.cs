namespace checkout.application.Dto;

public class InvoiceAddressDto
{
    public InvoiceAddressDto(string city, string country, string district)
    {
        City = city;
        Country = country;
        District = district;
    }

    public InvoiceAddressDto()
    {
        
    }

    public int UserId { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string District { get; set; }
}