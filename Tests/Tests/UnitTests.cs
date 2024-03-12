using API.Enum;
using API.Services;
using API.Interfaces;
using Tests.Data;

namespace Tests.Tests
{
    public class UnitTests
    {
        private readonly IVehicleAuctionService _test = new VehicleAuctionService();

        public static IEnumerable<object[]> testVehicles()
        {
            yield return new[] { new TestVehicle(398, VehicleType.Common, 39.8, 7.68, 5, 550.76), };
            yield return new[] { new TestVehicle(501, VehicleType.Common, 50, 10.02, 10, 671.02), };
            yield return new[] { new TestVehicle(57, VehicleType.Common, 10, 1.14, 5, 173.14), };
            yield return new[] { new TestVehicle(1800, VehicleType.Luxury, 180, 72, 15, 2167), };
            yield return new[] { new TestVehicle(1100, VehicleType.Common, 50, 22, 15, 1287), };
            yield return new[] { new TestVehicle(1000000, VehicleType.Luxury, 200, 40000, 20, 1040320), };
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void CheckBasicUserFee(TestVehicle testVehicle)
        {
            var result = _test.CalculateFinalPrice(testVehicle.VehiclePrice, testVehicle.VehicleType);
            Assert.Equal(testVehicle.ExpectedBasicFee, result.BasicUserFee, 2);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void CheckSpecialFee(TestVehicle testVehicle)
        {
            var result = _test.CalculateFinalPrice(testVehicle.VehiclePrice, testVehicle.VehicleType);
            Assert.Equal(testVehicle.ExpectedSpecialFee, result.SpecialFee, 2);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void CheckAssociationFee(TestVehicle testVehicle)
        {
            var result = _test.CalculateFinalPrice(testVehicle.VehiclePrice, testVehicle.VehicleType);
            Assert.Equal(testVehicle.ExpectedAssociationFee, result.AssociationFee, 2);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void CheckTotalPrice(TestVehicle testVehicle)
        {
            var result = _test.CalculateFinalPrice(testVehicle.VehiclePrice, testVehicle.VehicleType);
            Assert.Equal(testVehicle.ExpectedTotalPrice, result.TotalPrice, 2);
        }
    }
}