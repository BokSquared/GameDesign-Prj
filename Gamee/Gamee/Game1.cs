using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gamee
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Background bg1, bg2, curBg;

        int curStage = -1;

        Texture2D tileTexture;
        List<Platform> stage1 = new List<Platform>();
        List<Platform> stage2 = new List<Platform>();
        List<Platform> curPlatforms;

        Platform[] t1, t2, t3, t4, t5, t6;
        Platform[] p1, p2, p3, p4, p5, p6, p7; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 580;
            _graphics.PreferredBackBufferWidth = 900;
        }

        protected override void Initialize()
        {
            #region Background
            Texture2D bg1Texture = Content.Load<Texture2D>("background1");
            Rectangle bg1Rectangle = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            Color bg1Color = Color.White;

            bg1 = new Background(bg1Texture, bg1Rectangle, bg1Color);

            Texture2D bg2Texture = Content.Load<Texture2D>("background2");
            Rectangle bg2Rectangle = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            Color bg2Color = Color.White;

            bg2 = new Background(bg2Texture, bg2Rectangle, bg2Color);

            #endregion

            curBg = bg1;

            tileTexture = Content.Load<Texture2D>("plates");
            
            Color tileColor = Color.White;

            #region Stage 1
            t1 = new Platform[5];
            for (int i = 0; i < t1.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(0 + (i * 50), Window.ClientBounds.Height - 450, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t1[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t1[i]);       
            }

            t2 = new Platform[4];
            for (int i = 0; i < t2.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(175 + (i * 50), Window.ClientBounds.Height - 300, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t2[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t2[i]);
            }

            t3 = new Platform[7];
            for (int i = 0; i < t3.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(0 + (i * 50), Window.ClientBounds.Height - 100, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t3[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t3[i]);
            }

            t4 = new Platform[6];
            for (int i = 0; i < t4.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(500 + (i * 50), Window.ClientBounds.Height - 150, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t4[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t4[i]);
            }

            t5 = new Platform[2];
            int pos = Window.ClientBounds.Width - (2 * 50);
            for (int i = 0; i < t5.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(pos + (i * 50), Window.ClientBounds.Height - 250, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t5[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t5[i]);
            }

            t6 = new Platform[6];
            for (int i = 0; i < t6.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(480 + (i * 50), Window.ClientBounds.Height - 400, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 4, 0, tileTexture.Width / 5, tileTexture.Height);
                t6[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage1.Add(t6[i]);
            }
            #endregion

            #region Stage 2
            p1 = new Platform[4];
            for (int i = 0; i < p1.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(0 + (i * 50), Window.ClientBounds.Height - 400, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p1[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p1[i]);
            }

            p2 = new Platform[3];
            for (int i = 0; i < p2.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(150 + (i * 50), Window.ClientBounds.Height - 280, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p2[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p2[i]);
            }

            p3 = new Platform[2];
            for (int i = 0; i < p3.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(400 + (i * 50), Window.ClientBounds.Height - 330, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p3[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p3[i]);
            }

            p4 = new Platform[1];
            for (int i = 0; i < p4.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(500 + (i * 50), Window.ClientBounds.Height - 430, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p4[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p4[i]);
            }

            p5 = new Platform[5];
            int pos2 = Window.ClientBounds.Width - (5 * 50);
            for (int i = 0; i < p5.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(pos2 + (i * 50), Window.ClientBounds.Height - 480, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p5[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p5[i]);
            }

            p6 = new Platform[6];
            for (int i = 0; i < p6.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(0 + (i * 50), Window.ClientBounds.Height - 100, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p6[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p6[i]);
            }

            p7 = new Platform[5];
            for (int i = 0; i < p7.Length; i++)
            {
                Rectangle tileDisplay = new Rectangle(550 + (i * 50), Window.ClientBounds.Height - 150, 50, 50);
                Rectangle tileSource = new Rectangle(tileTexture.Width / 5 * 3, 0, tileTexture.Width / 5, tileTexture.Height);
                p7[i] = new Platform(tileTexture, tileDisplay, tileSource, tileColor);
                stage2.Add(p7[i]);
            }
            #endregion

            curPlatforms = stage1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
                   
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                curStage = 1;
                curBg = bg1;
                curPlatforms = stage1;
            } 

            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                curStage = 2;
                curBg = bg2;
                curPlatforms = stage2;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(curBg.BgTexture, curBg.BgRectangle, curBg.BgColor);

            foreach (Platform platform in curPlatforms)
            {
                _spriteBatch.Draw(platform.TileTexture, platform.TileDisplay,
                    platform.TileSource, platform.TileColor);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
