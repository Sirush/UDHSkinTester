using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class RoundedMaskSkinModule : ISkinModule
    {
        public string Type { get; set; }

        public string Source { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double AvatarSize { get; set; }
        public double CornerHeight { get; set; }
        public double CornerWidth { get; set; }
        public int StrokeWidth { get; set; }

        public Drawables GetDrawables(ProfileData data)
        {
            MagickColor color = MagickColor.FromRgb(data.MainRoleColor.R, data.MainRoleColor.G, data.MainRoleColor.B);
            MagickImage mask = new MagickImage(Source);
            data.Picture.Composite(mask, CompositeOperator.CopyAlpha);
            return new Drawables()
                   .FillColor(color)
                   .RoundRectangle(StartX - StrokeWidth,
                                   StartY - StrokeWidth,
                                   StartX + AvatarSize + StrokeWidth,
                                   StartY + AvatarSize + StrokeWidth,
                                   CornerWidth,
                                   CornerHeight);
        }

        public RoundedMaskSkinModule()
        {
            Source = "resources/circularMask.png";
            AvatarSize = 128;
            StartX = 0;
            StartY = 0;
            CornerWidth = 1;
            CornerHeight = 1;
            StrokeWidth = 3;
        }
    }
}