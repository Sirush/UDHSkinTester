using ImageMagick;

namespace UDHSkinTester.Skin
{
    public interface ISkinModule
    {
        string Type { get; set; }
        
        Drawables GetDrawables(ProfileData data);
    }
}