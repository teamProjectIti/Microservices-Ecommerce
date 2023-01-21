using Data.Entities.Basket.order;
using Microsoft.Extensions.Caching.Distributed;
using Repositery.Interface.Basket;
using Newtonsoft.Json;
 
namespace Repositery.Implemint.Basket
{
    public class BasketRepositery : IBasketRepositery
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepositery(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _distributedCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> SetBasket(ShoppingCart basket)
        {
            await _distributedCache.SetStringAsync(basket._UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket._UserName);
        }
        public async Task DeleteBasket(string userName)
        {
            await _distributedCache.RemoveAsync(userName);
        }

    }
}
