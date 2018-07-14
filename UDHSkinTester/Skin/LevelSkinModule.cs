using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class LevelSkinModule : BaseTextSkinModule
    {
        public override Drawables GetDrawables(ProfileData data)
        {
            Text = data.Level.ToString();
            return base.GetDrawables(data);
        }

        public LevelSkinModule()
        {
            StartX = 220;
            StartY = 140;
            StrokeColor = MagickColors.IndianRed.ToString();
            FillColor = MagickColors.IndianRed.ToString();
            FontPointSize = 50;
        }
    }
}