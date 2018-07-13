using ImageMagick;

namespace UDHSkinTester.Skin
{
    public abstract class BaseTextSkinModule : ISkinModule
    {
        public double StartX { get; set; }
        public double StartY { get; set; }

        public bool StrokeAntiAlias { get; set; }
        public bool TextAntiAlias { get; set; }
        public string StrokeColor { get; set; }
        public double StrokeWidth { get; set; }
        public string FillColor { get; set; }
        public string Font { get; set; }
        public double FontPointSize { get; set; }

        public virtual string Type { get; set; }

        public virtual Drawables GetDrawables(ProfileData data)
        {
            throw new System.NotImplementedException();
        }
    }
}