namespace API.Classes
{
    public class ApiResult
    {
        public double VehiclePrice { get; set; }
        public double BasicUserFee { get; set; }
        public double SpecialFee { get; set; }
        public double AssociationFee { get; set; }
        public double StorageFee { get; set; }
        public double TotalPrice { get; set; }

        public ApiResult() { }
        public ApiResult(double vehiclePrice, double basicUserFee, double specialFee, double associationFee, double storageFee)
        {
            VehiclePrice = Math.Round(vehiclePrice, 2);
            BasicUserFee = Math.Round(basicUserFee, 2);
            SpecialFee = Math.Round(specialFee, 2);
            AssociationFee = Math.Round(associationFee, 2);
            StorageFee = Math.Round(storageFee, 2);
            TotalPrice = Math.Round(vehiclePrice + basicUserFee + specialFee + associationFee + storageFee, 2);
        }
    }
}
