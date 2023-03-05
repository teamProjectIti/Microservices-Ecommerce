using Dto.Common;

namespace Repositery.Interface.Discount.CouponInterf
{
    public interface IDiscountRepository<T> where T:class,new()
    {
        Task<AjexResult> GetByIdAsync(int id);
        Task<AjexResult> GetByNameAsync(string text);
        Task<AjexResult> GetAllAsync();
        Task<AjexResult> AddAsync(T entity);
        Task<AjexResult> UpdateAsync(T entity);
        Task<AjexResult> DeleteAsync(T entity);
        Task<bool> DeleteAsync(int Id);
    }
}
