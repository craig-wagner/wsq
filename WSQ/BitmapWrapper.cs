using System.Text;

namespace Wsqm
{
    internal class BitmapWrapper
    {
        public int Depth { get; }

        public int Height { get; }

        public int Length { get; }

        public int LossyFlag { get; }

        public byte[] Pixels { get; }

        public int Ppi { get; }

        public int Width { get; }

        public BitmapWrapper(byte[] pixels, int width, int height, int ppi, int depth, int lossyflag)
        {
            Pixels = pixels;
            Length = pixels != null ? pixels.Length : 0;
            Width = width;
            Height = height;
            Ppi = ppi;
            Depth = depth;
            LossyFlag = lossyflag;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Bitmap [");
            result.Append(Width);
            result.Append(" x "); result.Append(Height);
            result.Append(" x "); result.Append(Depth); result.Append(", ");
            result.Append("ppi = "); result.Append(Ppi); result.Append(", ");
            result.Append("lossy = "); result.Append(LossyFlag);
            result.Append("]");
            return result.ToString();
        }
    }
}