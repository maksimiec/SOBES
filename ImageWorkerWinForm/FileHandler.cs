using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
 
namespace ImageTransformationApp
{
    public static class FileHandler
    {

        // Чтение PNG файлов из каталога
        public static string[] GetPngFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                MessageBox.Show("Cann'ot find folder, check it out");
   
            
                //throw new DirectoryNotFoundException($"Directory {directoryPath} not found");
                // string[] exts = {"*.jpg" , "*.png" };
                string[] files1 = Directory.GetFiles(directoryPath, "*.jpg"); string[] files2 = Directory.GetFiles(directoryPath, "*.png");
                string[] allfiles = new string[files1.Length + files2.Length];
                Array.Copy(files1, 0, allfiles, 0, files1.Length);
                Array.Copy(files2, 0, allfiles, files1.Length, files2.Length);


                //            return Directory.GetFiles(directoryPath, "*.jpg");

                return allfiles;
            

        }

        // Сохранение изображения в новую папку
        public static void SaveImage(string directoryPath, string originalFileName, string suffix, Image<Rgba32> image)
        {
            string newDirectory = Path.Combine(directoryPath, suffix);
            if (!Directory.Exists(newDirectory))
                Directory.CreateDirectory(newDirectory);

            string newFileName = Path.GetFileNameWithoutExtension(originalFileName) + $"-{suffix}.jpg";
            string fullPath = Path.Combine(newDirectory, newFileName);
            image.Save(fullPath);
        }
        public static void SaveImage(string directoryPath, string originalFileName, string suffix, Bitmap image)
        {
            string newDirectory = Path.Combine(directoryPath, suffix);
            if (!Directory.Exists(newDirectory))
                Directory.CreateDirectory(newDirectory);

            string newFileName = Path.GetFileNameWithoutExtension(originalFileName) + $"-{suffix}.jpg";
            string fullPath = Path.Combine(newDirectory, newFileName);
            image.Save(fullPath);
        }
        public static void SaveImage(string directoryPath, string originalFileName, string suffix, SixLabors.ImageSharp.Image image)
        {
            string newDirectory = Path.Combine(directoryPath, suffix);
            if (!Directory.Exists(newDirectory))
                Directory.CreateDirectory(newDirectory);

            string newFileName = Path.GetFileNameWithoutExtension(originalFileName) + $"-{suffix}.jpg";
            string fullPath = Path.Combine(newDirectory, newFileName);
            image.Save(fullPath);
        }

    }
}
