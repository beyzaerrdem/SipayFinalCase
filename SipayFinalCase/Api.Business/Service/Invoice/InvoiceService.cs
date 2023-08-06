using Api.Business.Service.Generic;
using Api.DataAccess.Models;
using Api.DataAccess.UnitOfWork;
using Api.Schema.Request;
using Api.Schema.Response;
using AutoMapper;

namespace Api.Business;

public class InvoiceService : GenericService<Invoice,InvoiceRequest,InvoiceResponse> , IInvoiceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public decimal Debt(int userId, decimal paymentAmount)
    {
        var invoice = _unitOfWork.InvoiceRepository.Where(x => x.User.UserLoginId == userId).First();
        invoice.PaidDept += paymentAmount;
        _unitOfWork.InvoiceRepository.Update(invoice);
        _unitOfWork.Saved();
        return invoice.DeptAmount;
    }
}
