using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEditorForUser.Graphics
{
    internal static class Palettes
    {
        private const string PATH = @"../../Resources/Graphics/palettes.csv";
        private static readonly List<Color> colors = ReadFrom(PATH);
        private static int lastColorIndex;

        private static List<Color> ReadFrom(string path)
        {
            List<Color> temp = new List<Color>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    temp.Add(ColorTranslator.FromHtml(sr.ReadLine()));
                }
            }

            return temp;
        }

        public static Color GetNextRandom(Random rnd)
        {
            int colorIndex = rnd.Next(colors.Count);
            while (lastColorIndex == colorIndex)
                colorIndex = rnd.Next(colors.Count);
            lastColorIndex = colorIndex;
            return colors[colorIndex];
        }
    }
}
