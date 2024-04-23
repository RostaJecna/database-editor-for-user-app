using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DatabaseEditorForUser.Graphics
{
    internal static class Palettes
    {
        private const string Path = @"../../Resources/Graphics/palettes.csv";
        private static readonly List<Color> Colors = ReadFrom(Path);
        private static int _lastColorIndex;

        private static List<Color> ReadFrom(string path)
        {
            List<Color> temp = new List<Color>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) temp.Add(ColorTranslator.FromHtml(sr.ReadLine()));
            }

            return temp;
        }

        public static Color GetNextRandom(Random rnd)
        {
            int colorIndex = rnd.Next(Colors.Count);
            while (_lastColorIndex == colorIndex)
                colorIndex = rnd.Next(Colors.Count);
            _lastColorIndex = colorIndex;
            return Colors[colorIndex];
        }

        public static Color GetLast()
        {
            return Colors[_lastColorIndex];
        }

        public static Color GetLastDarkness(int darkness)
        {
            Color color = Colors[_lastColorIndex];
            return Color.FromArgb(
                Math.Abs(color.R - darkness),
                Math.Abs(color.G - darkness),
                Math.Abs(color.B - darkness)
            );
        }
    }
}