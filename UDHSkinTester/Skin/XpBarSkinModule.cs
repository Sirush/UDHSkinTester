using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class XpBarSkinModule : ISkinModule
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double StrokeWidth { get; set; }
        public string OutsideStrokeColor { get; set; }
        public string OutsideFillColor { get; set; }
        public string InsideStrokeColor { get; set; }
        public string InsideFillColor { get; set; }

        public string Type { get; set; }

        public Drawables GetDrawables(ProfileData data)
        {
            RectangleD xpBarOutsideRectangle = new RectangleD(StartX, StartY,
                StartX + Width, StartY + Height);

            RectangleD xpBarInsideRectangle =
                new RectangleD(xpBarOutsideRectangle.UpperLeftX + 2, xpBarOutsideRectangle.UpperLeftY + 2,
                    StartX + (Width * data.XpPercentage) - 2, xpBarOutsideRectangle.LowerRightY - 2);

            return new Drawables()
                //XP Bar Outside
                .StrokeColor(new MagickColor(OutsideStrokeColor))
                .StrokeWidth(StrokeWidth)
                .FillColor(new MagickColor(OutsideFillColor))
                .Rectangle(xpBarOutsideRectangle.UpperLeftX, xpBarOutsideRectangle.UpperLeftY, xpBarOutsideRectangle.LowerRightX,
                    xpBarOutsideRectangle.LowerRightY)

                //XP Bar Inside
                .StrokeColor(new MagickColor(InsideStrokeColor))
                .FillColor(new MagickColor(InsideFillColor))
                .Rectangle(xpBarInsideRectangle.UpperLeftX, xpBarInsideRectangle.UpperLeftY, xpBarInsideRectangle.LowerRightX,
                    xpBarInsideRectangle.LowerRightY);
        }

        public XpBarSkinModule()
        {
            OutsideStrokeColor = "#778899FF";
            OutsideFillColor = "#F5F5F5FF";
            InsideStrokeColor = "#FFFFFF00";
            InsideFillColor = "#32CD32FF";
            StrokeWidth = 1;
            Width = 200;
            Height = 20;
        }
    }
}