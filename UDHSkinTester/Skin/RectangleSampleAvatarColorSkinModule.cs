using ImageMagick;

namespace UDHSkinTester.Skin
{
    /// <summary>
    /// Fill the background with the color based on the pfp
    /// </summary>
    public class RectangleSampleAvatarColorSkinModule : ISkinModule
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string Type { get; set; }

        public Drawables GetDrawables(ProfileData data)
        {
            MagickColor color = DetermineColor(data.Picture);

            return new Drawables()
                .FillColor(color)
                .Rectangle(StartX, StartY, StartX + Width, StartY + Height);
        }

        private MagickColor DetermineColor(MagickImage dataPicture)
        {
            //basically we let magick to choose what the main color by resizing to 1x1
            MagickImage copy = new MagickImage(dataPicture);
            copy.Resize(1, 1);
            return copy.GetPixels()[0, 0].ToColor();
        }
    }
}