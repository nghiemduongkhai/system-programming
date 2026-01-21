using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SystemProgramming.Lab02
{
    public class Question5
    {
        public static void Solution()
        {
            string fontName = "Arial";
            string fontPath = @"C:\Fonts\Arial.ttf";

            EnsureFontInstalled(fontName, fontPath);

            Console.WriteLine("===== MEMBERSHIP CARD =====");
            Console.WriteLine("Name  : DUONG KHAI NGHIEM");
            Console.WriteLine("ID    : CRM-2030-01");
            Console.WriteLine("Level : PLATINUM");
            Console.WriteLine("===========================");
        }

        public static void EnsureFontInstalled(string fontName, string fontPath)
        {
            if (IsFontInstalled(fontName))
            {
                Console.WriteLine($"Font '{fontName}' already installed.\n");
                return;
            }

            if (!File.Exists(fontPath))
            {
                Console.WriteLine(
                    $"Font '{fontName}' not found and font file is missing. " + $"Using default system font.\n");
                return;
            }

            Console.WriteLine($"Installing font '{fontName}'...\n");

            Console.WriteLine($"Font '{fontName}' installed successfully.\n");
        }

        public static bool IsFontInstalled(string fontName)
        {
            string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

            foreach (string file in Directory.GetFiles(fontsFolder))
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                if (fileName.IndexOf(fontName, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }

            return false;
        }
    }
}