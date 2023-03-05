using Dapper;
using Data.Entities.BaseData;
using Data.Entities.Discount;
using Dto.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Repositery.Interface.Discount.CouponInterf;

namespace Repositery.Implemint.Discount.CouponRepo
{
    public  class DiscountRepository<T> : IDiscountRepository<T> where T : BaseEntityPostGres,new()
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<AjexResult> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public async Task<AjexResult> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AjexResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AjexResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AjexResult> GetByNameAsync(string text)
        {
            var res = new AjexResult();
            using var connection = new NpgsqlConnection
                (_configuration.GetConnectionString("ConnectionString"));

            var coupondb = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("select * from coupon where productname=@text", new { ProductName = text });

            if (coupondb is null)
                res.AddParameter("Result", "Not Fount Any Discount");

            res.AddParameter("Coupon", coupondb);

            return res;
        }

        public async Task<AjexResult> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}