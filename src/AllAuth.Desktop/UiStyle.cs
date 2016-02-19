using System;
using System.Drawing;

namespace AllAuth.Desktop
{
    internal static class UiStyle
    {
        private const float DefaultFontSize = 11.25f;
        private const float DefaultFontTitleSize = 22f;

        public static Font DefaultFont { get; private set; }
        public static Font DefaultFontTitle { get; private set; }

        public static readonly Color AccentColor = Color.FromArgb(119, 172, 57);
        
        static UiStyle()
        {
            if (IsFontInstalled("Open Sans"))
            {
                DefaultFont = new Font("Open Sans", DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                DefaultFontTitle = new Font("Open Sans Light", DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            else if (Environment.OSVersion.Platform == PlatformID.Unix && IsFontInstalled("Ubuntu L"))
            {
                DefaultFont = new Font("Ubuntu L", DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                DefaultFontTitle = new Font("Ubuntu L", DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            else
            {
                DefaultFont = new Font("Segoe UI", DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                DefaultFontTitle = new Font("Segoe UI Light", DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        private static bool IsFontInstalled(string fontName)
        {
            using (var testFont = new Font(fontName, 8))
            {
                return 0 == string.Compare(
                  fontName,
                  testFont.Name,
                  StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
