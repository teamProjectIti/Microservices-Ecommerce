using Data.Entities.Basket.order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositery.Interface.Basket
{
    public interface IBasketRepositery
    {
        Task<ShoppingCart> GetBasket(string usrename);   
        Task<ShoppingCart> SetBasket(ShoppingCart model);   
        Task DeleteBasket(string usrename);   

    }
}
