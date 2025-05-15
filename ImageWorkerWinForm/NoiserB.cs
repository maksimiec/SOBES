//Realization of this class based on examples from https://thebookofshaders.com/11/?lan=ru 

using System;
using System.Drawing;
using System.Drawing.Imaging;

public class NoiserB
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
        public static Vector2 operator *(float a, Vector2 b) => new Vector2(a * b.X, a * b.Y);
        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
    }

    private float Random(Vector2 st, float r1 = 12.9898f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {

        return (float)(Math.Abs(Math.Sin(Vector2.Dot(st, new Vector2(r1, r2))) * r3)); //12.9898f 
    }

    private float Noise(Vector2 st, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        Vector2 i = new Vector2((float)Math.Floor(st.X), (float)Math.Floor(st.Y));
        Vector2 f = new Vector2(st.X - i.X, st.Y - i.Y);

        float a = Random(i, r1, r2, r3);
        float b = Random(i + new Vector2(1.0f, 0.0f), r1, r2, r3);
        float c = Random(i + new Vector2(0.0f, 1.0f), r1, r2, r3);
        float d = Random(i + new Vector2(1.0f, 1.0f), r1, r2, r3);

        Vector2 u = f * f * (new Vector2(3.0f, 3.0f) - (f * 2.0f));

        return MathHelper.Lerp(
            MathHelper.Lerp(a, b, u.X),
            MathHelper.Lerp(c, d, u.X),
            u.Y);
    }

    private const int OCTAVES = 6;

    private float Fbm(Vector2 st, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        float value = 0.1f;
        float amplitude = 0.35f;

        for (int i = 0; i < OCTAVES; i++)
        {
            value += amplitude * Noise(st, r1, r2, r3);
            st *= 2.0f;
            amplitude *= 0.5f;
        }

        return value;
    }

    public Bitmap ApplyFbmNoise(Bitmap original, float noiseScale = 4.0f, float intensity = 0.4f, bool stretchToWidth = true, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        Bitmap noisyImage = new Bitmap(original.Width, original.Height);

        BitmapData origData = original.LockBits(
            new Rectangle(0, 0, original.Width, original.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

        BitmapData noisyData = noisyImage.LockBits(
            new Rectangle(0, 0, noisyImage.Width, noisyImage.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

        int bytesPerPixel = 4;
        byte[] origPixels = new byte[origData.Stride * original.Height];
        byte[] noisyPixels = new byte[noisyData.Stride * noisyImage.Height];

        System.Runtime.InteropServices.Marshal.Copy(origData.Scan0, origPixels, 0, origPixels.Length);

        for (int y = 0; y < noisyImage.Height; y++)
        {
            for (int x = 0; x < noisyImage.Width; x++)
            {
                Vector2 st = new Vector2(
                    x / (float)noisyImage.Width,
                    y / (float)noisyImage.Height);

                if (stretchToWidth)
                    st.X *= noisyImage.Width / (float)noisyImage.Height;

                float noiseValue = Fbm(st * noiseScale, r1, r2, r3);
                float noiseFactor = (noiseValue - 0.5f) * intensity; // [-0.5*intensity, 0.5*intensity]

                int index = (y * noisyData.Stride) + (x * bytesPerPixel);

                for (int c = 0; c < 3; c++) // RGB каналы
                {
                    float originalValue = origPixels[index + c] / 255f;
                    float noisyValue = originalValue + noiseFactor;
                    noisyPixels[index + c] = (byte)(Math.Clamp(noisyValue, 0, 1) * 255);
                }
                noisyPixels[index + 3] = 255; // Alpha канал
            }
        }

        System.Runtime.InteropServices.Marshal.Copy(noisyPixels, 0, noisyData.Scan0, noisyPixels.Length);
        original.UnlockBits(origData);
        noisyImage.UnlockBits(noisyData);

        return noisyImage;
    }
}

public static class MathHelper
{
    public static float Lerp(float a, float b, float t) => a + (b - a) * t;
}