using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Backend.Dtos;
using Backend.Models;

namespace Backend_API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StripeController : BaseController
    {
        private readonly IConfiguration _config;

        private static string s_wasmClientURL=string.Empty;

        public StripeController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult<Backend.Dtos.StripeResponse>> StripeResponse([FromBody] Backend.Dtos.StripeRequest request, [FromServices] IServiceProvider sp)
        {
            var referer = Request.Headers.Referer;
            s_wasmClientURL = referer[0];
           
            // Build the URL to which the customer will be redirected after paying.
            var server = sp.GetRequiredService<IServer>();

            var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

            string? thisApiUrl = null;

            if (serverAddressesFeature is not null)
            {
                thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
            }

            if (thisApiUrl is not null)
            {
                var sessionId = await CheckOut(request, thisApiUrl);
                var pubKey = _config["Stripe:PubKey"];

                var stripeResponse = new Backend.Dtos.StripeResponse(sessionId, pubKey);

                return Ok(stripeResponse);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [NonAction]
        public async Task<string> CheckOut(Backend.Dtos.StripeRequest request, string thisApiUrl)
        {
            // Create a payment flow from the items in the cart.
            // Gets sent to Stripe API.
            var options = new SessionCreateOptions
            {
                // Stripe calls the URLs below when certain checkout events happen such as success and failure.
                SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}", // Customer paid.
                CancelUrl = s_wasmClientURL + "failed",  // Checkout cancelled.
                PaymentMethodTypes = new List<string> // Only card available in test mode?
            {
                "card"
            },
                LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long?)request.Amount, // Price is in USD cents.
                        Currency = "NZD",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.PerEmail,
                            Description = null,
                            Images = null
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment" // One-time payment. Stripe supports recurring 'subscription' payments.
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return session.Id;
        }

        [HttpGet("success")]
        // Automatic query parameter handling from ASP.NET.
        public ActionResult CheckoutSuccess(string sessionId)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);

            // Here you can save order and customer details to your database.
            var total = session.AmountTotal.Value;
            var customerEmail = session.CustomerDetails.Email;

            return Redirect(s_wasmClientURL + "success");
        }
    }
}
