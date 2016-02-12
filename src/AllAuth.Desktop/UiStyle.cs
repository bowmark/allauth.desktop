using System.Drawing;
using System.Drawing.Text;
using System.IO;

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
            // Custom font errors seen in Ubuntu 14.04
            //if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            //{
                DefaultFont = new Font("Segoe UI", DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                DefaultFontTitle = new Font("Segoe UI Light", DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                return;
            //}

            if (File.Exists("Resources/OpenSans-Regular.ttf"))
            {
                var privateFontsRegular = new PrivateFontCollection();
                privateFontsRegular.AddFontFile("Resources/OpenSans-Regular.ttf");
                var regularFont = privateFontsRegular.Families[0];

                DefaultFont = new Font(regularFont, DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            else
            {
                DefaultFont = new Font("Open Sans", DefaultFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }

            if (File.Exists("Resources/OpenSans-Light.ttf"))
            {
                var privateFontsLight = new PrivateFontCollection();
                privateFontsLight.AddFontFile("Resources/OpenSans-Light.ttf");
                var lightFont = privateFontsLight.Families[0];
                
                DefaultFontTitle = new Font(lightFont, DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
            else
            {
                DefaultFontTitle = new Font("Open Sans Light", DefaultFontTitleSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }
    }
}
