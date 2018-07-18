using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class RectangularMaskSkinModule : ISkinModule
    {
        public string Type { get; set; }

        public string Source { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double AvatarSize { get; set; }
        public int StrokeWidth { get; set; }

        public Drawables GetDrawables(ProfileData data)
        {
            MagickColor color = MagickColor.FromRgb(data.MainRoleColor.R, data.MainRoleColor.G, data.MainRoleColor.B);
            MagickImage mask = new MagickImage(Source);
            data.Picture.Composite(mask, CompositeOperator.CopyAlpha);
            return new Drawables()
                   .FillColor(color)
                   .Rectangle(StartX - StrokeWidth,
                              StartY - StrokeWidth,
                              StartX + AvatarSize + StrokeWidth,
                              StartY + AvatarSize + StrokeWidth);
        }

        public RectangularMaskSkinModule()
        {
            Source = "resources/rectMask.png";
            AvatarSize = 128;
            StartX = 0;
            StartY = 0;
            StrokeWidth = 3;
        }
    }
}