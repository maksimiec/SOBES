//using Aspose.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
//using static System.Net.Mime.MediaTypeNames;
using SixLabors.Fonts;
using System.Numerics;
using SixLabors.ImageSharp.Processing;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageTransformationApp
{


    public static class ImageProcessor
    {
        // Преобразование изображения в черно-белое
        public static Image<Rgba32> ConvertToGrayscale(Image<Rgba32> original)
        {
            var grayImage = original.Clone(context => context.Grayscale());
            return grayImage;
        }

        // Преобразование изображения в очертания
        public static Image<Rgba32> ApplyEdgeDetection(Image<Rgba32> original)
        {
            var edgeImage = original.Clone(context => context.DetectEdges(KnownEdgeDetectorKernels.Sobel));
            return edgeImage;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        //   public static Image<Rgba32> ApplyRainEffect(Image<Rgba32> original)
        // {
        //        var rainImage = original.Clone();
        //          Random rnd = new Random();
        //
        //// Создание случайных "капель" на изображении (изменение яркости случайных пикселей)
        //rainImage.Mutate(context =>
        //{
        //    for (int i = 0; i < original.Width * original.Height / 100; i++)
        //    {
        //        int x = rnd.Next(original.Width);
        //        int y = rnd.Next(original.Height);
        //        var randomColor = new Rgba32((byte)rnd.Next(150, 255), (byte)rnd.Next(150, 255), (byte)rnd.Next(150, 255), 200);
        //        context.Fill(randomColor, new SixLabors.ImageSharp.Drawing.Path(new SixLabors.ImageSharp.Drawing.Shapes.EllipsePolygon(x, y, 2)));  // Рисуем небольшие "капли"
        //    }
        //});
        ////
        //      return rainImage;
        //     }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------\

        public static Image<Rgba32> ApplyFogEffect(Image<Rgba32> original)
        {
            var fogImage = original.Clone();
            Random rnd = new Random();
            fogImage.Mutate(context =>
            {
                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        var originalColor = original[x, y];
                        int fog = rnd.Next(0, 45);
                        var newColor = new Rgba32(
                            Math.Min(255, originalColor.R + fog),
                            Math.Min(255, originalColor.G + fog),
                            Math.Min(255, originalColor.B + fog),
                            originalColor.A);
                        fogImage[x, y] = newColor;
                    }
                }
            });
            return fogImage;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //
        //    public static Image<Rgba32> ApllyBlurEffect(Image<Rgba32> original)
        //       {
        //      var BlurImage = original.Clone();
        /////
        //
        //      return BlurImage;
        // }
        // Изменение резкости
        //public static Image<Rgba32> ApplySharpenEffect(Image<Rgba32> original)
        //{
        //    var sharpenImage = original.Clone(context => context.Sharpen());  // Можно передать радиус, например, Sharpen(1.0f)
        //    return sharpenImage;
        //}

    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------------------

    public static class NoiseProcessor
    {
        // Метод для добавления шума
        public static Image<Rgba32> AddNoise(Image<Rgba32> original, float noiseAmount = 0.2f, int intensity = 30)
        {
            var noisyImage = original.Clone();
            Random rnd = new Random();

            noisyImage.Mutate(context =>
            {
                for (int y = 0; y < noisyImage.Height; y++)
                {
                    for (int x = 0; x < noisyImage.Width; x++)
                    {
                        // Применяем шум только к некоторым пикселям на основе вероятности
                        if (rnd.NextDouble() < noiseAmount)
                        {
                            // Получаем текущий цвет пикселя
                            var pixel = noisyImage[x, y];

                            // Генерируем случайное смещение яркости для каждого цветового канала
                            int rOffset = rnd.Next(-intensity, intensity);
                            int gOffset = rnd.Next(-intensity, intensity);
                            int bOffset = rnd.Next(-intensity, intensity);

                            // Изменяем цвет пикселя, добавляя шум (контролируемый интенсивностью)
                            var noisyPixel = new Rgba32(
                                Clamp(pixel.R + rOffset),
                                Clamp(pixel.G + gOffset),
                                Clamp(pixel.B + bOffset),
                                pixel.A);  // Прозрачность остаётся неизменной

                            noisyImage[x, y] = noisyPixel;
                        }
                    }
                }
            });

            return noisyImage;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class NegativeProcessor
        {
            // Метод для преобразования изображения в негатив
            public static Image<Rgba32> ApplyNegative(Image<Rgba32> original)
            {
                var negativeImage = original.Clone();

                negativeImage.Mutate(context =>
                {
                    for (int y = 0; y < negativeImage.Height; y++)
                    {
                        for (int x = 0; x < negativeImage.Width; x++)
                        {
                            // Получаем текущий цвет пикселя
                            var pixel = negativeImage[x, y];

                            // Инвертируем цветовые каналы (R, G, B)
                            var negativePixel = new Rgba32(
                                (byte)(255 - pixel.R),
                                (byte)(255 - pixel.G),
                                (byte)(255 - pixel.B),
                                pixel.A);  // Прозрачность остаётся неизменной

                            // Записываем изменённый пиксель обратно в изображение
                            negativeImage[x, y] = negativePixel;
                        }
                    }
                });

                return negativeImage;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class Rotator
        {
            public static Image<Rgba32> ApllyRotation(Image<Rgba32> original, int r)
            {
                var rotImage = original.Clone();


                rotImage.Mutate(img => img.Transform(new AffineTransformBuilder()
                    .AppendRotationDegrees(r)
                ));

                return rotImage;

            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        public static class TiltProcessor
        {
            // Метод для наклона изображения
            public static Image<Rgba32> ApplyTilt(Image<Rgba32> original, float skewAngleX = 10, float skewAngleY = 0)
            {
                var tiltedImage = original.Clone();

                // Применяем наклон (Skew) к изображению
                tiltedImage.Mutate(context => context.Skew(skewAngleX, skewAngleY));

                return tiltedImage;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------


        public static class ColorShiftProcessor
        {
            // Метод для цветового сдвига
            public static Image<Rgba32> ApplyColorShift(Image<Rgba32> original, int redShift, int greenShift, int blueShift)
            {
                var shiftedImage = original.Clone();

                shiftedImage.Mutate(context =>
                {
                    for (int y = 0; y < shiftedImage.Height; y++)
                    {
                        for (int x = 0; x < shiftedImage.Width; x++)
                        {
                            var pixel = shiftedImage[x, y];

                            // Сдвигаем цветовые каналы R, G, B
                            var shiftedPixel = new Rgba32(
                                Clamp(pixel.R + redShift),
                                Clamp(pixel.G + greenShift),
                                Clamp(pixel.B + blueShift),
                                pixel.A); // Прозрачность остаётся неизменной

                            shiftedImage[x, y] = shiftedPixel;
                        }
                    }
                });

                return shiftedImage;
            }

            // Метод для корректировки значения цвета в пределах [0, 255]
            private static byte Clamp(int value)
            {
                return (byte)Math.Max(0, Math.Min(255, value));
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class ImageAdjustmentsProcessor
        {
            public static Image<Rgba32> AdjustBGK(Image<Rgba32> original, float brightnessFactor, float gammaFactor, float contrastFactor)
            {
                var adjustedImage = original.Clone();
                float inverseGamma = 1.0f / gammaFactor;
                // Применяем изменение яркости
                adjustedImage.Mutate(context => context.Brightness(brightnessFactor));
                adjustedImage.Mutate(context =>
                {
                    for (int y = 0; y < adjustedImage.Height; y++)
                    {
                        for (int x = 0; x < adjustedImage.Width; x++)
                        {
                            var pixel = adjustedImage[x, y];

                            // Применяем коррекцию гаммы для каждого цветового канала
                            byte correctedRed = (byte)(Math.Pow(pixel.R / 255.0, inverseGamma) * 255);
                            byte correctedGreen = (byte)(Math.Pow(pixel.G / 255.0, inverseGamma) * 255);
                            byte correctedBlue = (byte)(Math.Pow(pixel.B / 255.0, inverseGamma) * 255);

                            adjustedImage[x, y] = new Rgba32(correctedRed, correctedGreen, correctedBlue, pixel.A);
                        }
                    }
                });
                adjustedImage.Mutate(context => context.Contrast(contrastFactor));
                return adjustedImage;
            }


        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class ColorIntensityReducer
        {
            public static Image<Rgba32> ReduceCI(Image<Rgba32> original, string colorChannel, float intensityFactor)
            {
                if (intensityFactor < 0 || intensityFactor > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(intensityFactor), "Коэффициент интенсивности должен быть в диапазоне от 0 до 1.");
                }

                var adjustedImage = original.Clone();

                adjustedImage.Mutate(context =>
                {
                    for (int y = 0; y < adjustedImage.Height; y++)
                    {
                        for (int x = 0; x < adjustedImage.Width; x++)
                        {
                            var pixel = adjustedImage[x, y];

                            switch (colorChannel.ToLower())
                            {
                                case "red":
                                    pixel.R = (byte)(pixel.R * intensityFactor);
                                    break;

                                case "green":
                                    pixel.G = (byte)(pixel.G * intensityFactor);
                                    break;

                                case "blue":
                                    pixel.B = (byte)(pixel.B * intensityFactor);
                                    break;

                                default:
                                    throw new ArgumentException("Неправильный цветовой канал. Допустимые значения: 'red', 'green', 'blue'.");
                            }

                            adjustedImage[x, y] = pixel;
                        }
                    }
                });

                return adjustedImage;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class ImageMirrorProcessor
        {

            public static Image<Rgba32> MirrorH(Image<Rgba32> original)
            {
                var mirroredImage = original.Clone();
                mirroredImage.Mutate(context => context.Flip(FlipMode.Horizontal));
                return mirroredImage;
            }


            public static Image<Rgba32> MirrorV(Image<Rgba32> original)
            {
                var mirroredImage = original.Clone();
                mirroredImage.Mutate(context => context.Flip(FlipMode.Vertical));
                return mirroredImage;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class HueAdjuster
        {

            public static Image<Rgba32> AdjustHue(Image<Rgba32> original, float hueShiftDegrees) // -180 180
            {
                var adjustedImage = original.Clone();

                hueShiftDegrees = hueShiftDegrees % 360;
                if (hueShiftDegrees < 0) hueShiftDegrees += 360;

                adjustedImage.Mutate(context =>
                {
                    for (int y = 0; y < adjustedImage.Height; y++)
                    {
                        for (int x = 0; x < adjustedImage.Width; x++)
                        {
                            // Получение текущего пикселя
                            var pixel = adjustedImage[x, y];

                            // Преобразование из RGB в HSL
                            (float h, float s, float l) = RgbToHsl(pixel);

                            // Сдвиг цветового тона
                            h = (h + hueShiftDegrees) % 360;

                            // Преобразование обратно из HSL в RGB
                            var newPixel = HslToRgb(h, s, l);
                            adjustedImage[x, y] = newPixel;
                        }
                    }
                });

                return adjustedImage;
            }


            private static (float H, float S, float L) RgbToHsl(Rgba32 pixel)
            {
                float r = pixel.R / 255f;
                float g = pixel.G / 255f;
                float b = pixel.B / 255f;

                float max = Math.Max(r, Math.Max(g, b));
                float min = Math.Min(r, Math.Min(g, b));

                float h = 0;
                float s = 0;
                float l = (max + min) / 2;

                if (max != min)
                {
                    float delta = max - min;

                    s = l > 0.5f ? delta / (2 - max - min) : delta / (max + min);

                    if (max == r)
                    {
                        h = (g - b) / delta + (g < b ? 6 : 0);
                    }
                    else if (max == g)
                    {
                        h = (b - r) / delta + 2;
                    }
                    else if (max == b)
                    {
                        h = (r - g) / delta + 4;
                    }

                    h *= 60;
                }

                return (h, s, l);
            }

            private static Rgba32 HslToRgb(float h, float s, float l)
            {
                float r, g, b;

                if (s == 0)
                {
                    r = g = b = l; // Градация серого
                }
                else
                {
                    float q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                    float p = 2 * l - q;
                    r = HueToRgb(p, q, h + 120);
                    g = HueToRgb(p, q, h);
                    b = HueToRgb(p, q, h - 120);
                }

                return new Rgba32(
                    (byte)(r * 255),
                    (byte)(g * 255),
                    (byte)(b * 255),
                    255 // Прозрачность остается неизменной
                );
            }

            private static float HueToRgb(float p, float q, float t)
            {
                if (t < 0) t += 360;
                if (t > 360) t -= 360;
                if (t < 60) return p + (q - p) * t / 60;
                if (t < 180) return q;
                if (t < 240) return p + (q - p) * (240 - t) / 60;
                return p;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        public static class ImageWarpProcessor
        {

            public static Image<Rgba32> WarpImage(Image<Rgba32> original, float waveIntensity, float frequency)
            {
                var width = original.Width;
                var height = original.Height;

                var warpedImage = new Image<Rgba32>(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Расчет смещения с использованием синусоидальной функции
                        int offsetX = (int)(waveIntensity * Math.Sin(2 * Math.PI * y * frequency / height));
                        int newX = x + offsetX;

                        // Проверка выхода за пределы изображения
                        if (newX >= 0 && newX < width)
                        {
                            warpedImage[newX, y] = original[x, y];
                        }
                    }
                }

                return warpedImage;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        private static byte Clamp(int value)
        {
            return (byte)Math.Max(0, Math.Min(255, value));
        }
    }
}