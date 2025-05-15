//Realization of this class based on examples from https://thebookofshaders.com/11/?lan=ru 
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Drawing;
using System.Drawing.Imaging;

public class NoiserS
{
    public struct Vector2
    {
        public float X, Y;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
    }

    private float Random(Vector2 st, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        return (float)Math.Abs(Math.Sin(Vector2.Dot(st, new Vector2(r1, r2))) * r3);
    }

    public Bitmap ApplyRandomNoise(Bitmap original, float intensity = 0.4f, float r1 = 12.0f, float r2 = 78.0f, double r3 = 43758.0 % 1)
    {
        Bitmap noisyImage = new Bitmap(original.Width, original.Height);

        // Блокируем биты оригинального изображения для чтения
        BitmapData origData = original.LockBits(
            new Rectangle(0, 0, original.Width, original.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

        // Блокируем биты результирующего изображения для записи
        BitmapData noisyData = noisyImage.LockBits(
            new Rectangle(0, 0, noisyImage.Width, noisyImage.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format32bppArgb);

        int bytesPerPixel = 4;
        byte[] origPixels = new byte[origData.Stride * original.Height];
        byte[] noisyPixels = new byte[noisyData.Stride * noisyImage.Height];

        // Копируем данные оригинального изображения
        System.Runtime.InteropServices.Marshal.Copy(origData.Scan0, origPixels, 0, origPixels.Length);

        for (int y = 0; y < noisyImage.Height; y++)
        {
            for (int x = 0; x < noisyImage.Width; x++)
            {
                Vector2 st = new Vector2(
                    x / (float)noisyImage.Width,
                    y / (float)noisyImage.Height);

                // Генерируем случайное значение (0..1)
                float rnd = Random(st, r1, r2, r3);

                // Преобразуем в диапазон (-intensity/2 .. +intensity/2)
                float noiseValue = (rnd - 0.5f) * intensity;

                int index = (y * noisyData.Stride) + (x * bytesPerPixel);

                // Применяем шум к каждому цветовому каналу
                for (int c = 0; c < 3; c++) // RGB каналы
                {
                    float originalValue = origPixels[index + c] / 255f;
                    float noisyValue = originalValue + noiseValue;
                    noisyPixels[index + c] = (byte)(Math.Clamp(noisyValue, 0, 1) * 255);
                }
                noisyPixels[index + 3] = origPixels[index + 3]; // Сохраняем альфа-канал
            }
        }

        // Копируем результат обратно в Bitmap
        System.Runtime.InteropServices.Marshal.Copy(noisyPixels, 0, noisyData.Scan0, noisyPixels.Length);

        // Разблокируем биты
        original.UnlockBits(origData);
        noisyImage.UnlockBits(noisyData);

        return noisyImage;
    }
}