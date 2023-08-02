using Api.Base.BaseResponse;
using Api.Business;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public ApiResponse<List<InvoiceResponse>> GetAll()
        {
            var entityList = _invoiceService.GetAll();
            return entityList;
        }

        [HttpGet("{id}")]
        public ApiResponse<InvoiceResponse> Get(int id)
        {
            var entity = _invoiceService.GetById(id);
            return entity;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] InvoiceRequest request)
        {
            var entity = _invoiceService.Insert(request);
            return entity;
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] InvoiceRequest request)
        {
            var response = _invoiceService.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var response = _invoiceService.Delete(id);
            return response;
        }
    }
}
