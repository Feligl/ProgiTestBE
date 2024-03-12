using API.Enum;
using API.Classes;
using API.Interfaces;

namespace API.Services
{
    public class VehicleAuctionService : IVehicleAuctionService
    {
        public ApiResult CalculateFinalPrice(double vehiclePrice, VehicleType vehicleType)
        {
            var result = new ApiResult(
                vehiclePrice: vehiclePrice,
                basicUserFee: CalculateBasicUserFee(vehiclePrice, vehicleType),
                specialFee: CalculateSpecialFee(vehiclePrice, vehicleType),
                associationFee: CalculateAssociationFee(vehiclePrice, vehicleType),
                storageFee: CalculateStorageFee(vehiclePrice, vehicleType)
                );

            return result;
        }

        private double CalculateBasicUserFee(double vehiclePrice, VehicleType vehicleType)
        {
            var result = vehiclePrice * (BasicUserFee.Percentage / 100);

            if (vehicleType == VehicleType.Common)
            {
                if (result > BasicUserFee.Common.Max)
                    result = BasicUserFee.Common.Max;

                if (result < BasicUserFee.Common.Min)
                    result = BasicUserFee.Common.Min;
            }

            if (vehicleType == VehicleType.Luxury)
            {
                if (result > BasicUserFee.Luxury.Max)
                    result = BasicUserFee.Luxury.Max;

                if (result < BasicUserFee.Luxury.Min)
                    result = BasicUserFee.Luxury.Min;
            }

            return result;
        }

        private double CalculateSpecialFee(double vehiclePrice, VehicleType vehicleType)
        {
            double rate = 0;

            if (vehicleType == VehicleType.Common)
                rate = SpecialFee.Common;

            if (vehicleType == VehicleType.Luxury)
                rate = SpecialFee.Luxury;

            var result = vehiclePrice * (rate / 100);

            return result;
        }

        private double CalculateAssociationFee(double vehiclePrice, VehicleType vehicleType)
        {
            var x = AssociationFee.Ranges;
            double result = 0;

            foreach (var y in x)
            {
                if (vehiclePrice > y.Min && vehiclePrice <= y.Max || y.Max == 0)
                {
                    result = y.Fee;
                    break;
                }

                if (y.Max > vehiclePrice)
                {
                    continue;
                }
            }

            return result;
        }

        private double CalculateStorageFee(double vehiclePrice, VehicleType vehicleType)
        {
            return StorageFee.Fee;
        }
    }
}
