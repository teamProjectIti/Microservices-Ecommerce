using Data.Entities.Discount;
using Discount.Grpc.Protos;
using Grpc.Core;
using Repositery.Interface.Discount.CouponInterf;

namespace Discount.Grpc.Services
{
    public class DiscountService: DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository<Coupon> _discountRepository;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IDiscountRepository<Coupon> discountRepository, ILogger<DiscountService> logger)
        {
            this._discountRepository = discountRepository;
            _logger = logger;
        }
        public override async Task<copounModel> GetDiscount(GetdiscountRequest request, ServerCallContext context)
        {
            var coupon = await _discountRepository.GetByNameAsync(request.ProductName);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount Is Empty{request.ProductName}"));

            var couponModel = _maper.map<copounModel>(coupon);

            return couponModel;
            //return base.GetDiscount(request, context);
        }

        public override async Task<copounModel> CreateDiscount(CreateCopoun request, ServerCallContext context)
        {
            var coupon = _mapper.map<Coupon>(request.Coupon);

            await _discountRepository.AddAsync(coupon);
            _logger.LogInformation("Discount Success Create ProductName", request.Coupon.ProductName);

            var couponModel = _maper.map<copounModel>(coupon);

            return couponModel;
        }

        public override async Task<copounModel> UpdateDiscount(UpdateCopoun request, ServerCallContext context)
        {
            var coupon = _mapper.map<Coupon>(request.Coupon);

            await _discountRepository.UpdateAsync(coupon);
            _logger.LogInformation("Discount Success Create ProductName", request.Coupon.ProductName);

            var couponModel = _maper.map<copounModel>(coupon);

            return couponModel;
        }
        public override async Task<DeleteCopoun> DeleteDiscount(DeleteCopounRequest request, ServerCallContext context)
        {
            var delete = await _discountRepository.DeleteAsync(request.ProductID);
            return new DeleteCopoun { Success = delete };
        }

    }
}
