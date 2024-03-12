namespace API.Classes
{
    public class Range
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }

    public class RangeWithFee : Range
    {
        public double Fee { get; set; }
    }
}
