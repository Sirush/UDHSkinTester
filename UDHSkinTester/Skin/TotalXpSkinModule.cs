using System.Globalization;
using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class TotalXpSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            Text = data.XpTotal.ToString("N0", new CultureInfo("en-US"));
            return base.GetDrawables(data);
        }

        public TotalXpSkinModule()
        {
            StrokeColor = MagickColors.Transparent.ToString();
            FillColor = MagickColors.Black.ToString();
            FontPointSize = 17;
        }
    }
}