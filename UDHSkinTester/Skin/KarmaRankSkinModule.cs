using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class KarmaRankSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            Text = $"#{data.KarmaRank}";
            return base.GetDrawables(data);
        }

        public KarmaRankSkinModule()
        {
            StartX = 535;
            StartY = 153;
            StrokeColor = MagickColors.Transparent.ToString();
            FillColor = MagickColors.Black.ToString();
            FontPointSize = 17;
        }
    }
}