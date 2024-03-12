using API.Interfaces;
using API.Utilities;

namespace API.Classes
{
    public class ConfigReader
    {
        public static AppSettingsReader _appSettingsReader = new AppSettingsReader();
    }

    public sealed class BasicUserFee : ConfigReader
    {
        public static double Percentage = _appSettingsReader.GetValue<double>("BasicUserFee:Percentage");
        public static Range Common = new Range
        {
            Min = _appSettingsReader.GetValue<double>("BasicUserFee:commonMin"),
            Max = _appSettingsReader.GetValue<double>("BasicUserFee:commonMax")
        };
        public static Range Luxury = new Range
        {
            Min = _appSettingsReader.GetValue<double>("BasicUserFee:luxuryMin"),
            Max = _appSettingsReader.GetValue<double>("BasicUserFee:luxuryMax")
        };
    }

    public sealed class SpecialFee : ConfigReader
    {
        public static double Common = _appSettingsReader.GetValue<double>("SpecialFee:common");
        public static double Luxury = _appSettingsReader.GetValue<double>("SpecialFee:luxury");
    }

    public sealed class AssociationFee : ConfigReader
    {
        public static List<RangeWithFee> Ranges = _appSettingsReader.GetValues<RangeWithFee>("AssociationFee:Ranges");
    }

    public sealed class StorageFee : ConfigReader
    {
        public static double Fee = _appSettingsReader.GetValue<double>("StorageFee");
    }

}
