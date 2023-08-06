using Api.Base.BaseResponse;
using Api.Business;
using Api.Business.ValidationRules;
using Api.Schema.Request;
using Api.Schema.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {    
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public ApiResponse<List<ApartmentResponse>> GetAll()
        {
            var entityList = _apartmentService.GetAll();
            return entityList;
        }

        [HttpGet("{id}")]
        public ApiResponse<ApartmentResponse> Get(int id)
        {
            var entity = _apartmentService.GetById(id);
            return entity;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {
            ApartmentValidator apartmentValidator = new ApartmentValidator();
            var result = apartmentValidator.Validate(request);
            if (result.IsValid)
            {
                var entity = _apartmentService.Insert(request);
                return entity;
            }
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errorMessages);
            return new ApiResponse { Success = false, Message = errorMessage };
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
        {
            ApartmentValidator apartmentValidator = new ApartmentValidator();
            var result = apartmentValidator.Validate(request);
            if (result.IsValid)
            {
                var response = _apartmentService.Update(id, request);
                return response;
            }
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errorMessages);
            return new ApiResponse { Success = false, Message = errorMessage };
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var response = _apartmentService.Delete(id);
            return response;
        }
    }
}
