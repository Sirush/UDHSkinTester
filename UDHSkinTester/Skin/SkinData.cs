using System.Collections.Generic;

namespace UDHSkinTester.Skin
{
    public class SkinData
    {
        public string Name { get; set; }
        public string Codename { get; set; }
        public string Description { get; set; }
        public int AvatarSize { get; set; }
        public int AvatarX { get; set; }
        public int AvatarY { get; set; }
        public string Background { get; set; }
        public List<SkinLayer> Layers { get; set; }

        public SkinData()
        {
            Layers = new List<SkinLayer>();
        }
    }
}