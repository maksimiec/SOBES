
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace ImageWorkerWinForm
{ 
    public class Noiser
    {
        public static Bitmap ApplyPerlinNoise(Bitmap inputImage, int seed, float frequency, int octaves) // int seed = 1337, float frequency = 0.05f, int octaves = 3
        {
            Random rand = new Random(seed);
            int width = inputImage.Width;
            int height = inputImage.Height;
            Bitmap outputImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float noiseValue = GeneratePerlinNoise(x, y, width, height, seed, frequency, octaves);
                    Color originalColor = inputImage.GetPixel(x, y);

                    // Modify the brightness based on the noise value
                    int r = Clamp((int)(originalColor.R * noiseValue));
                    int g = Clamp((int)(originalColor.G * noiseValue));
                    int b = Clamp((int)(originalColor.B * noiseValue));

                    Color newColor = Color.FromArgb(r, g, b);
                    outputImage.SetPixel(x, y, newColor);
                }
            }

            return outputImage;
        }

        private static float GeneratePerlinNoise(int x, int y, int width, int height, int seed, float frequency, int octaves)
        {
            float total = 0;
            float amplitude = 1.0f;
            float freq = frequency;

            for (int i = 0; i < octaves; i++)
            {
                float value = SmoothNoise(x * freq, y * freq, seed) * amplitude;
                total += value;
                amplitude *= 0.5f;
                freq *= 2;
            }

            return total;
        }

        private static float SmoothNoise(float x, float y, int seed)
        {
            int intX = (int)x;
            int intY = (int)y;
            float fracX = x - intX;
            float fracY = y - intY;

            float v1 = Interpolate(Noise(intX - 1, intY - 1, seed), Noise(intX + 1, intY - 1, seed), fracX);
            float v2 = Interpolate(Noise(intX - 1, intY + 1, seed), Noise(intX + 1, intY + 1, seed), fracX);

            return Interpolate(v1, v2, fracY);
        }

        private static float Interpolate(float a, float b, float x)
        {
            float ft = x * 2.1415927f;
            float f = (1.0f - (float)Math.Cos(ft)) * 0.5f;
            return a * (1.0f - f) + b * f;
        }

        private static float Noise(int x, int y, int seed)
        {
            Random rand = new Random(x + y + seed);
            return (float)rand.NextDouble() * 2 - 1;
        }

        private static int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
        //===========================================================================================================================
        //===========================================================================================================================
        public static Bitmap ApplyFractalBrownianNoise(Bitmap inputImage, int seed, float frequency, int octaves, float lacunarity, float gain) // int seed = 1337, float frequency = 0.05f, int octaves = 6, float lacunarity = 2.0f, float gain = 0.5f
        {
            Random rand = new Random(seed);
            int width = inputImage.Width;
            int height = inputImage.Height;
            Bitmap outputImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float noiseValue = GenerateFractalBrownianNoise(x, y, width, height, seed, frequency, octaves, lacunarity, gain);
                    Color originalColor = inputImage.GetPixel(x, y);

                    // Modify the brightness based on the noise value
                    int r = Clamp((int)(originalColor.R * noiseValue));
                    int g = Clamp((int)(originalColor.G * noiseValue));
                    int b = Clamp((int)(originalColor.B * noiseValue));

                    Color newColor = Color.FromArgb(r, g, b);
                    outputImage.SetPixel(x, y, newColor);
                }
            }

            return outputImage;
        }

        private static float GenerateFractalBrownianNoise(int x, int y, int width, int height, int seed, float frequency, int octaves, float lacunarity, float gain)
        {
            float amplitude = 1.0f;
            float total = 0.0f;
            float freq = frequency;

            for (int i = 0; i < octaves; i++)
            {
                total += SmoothNoise(x * freq, y * freq, seed) * amplitude;
                amplitude *= gain;
                freq *= lacunarity;
            }

            return total;
        }

        //====================================================================================================
        //====================================================================================================
        public static Bitmap ApplySimplexNoise(Bitmap inputImage, int seed, float frequency, int octaves) //int seed = 1337, float frequency = 0.05f, int octaves = 3
        {
            int width = inputImage.Width;
            int height = inputImage.Height;
            Bitmap outputImage = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float noiseValue = GenerateSimplexNoise(x, y, width, height, seed, frequency, octaves);
                    Color originalColor = inputImage.GetPixel(x, y);

                    // Modify the brightness based on the noise value
                    int r = Clamp((int)(originalColor.R * noiseValue));
                    int g = Clamp((int)(originalColor.G * noiseValue));
                    int b = Clamp((int)(originalColor.B * noiseValue));

                    Color newColor = Color.FromArgb(r, g, b);
                    outputImage.SetPixel(x, y, newColor);
                }
            }

            return outputImage;
        }

        private static float GenerateSimplexNoise(int x, int y, int width, int height, int seed, float frequency, int octaves)
        {
            float total = 0;
            float amplitude = 1.0f;
            float maxValue = 0;
            float freq = frequency;

            for (int i = 0; i < octaves; i++)
            {
                float value = SimplexNoise(x * freq, y * freq, seed) * amplitude;
                total += value;
                maxValue += amplitude;
                amplitude *= 0.5f;
                freq *= 2;
            }

            return total / maxValue;
        }
        private static float GeneratePerlinNoiseF(float x, float y, int width, int height, int seed, float frequency, int octaves)
        {
            float total = 0;
            float amplitude = 1.0f;
            float freq = frequency;

            for (int i = 0; i < octaves; i++)
            {
                float value = SmoothNoise(x * freq, y * freq, seed) * amplitude;
                total += value;
                amplitude *= 0.5f;
                freq *= 2;
            }

            return total;
        }
        private static float SimplexNoise(float x, float y, int seed)
        {

            return GeneratePerlinNoiseF(x, y, 1, 1, seed, 1.0f, 1);
        }

        //======================================================================
        //======================================================================
        public static Bitmap ApplyPerlinNoise(Bitmap image, int scale)
        {
            // Реализация перлин-шума (упрощенная версия)
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            Random rand = new Random();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int noise = (rand.Next(256) % scale);
                    Color pixelColor = image.GetPixel(x, y);
                    int newR = Math.Min(255, pixelColor.R + noise);
                    int newG = Math.Min(255, pixelColor.G + noise);
                    int newB = Math.Min(255, pixelColor.B + noise);
                    newImage.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }
            return newImage;
        }
        //=========================================================================
        //=========================================================================

        public static Bitmap ApplyWaterRippleEffect(Bitmap image, int amplitudeX, int amplitudeY)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int newX = x + (int)(amplitudeX * Math.Sin(2 * Math.PI * (y / 200.0)));
                    int newY = y + (int)(amplitudeY * Math.Sin(2 * Math.PI * (x / 200.0)));

                    if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                    {
                        newImage.SetPixel(x, y, image.GetPixel(newX, newY));
                    }
                }
            }
            return newImage;
        }

        //==============================================================================
        //==============================================================================

        public static Bitmap ApplyWaveEffect(Bitmap image, int horizontalAmplitude, int verticalAmplitude)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int newX = x + (int)(horizontalAmplitude * Math.Sin(2 * Math.PI * y / 100));
                    int newY = y + (int)(verticalAmplitude * Math.Sin(2 * Math.PI * x / 100));

                    if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                    {
                        newImage.SetPixel(x, y, image.GetPixel(newX, newY));
                    }
                }
            }
            return newImage;
        }
        //================================================================================
        //================================================================================

        //===============================================================================
        //===============================================================================

    }
}
