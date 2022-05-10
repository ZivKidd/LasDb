namespace LasDb
{
    public struct LasPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ushort Intensity { get; set; }
        public double X2D { get; set; }
        public double Y2D { get; set; }
    }
}