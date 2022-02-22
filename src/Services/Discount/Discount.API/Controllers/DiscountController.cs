using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountReposotory _reposotory;

        public DiscountController(IDiscountReposotory reposotory)
        {
            _reposotory = reposotory;
        }
        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var discount = await _reposotory.GetDiscount(productName);
            return Ok(discount);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> CreateDiscount([FromBody] Coupon coupon)
        {
            await _reposotory.CreateDiscount(coupon);
            return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
        }
        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateDiscount([FromBody] Coupon coupon)
        {
            return Ok(await _reposotory.UpdateDiscount(coupon));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string productName)
        {
            return Ok(await _reposotory.DeleteDiscount(productName));
        }
    }
}
