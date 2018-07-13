﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using ImageMagick;

namespace UDHSkinTester.Skin
{
    public class CustomTextSkinModule : BaseTextSkinModule
    {

        public override Drawables GetDrawables(ProfileData data)
        {
            PointD textPosition = new PointD(StartX, StartY);
            
            // Reflection to convert stuff like {Level} to data.Level
            var reg = new Regex(@"(?<=\{)(.*?)(?=\})");
            var mc = reg.Matches(Text);
            foreach (var match in mc)
            {
                var prop = typeof(ProfileData).GetProperty(match.ToString());
                if (prop == null) continue;
                var value = (dynamic) prop.GetValue(data, null);
                Text = Text.Replace("{" + match + "}", value.ToString());
            }
            /* ALL properties of ProfileData.cs can be used!
             * Like {Level} for ProfileData.Level
             * Or {Nickname} for ProfileData.Nickname
             */

            return new Drawables()
                .FontPointSize(FontPointSize)
                .Font(Font)
                .StrokeColor(new MagickColor(StrokeColor))
                .StrokeWidth(StrokeWidth)
                .StrokeAntialias(StrokeAntiAlias)
                .FillColor(new MagickColor(FillColor))
                .TextAlignment(TextAlignment.Left)
                .TextAntialias(TextAntiAlias)
                .Text(textPosition.X, textPosition.Y, $"{Text ?? Text}");
        }

        public CustomTextSkinModule()
        {
            StrokeWidth = 1;
            FillColor = MagickColors.Black.ToString();
            StrokeColor = MagickColors.Transparent.ToString();
            Font = "Consolas";
            FontPointSize = 15;
        }
    }
}