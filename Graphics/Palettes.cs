using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DatabaseEditorForUser.Graphics
{
    /// <summary>
    ///     Provides methods for managing color palettes used in the application.
    /// </summary>
    internal static class Palettes
    {
        private const string Path = @"../../Resources/Graphics/palettes.csv";
        private static readonly List<Color> Colors = ReadFrom(Path);
        private static int _lastColorIndex;

        /// <summary>
        ///     Reads color values from a CSV file located at the specified path.
        /// </summary>
        /// <param name="path">The path to the CSV file containing color values.</param>
        /// <returns>A list of colors read from the CSV file.</returns>
        private static List<Color> ReadFrom(string path)
        {
            List<Color> temp = new List<Color>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine(); // Skip header line
                while (!sr.EndOfStream)
                    temp.Add(ColorTranslator.FromHtml(sr.ReadLine()));
            }

            return temp;
        }

        /// <summary>
        ///     Retrieves a random color from the color palette.
        /// </summary>
        /// <param name="rnd">A Random object used to generate random indices.</param>
        /// <returns>A random color from the color palette.</returns>
        public static Color GetNextRandom(Random rnd)
        {
            int colorIndex = rnd.Next(Colors.Count);
            while (_lastColorIndex == colorIndex)
                colorIndex = rnd.Next(Colors.Count);
            _lastColorIndex = colorIndex;
            return Colors[colorIndex];
        }

        /// <summary>
        ///     Retrieves the last color accessed from the color palette.
        /// </summary>
        /// <returns>The last color accessed from the color palette.</returns>
        public static Color GetLast()
        {
            return Colors[_lastColorIndex];
        }

        /// <summary>
        ///     Retrieves a darker shade of the last accessed color from the color palette.
        /// </summary>
        /// <param name="darkness">The darkness value to apply to the color.</param>
        /// <returns>A darker shade of the last accessed color.</returns>
        public static Color GetLastDarkness(int darkness)
        {
            Color color = GetLast();
            return Color.FromArgb(
                Math.Abs(color.R - darkness),
                Math.Abs(color.G - darkness),
                Math.Abs(color.B - darkness)
            );
        }
    }
}