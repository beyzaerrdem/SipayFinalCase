using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;

namespace Api.Business;

public interface IInvoiceService : IGenericService<Invoice, InvoiceRequest, InvoiceResponse> 
{
    public decimal Debt(int userId,decimal paymentAmount);
}
