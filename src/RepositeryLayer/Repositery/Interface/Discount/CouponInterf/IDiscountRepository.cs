using Data.Entities.Discount;

namespace Repositery.Interface.Discount.CouponInterf
{
    public interface IDiscountRepository<T> where T:class,new()
    {
        Task<Coupon> GetByIdAsync(int id);
        Task<Coupon> GetByNameAsync(string text);
        Task<Coupon> GetAllAsync();
        Task<Coupon> AddAsync(T entity);
        Task<Coupon> UpdateAsync(T entity);
        Task<Coupon> DeleteAsync(T entity);
        Task<bool> DeleteAsync(int Id);
    }
}
