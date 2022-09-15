using System.Drawing.Imaging;

namespace DDSReader
{
    public class DDSImage
	{
		private readonly Pfim.IImage _image;

		public byte[] Data
		{
			get
			{
				if (_image != null)
					return _image.Data;
				else
					return new byte[0];
			}
		}

		public DDSImage(string file)
		{
			_image = Pfim.Pfimage.FromFile(file);
			Process();
		}

		public DDSImage(Stream stream)
		{
			if (stream == null)
				throw new Exception("DDSImage ctor: Stream is null");

			_image = Pfim.Dds.Create(stream, new Pfim.PfimConfig());
			Process();
		}

		public DDSImage(byte[] data)
		{
			if (data == null || data.Length <= 0)
				throw new Exception("DDSImage ctor: no data");

			_image = Pfim.Dds.Create(data, new Pfim.PfimConfig());
			Process();
		}

		private void Process()
		{
			if (_image == null)
				throw new Exception("DDSImage image creation failed");

			if (_image.Compressed)
				_image.Decompress();
		}

		private Bitmap CreateBitmap(int width, int height, byte[] rawData)
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height)
				, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			IntPtr scan = data.Scan0;
			int size = bitmap.Width * bitmap.Height * 4;

			unsafe
			{
				byte* p = (byte*)scan;
				for (int i = 0; i < size; i += 4)
				{
					// iterate through bytes.
					// Bitmap stores it's data in RGBA order.
					// DDS stores it's data in BGRA order.
					p[i] = rawData[i + 2]; // blue
					p[i + 1] = rawData[i + 1]; // green
					p[i + 2] = rawData[i];   // red
					p[i + 3] = rawData[i + 3]; // alpha
				}
			}

			bitmap.UnlockBits(data);
			return bitmap;
		}

		public Bitmap ToBitmap()
        {
			return CreateBitmap(_image.Width, _image.Height, _image.Data);
        }
	}
}
