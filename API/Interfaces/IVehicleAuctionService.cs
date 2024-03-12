using API.Enum;
using API.Classes;

namespace API.Interfaces
{
    public interface IVehicleAuctionService
    {
        public ApiResult CalculateFinalPrice(double price, VehicleType type);
    }
}
