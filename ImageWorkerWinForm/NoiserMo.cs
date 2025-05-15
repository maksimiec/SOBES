//Realization of this class based on examples from https://thebookofshaders.com/11/?lan=ru 
using System;
using System.Drawing;
using System.Drawing.Imaging;

public class NoiserMo
{
    public struct Vector2
    {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }
        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
    }

    private float Random(Vector2 st, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        return (float)Math.Abs(Math.Sin(Vector2.Dot(st, new Vector2(r1, r2))) * r3);
    }

    public Bitmap ApplyMosaicEffect(Bitmap original, int cells = 10, float intensity = 0.5f, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        Bitmap result = new Bitmap(original.Width, original.Height);

        // Блокируем биты для быстрого доступа к пикселям
        BitmapData origData = original.LockBits(
            new Rectangle(0, 0, original.Width, original.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

        BitmapData resultData = result.LockBits(
            new Rectangle(0, 0, result.Width, result.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

        int bytesPerPixel = 4;
        byte[] origPixels = new byte[origData.Stride * original.Height];
        byte[] resultPixels = new byte[resultData.Stride * result.Height];
        System.Runtime.InteropServices.Marshal.Copy(origData.Scan0, origPixels, 0, origPixels.Length);

        float invIntensity = 1f - intensity; // Вес оригинального изображения

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                // Масштабируем координаты
                Vector2 st = new Vector2(
                    x / (float)original.Width * cells,
                    y / (float)original.Height * cells);

                // Определяем ячейку мозаики
                Vector2 ipos = new Vector2((float)Math.Floor(st.X), (float)Math.Floor(st.Y));
                float randomValue = Random(ipos, r1, r2, r3); // Шум для текущей ячейки

                int index = (y * resultData.Stride) + (x * bytesPerPixel);

                // Смешиваем оригинал и шум
                for (int c = 0; c < 3; c++) // RGB каналы
                {
                    float originalColor = origPixels[index + c] / 255f;
                    float mixed = originalColor * invIntensity + randomValue * intensity;
                    resultPixels[index + c] = (byte)(Math.Clamp(mixed, 0, 1) * 255);
                }
                resultPixels[index + 3] = origPixels[index + 3]; // Альфа-канал
            }
        }

        System.Runtime.InteropServices.Marshal.Copy(resultPixels, 0, resultData.Scan0, resultPixels.Length);
        original.UnlockBits(origData);
        result.UnlockBits(resultData);

        return result;
    }
}