using Discount.API.Entities;

namespace Discount.API.Repositories
{
    public interface IDiscountReposotory
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> DeleteDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);


    }
}
