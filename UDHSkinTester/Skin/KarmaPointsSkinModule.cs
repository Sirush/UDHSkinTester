using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class KarmaPointsSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            Text = $"{data.Karma}";
            return base.GetDrawables(data);
        }

        public KarmaPointsSkinModule()
        {
            StartX = 535;
            StartY = 130;
            StrokeColor = MagickColors.Transparent.ToString();
            FillColor = MagickColors.Black.ToString();
            FontPointSize = 17;
        }
    }
}