﻿﻿using System.Drawing;
using System.IO;
using ImageMagick;
using Newtonsoft.Json;
using UDHSkinTester.Skin;

namespace UDHSkinTester
{
    public class ProfileCardGenerator
    {
        private string _avatarPath = "resources/avatar.png";
        private string _profilePath = "resources/profile.json";
        private string _skinPath = "resources/skin.alaanor.json";

        private ProfileData GetProfileData()
        {
            ProfileData data = JsonConvert.DeserializeObject<ProfileData>(File.ReadAllText(_profilePath));
            data.MainRoleColor = Color.Red;
            data.Picture = new MagickImage(_avatarPath);
            return data;
        }

        private SkinData GetSkinData()
        {
            return JsonConvert.DeserializeObject<SkinData>(File.ReadAllText(_skinPath), new SkinModuleJsonConverter());
        }

        public void GenerateProfileCard()
        {
            using (MagickImageCollection profileCard = new MagickImageCollection())
            {
                ProfileData profile = GetProfileData();
                SkinData skin = GetSkinData();

                MagickImage background = new MagickImage(skin.Background);
                profile.Picture.Resize(skin.AvatarSize, skin.AvatarSize);
                profileCard.Add(background);

                foreach (var layer in skin.Layers)
                {
                    if (layer.Image != null)
                    {
                        MagickImage image = layer.Image.ToLower() == "avatar"
                            ? profile.Picture
                            : new MagickImage(layer.Image);
                        
                        background.Composite(image, (int) layer.StartX, (int) layer.StartY, CompositeOperator.Over);
                    }

                    MagickImage l = new MagickImage(MagickColors.Transparent, (int) layer.Width, (int) layer.Height);
                    foreach (var module in layer.Modules)
                    {
                        module.GetDrawables(profile).Draw(l);
                    }

                    background.Composite(l, (int) layer.StartX, (int) layer.StartY, CompositeOperator.Over);
                }

                using (IMagickImage result = profileCard.Mosaic())
                {
                    result.Write("profileCard.png");
                }
            }
        }
    }
}