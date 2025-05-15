//Realization of this class based on examples from https://thebookofshaders.com/11/?lan=ru 
using System;
using System.Drawing;
using System.Drawing.Imaging;

public class NoiserT
{
    public struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.X * b.X, a.Y * b.Y);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.X * b, a.Y * b);
        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
    }

    private float Random(Vector2 st, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        return (float)Math.Abs(Math.Sin(Vector2.Dot(st, new Vector2(r1, r2))) * r3);
    }

    private float Noise(Vector2 st, float scale, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        st *= scale;
        Vector2 i = new Vector2((float)Math.Floor(st.X), (float)Math.Floor(st.Y));
        Vector2 f = new Vector2(st.X - i.X, st.Y - i.Y);

        float a = Random(i, r1, r2, r3);
        float b = Random(i + new Vector2(1.0f, 0.0f), r1, r2, r3);
        float c = Random(i + new Vector2(0.0f, 1.0f), r1, r2, r3);
        float d = Random(i + new Vector2(1.0f, 1.0f), r1, r2, r3);

        Vector2 u = f * f * (new Vector2(3.0f, 3.0f) - f * 2.0f);
        return Lerp(Lerp(a, b, u.X), Lerp(c, d, u.X), u.Y);
    }

    private float Lerp(float a, float b, float t) => a + (b - a) * t;

    public Bitmap ApplyPerlinNoise(Bitmap original, float scale = 6.0f, float intensity = 0.3f, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        Bitmap noisyImage = new Bitmap(original.Width, original.Height);

        using (Graphics g = Graphics.FromImage(noisyImage))
        {
            g.DrawImage(original, 0, 0);
        }

        BitmapData bmpData = noisyImage.LockBits(
            new Rectangle(0, 0, noisyImage.Width, noisyImage.Height),
            ImageLockMode.ReadWrite,
            noisyImage.PixelFormat);

        int bytesPerPixel = Bitmap.GetPixelFormatSize(noisyImage.PixelFormat) / 8;
        int byteCount = bmpData.Stride * noisyImage.Height;
        byte[] pixels = new byte[byteCount];
        IntPtr ptrFirstPixel = bmpData.Scan0;
        System.Runtime.InteropServices.Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

        for (int y = 0; y < noisyImage.Height; y++)
        {
            for (int x = 0; x < noisyImage.Width; x++)
            {
                int index = (y * bmpData.Stride) + (x * bytesPerPixel);

                Vector2 st = new Vector2(
                    x / (float)noisyImage.Width,
                    y / (float)noisyImage.Height);

                float noise = Noise(st, scale, r1, r2, r3);
                int noiseValue = (int)((noise - 0.5f) * 255 * intensity);

                for (int i = 0; i < 3; i++) // Для RGB каналов
                {
                    int newValue = pixels[index + i] + noiseValue;
                    pixels[index + i] = (byte)Math.Clamp(newValue, 0, 255);
                }
            }
        }

        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
        noisyImage.UnlockBits(bmpData);

        return noisyImage;
    }

    public void SaveImageWithNoise(string inputPath, string outputPath, float scale = 5.0f, float intensity = 0.3f)
    {
        using (Bitmap original = new Bitmap(inputPath))
        using (Bitmap noisyImage = ApplyPerlinNoise(original, scale, intensity))
        {
            noisyImage.Save(outputPath, ImageFormat.Png);
        }
    }
}