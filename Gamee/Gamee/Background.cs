using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gamee
{
    internal class Background
    {
        Texture2D bgTexture;
        Rectangle bgRectangle;
        Color bgColor;

        public Background(Texture2D bgTexture, Rectangle bgRectangle, Color bgColor)
        {
            this.bgTexture = bgTexture;
            this.bgRectangle = bgRectangle;
            this.bgColor = bgColor;
        }

        public Texture2D BgTexture { get => bgTexture; }
        public Rectangle BgRectangle { get => bgRectangle;}
        public Color BgColor { get => bgColor; }
    }
}
