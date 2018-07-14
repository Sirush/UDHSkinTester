using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class XpBarInfoSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            Text = $"{data.XpShown:#,##0} / {data.MaxXpShown:N0} ({(data.XpPercentage * 100):0}%)";
            return base.GetDrawables(data);
        }

        public XpBarInfoSkinModule()
        {
            StrokeWidth = 1;
            FillColor = MagickColors.Black.ToString();
            StrokeColor = MagickColors.Transparent.ToString();
            FontPointSize = 17;
        }
    }
}