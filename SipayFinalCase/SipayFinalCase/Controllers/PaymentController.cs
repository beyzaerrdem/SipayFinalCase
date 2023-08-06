using Api.Business;
using Api.Schema.Request;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Service.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly Iyzipay.Options _options;
        private readonly IInvoiceService _invoiceService;

        public PaymentController(IOptions<Iyzipay.Options> options, IInvoiceService invoiceService)
        {
            _options = options.Value;
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment([FromBody] PaymentRequest p)
        {
            try
            {
                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                //request.ConversationId = "123456789";
                request.Price = (p.PaymentAmount + 0.1).ToString();
                request.PaidPrice = (p.PaymentAmount + 0.1).ToString();
                request.Currency = Currency.TRY.ToString();             
                request.BasketId = "B67832";
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = "John Doe";
                paymentCard.CardNumber = p.CardNumber;
                paymentCard.ExpireMonth = p.ExpiryMonth.ToString();
                paymentCard.ExpireYear = p.ExpiryYear.ToString();
                paymentCard.Cvc = p.CVC.ToString();
                paymentCard.RegisterCard = 0;
                request.PaymentCard = paymentCard;

                var userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId");
                        
                Buyer buyer = new Buyer();
                buyer.Id = userId.ToString();
                buyer.Name = "john";
                buyer.Surname = "Doe";               
                buyer.Email = "email@email.com";
                buyer.IdentityNumber = "74300864791";     
                buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                buyer.Ip = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                buyer.City = "Istanbul";
                buyer.Country = "Turkey";
     
                request.Buyer = buyer;

                Address address = new Address();
                address.ContactName = "Jane Doe";
                address.City = "Istanbul";
                address.Country = "Turkey";
                address.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            
                request.ShippingAddress = address;
                request.BillingAddress = address;

                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = "BI101";
                firstBasketItem.Name = "Borc";
                firstBasketItem.Category1 = "Borc";
                firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
                firstBasketItem.Price = p.PaymentAmount.ToString();
                basketItems.Add(firstBasketItem);

                BasketItem secondBasketItem = new BasketItem();
                secondBasketItem.Id = "BI102";
                secondBasketItem.Name = "Game code";
                secondBasketItem.Category1 = "Game";
                secondBasketItem.Category2 = "Online Game Items";
                secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
                secondBasketItem.Price = "0.1";
                basketItems.Add(secondBasketItem);

                request.BasketItems = basketItems;

                Payment payment = Payment.Create(request, _options);
                              
                var debit = _invoiceService.Debt(int.Parse(userId.Value), decimal.Parse(payment.Price));                   
                return Ok(debit);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
