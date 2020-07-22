using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wsqm
{
    public class Wsq
    {
        private Encoder _encoder;
        private Decoder _decoder;

        public Wsq()
        {
            _encoder = new Encoder();
            _decoder = new Decoder();
        }

        public void Encode(string sourceFile, string destinationFile, string[] comments, double bitRate)
        {
            if (Path.GetExtension(destinationFile).ToUpper() != ".WSQ")
            {
                throw new ApplicationException("Error: FileDest extension no supported");
            }

            using (var bm = new Bitmap(sourceFile))
            using (var ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Png);

                var bitmap = new BitmapWrapper(ms.ToArray(), bm.Width, bm.Height, 500, 8, 1);
                var data = new DataOutput { RutaDestino = destinationFile };
                _encoder.encode(data, bitmap, bitRate, comments);
            }
        }

        public void Decode(string sourceFile, string destinationFile)
        {
            if (Path.GetExtension(sourceFile).ToUpper() != ".WSQ")
            {
                throw new ApplicationException("Error: FileSource extension no supported");
            }

            byte[] fileData;

            BitmapSource image;
            FileStream stream;
            FileStream fs;
            DataInput data;
            BitmapWithMetadata arch;
            byte[] datos;
            int rawStride;
            System.Windows.Media.PixelFormat pf;
            int tope;

            switch (Path.GetExtension(destinationFile).ToUpper())
            {
                case ".BMP":
                    fs = File.OpenRead(sourceFile);
                    fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, fileData.Length);

                    data = new DataInput(fileData);

                    arch = _decoder.decode(data);

                    pf = PixelFormats.Gray8;

                    rawStride = (arch.Width * pf.BitsPerPixel + 7) / 8;

                    datos = new byte[rawStride * arch.Height];

                    if (datos.Length > arch.Length)
                        tope = arch.Length;
                    else
                        tope = datos.Length;

                    for (int y = 0; y < tope; y++)
                    {
                        datos[y] = arch.Pixels[y];
                    }

                    image = BitmapSource.Create(
                            arch.Width,
                            arch.Height,
                            96,
                            96,
                            pf,
                            null,
                            datos,
                            rawStride);

                    stream = new FileStream(destinationFile, FileMode.Create);
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(stream);

                    stream.Dispose();
                    fs.Dispose();

                    break;

                case ".TIF":
                    fs = File.OpenRead(sourceFile);
                    fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, fileData.Length);

                    data = new DataInput(fileData);
                    arch = _decoder.decode(data);

                    pf = PixelFormats.Gray8;

                    rawStride = (arch.Width * pf.BitsPerPixel + 7) / 8;

                    datos = new byte[rawStride * arch.Height];

                    if (datos.Length > arch.Length)
                        tope = arch.Length;
                    else
                        tope = datos.Length;

                    for (int y = 0; y < tope; y++)
                    {
                        datos[y] = arch.Pixels[y];
                    }

                    // Creates a new empty image with the pre-defined palette

                    image = BitmapSource.Create(
                           arch.Width,
                           arch.Height,
                           96,
                           96,
                           pf,
                           null,
                           datos,
                           rawStride);

                    stream = new FileStream(destinationFile, FileMode.Create);
                    var encodert = new TiffBitmapEncoder();

                    encodert.Compression = TiffCompressOption.None;
                    encodert.Frames.Add(BitmapFrame.Create(image));
                    encodert.Save(stream);

                    stream.Dispose();
                    fs.Dispose();

                    break;

                default:
                    throw new ApplicationException("Error: FileDest extension no supported");
            }
        }

        private byte[] GetBytesFromBitmapSource(BitmapSource bmp)
        {
            int width = bmp.PixelWidth;
            int height = bmp.PixelHeight;
            int stride = width * ((bmp.Format.BitsPerPixel + 7) / 8);

            byte[] pixels = new byte[height * stride];

            bmp.CopyPixels(pixels, stride, 0);

            return pixels;
        }
    }
}