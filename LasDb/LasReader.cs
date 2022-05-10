namespace LasDb
{
    public class LasReader : IDisposable
    {
        public LasPoint CurrentPoint { get; private set; }

        private int currentPointIndex = 0;

        public bool MoveToNextPoint()
        {
            this.currentPointIndex++;
            if (this.currentPointIndex > this.NumberOfPoints)
            {
                return false;
            }
            double x = this._binaryReader.ReadInt32() * this.XScale + this.XOffset;
            double y = this._binaryReader.ReadInt32() * this.YScale + this.YOffset;
            double z = this._binaryReader.ReadInt32() * this.ZScale + this.ZOffset;
            ushort i = this._binaryReader.ReadUInt16();
            this._binaryReader.ReadBytes(this.PointDataRecordLength - 4 * 3 - 2);
            this.CurrentPoint = new LasPoint() { Intensity = i, X = x, Y = y, Z = z };

            return true;
        }

        public void Close()
        {
            this._binaryReader.Close();
        }

        public uint OffsetToPointData { get; }
        public ushort PointDataRecordLength { get; }
        public uint NumberOfPoints { get; }

        public byte VersionMajor { get; }
        public byte VersionMinor { get; }


        public double XScale { get; }
        public double YScale { get; }
        public double ZScale { get; }

        public double XOffset { get; }
        public double YOffset { get; }
        public double ZOffset { get; }

        public double MaxX { get; }
        public double MinX { get; }
        public double MaxY { get; }
        public double MinY { get; }
        public double MaxZ { get; }
        public double MinZ { get; }

        private BinaryReader _binaryReader;

        public LasReader(string lasFilePath)
        {
            this._binaryReader = new BinaryReader(File.OpenRead(lasFilePath));
            this._binaryReader.ReadBytes(8);//SEEK到Guid1位置
            var guidData1 = this._binaryReader.ReadUInt32();
            var guidData2 = this._binaryReader.ReadUInt16();//存储每个测线的点数
            var guidData3 = this._binaryReader.ReadUInt16();
            var guidData4 = this._binaryReader.ReadChars(8);
            this.VersionMajor = this._binaryReader.ReadByte();
            this.VersionMinor = this._binaryReader.ReadByte();
            var systemIdentifier = this._binaryReader.ReadChars(32);
            var generatingSoftware = this._binaryReader.ReadChars(32);
            var fileCreationDayOfYear = this._binaryReader.ReadUInt16();
            var fileCreationYear = this._binaryReader.ReadUInt16();
            var headerSize = this._binaryReader.ReadUInt16();
            this.OffsetToPointData = this._binaryReader.ReadUInt32();
            var numberOfVariable = this._binaryReader.ReadUInt32();
            var pointDataFormat = this._binaryReader.ReadByte();
            this.PointDataRecordLength = this._binaryReader.ReadUInt16();
            this.NumberOfPoints = this._binaryReader.ReadUInt32();
            var numberOfReturn = this._binaryReader.ReadBytes(20);
            this.XScale = this._binaryReader.ReadDouble();
            this.YScale = this._binaryReader.ReadDouble();
            this.ZScale = this._binaryReader.ReadDouble();
            this.XOffset = this._binaryReader.ReadDouble();
            this.YOffset = this._binaryReader.ReadDouble();
            this.ZOffset = this._binaryReader.ReadDouble();
            this.MaxX = this._binaryReader.ReadDouble();
            this.MinX = this._binaryReader.ReadDouble();
            this.MaxY = this._binaryReader.ReadDouble();
            this.MinY = this._binaryReader.ReadDouble();
            this.MaxZ = this._binaryReader.ReadDouble();
            this.MinZ = this._binaryReader.ReadDouble();

            this._binaryReader.BaseStream.Seek(this.OffsetToPointData, 0);
        }

        public void Dispose()
        {
            this._binaryReader?.Dispose();
        }
    }
}