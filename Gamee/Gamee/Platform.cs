using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Gamee
{
    internal class Platform
    {
        Texture2D tileTexture;
        Rectangle tileDisplay;
        Rectangle tileSource;
        Color tileColor;

        public Platform(Texture2D tileTexture, Rectangle tileDisplay, Rectangle tileSource, Color tileColor)
        {
            this.tileTexture = tileTexture;
            this.tileDisplay = tileDisplay;
            this.tileSource = tileSource;
            this.tileColor = tileColor;
        }

        public Texture2D TileTexture { get => tileTexture;}
        public Rectangle TileDisplay { get => tileDisplay;}
        public Rectangle TileSource { get => tileSource; }
        public Color TileColor { get => tileColor; }
    }
}
