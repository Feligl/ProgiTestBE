using API.Enum;
using System.Collections;

namespace Tests.Data
{
    public class TestVehicle
    {
        public double VehiclePrice { get; set; }
        public VehicleType VehicleType { get; set; }
        public double ExpectedBasicFee { get; set; }
        public double ExpectedSpecialFee { get; set; }
        public double ExpectedAssociationFee { get; set; }
        public double ExpectedTotalPrice { get; set; }

        public TestVehicle(double vehiclePrice, VehicleType vehicleType, double expectedBasicFee,
                           double expectedSpecialFee, double expectedAssociationFee, double expectedTotalPrice)
        {
            VehiclePrice = vehiclePrice;
            VehicleType = vehicleType;
            ExpectedBasicFee = expectedBasicFee;
            ExpectedSpecialFee = expectedSpecialFee;
            ExpectedAssociationFee = expectedAssociationFee;
            ExpectedTotalPrice = expectedTotalPrice;
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[] { new TestVehicle(398, VehicleType.Common, 39.8, 7.96, 5, 550.76), };
            yield return new[] { new TestVehicle(501, VehicleType.Common, 50, 10.02, 10, 671.02), };
            yield return new[] { new TestVehicle(57, VehicleType.Common, 10, 1.14, 5, 173.14), };
            yield return new[] { new TestVehicle(1800, VehicleType.Luxury, 180, 72, 15, 2167), };
            yield return new[] { new TestVehicle(1100, VehicleType.Common, 50, 22, 15, 1287), };
            yield return new[] { new TestVehicle(1000000, VehicleType.Luxury, 200, 40000, 20, 1040320), };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
