using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories
{
    public class DiscountReposotory : IDiscountReposotory
    {
        private readonly IConfiguration _configuration;

        public DiscountReposotory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("Select * from Coupon Where ProductName=@ProductName",new { productName });
            if (coupon == null)
                return new Coupon { ProductName="No Discount",Amount=0,Description="No Discount Dessc"};
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
           var affected= await connection.ExecuteAsync
                ("Insert into coupon (productname,description,amount) Values(@productname,@description,@amount)",
                new { productName = coupon.ProductName,description=coupon.Description,amount=coupon.Amount });
            if (affected == 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync
                 ("Update coupon set productname=@productname,description=@description,amount=@amount where id=@id",
                 new { productName = coupon.ProductName, description = coupon.Description, amount = coupon.Amount ,id=coupon.Id});
            if (affected == 0)
                return false;
            return true;
        }
        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync
                 ("delete coupon where productname=@productname",
                 new { productName = productName});
            if (affected == 0)
                return false;
            return true;
        }
    }
}
