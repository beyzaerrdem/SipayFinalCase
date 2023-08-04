﻿using Api.Base.BaseResponse;
using Api.Business;
using Api.Business.ValidationRules;
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
            InvoiceResponse invoiceResponse = new InvoiceResponse();
            InvoiceValidator invoiceValidator = new InvoiceValidator();
            var result = invoiceValidator.Validate(request);
            if (result.IsValid)
            {
    
                var entity = _invoiceService.Insert(request);
                return entity;
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errorMessages);
            return new ApiResponse { Success = false, Message = errorMessage };
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
