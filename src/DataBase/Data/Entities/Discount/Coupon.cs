using Data.Entities.BaseData;

namespace Data.Entities.Discount
{
    public class Coupon: BaseEntityPostGres
    {
         public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
