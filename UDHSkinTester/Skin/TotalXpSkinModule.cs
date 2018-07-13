using System.Globalization;
using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class TotalXpSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            PointD xpPosition = new PointD(StartX, StartY);

            return new Drawables()
                .FontPointSize(FontPointSize)
                .Font(Font)
                .StrokeColor(new MagickColor(StrokeColor))
                .StrokeWidth(StrokeWidth)
                .StrokeAntialias(StrokeAntiAlias)
                .FillColor(new MagickColor(FillColor))
                .TextAntialias(TextAntiAlias)
                .TextAlignment(TextAlignment.Right)
                .Text(xpPosition.X, xpPosition.Y, data.XpTotal.ToString("N0", new CultureInfo("en-US")));
        }

        public TotalXpSkinModule()
        {
            StrokeColor = MagickColors.Transparent.ToString();
            FillColor = MagickColors.Black.ToString();
            FontPointSize = 17;
            StrokeWidth = 1;
            Font = "Consolas";
            TextAntiAlias = true;
            StrokeAntiAlias = true;
        }
    }
}