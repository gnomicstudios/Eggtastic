using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Gnomic.Core;

namespace Eggtastic
{
    public class StartScreen : GameScreen
    {
        public StartScreen(Game1 game)
            : base(game, game.Camera) 
        {
            Texture2D backgroundTexture = game.Content.Load<Texture2D>("startScreen");

            base.ActiveEntities.Add(
                new SpriteEntity(backgroundTexture, game.ScreenSizeDefault / 2.0f));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

#if ANDROID
			// Temporary hack as Android's touch input seems to only report Move events (at least on simulator)
			if (Microsoft.Xna.Framework.Input.Touch.TouchPanel.GetState().Count > 0)
#else
			if (Input.ButtonJustUpMapped((int)Controls.Select))
#endif
            {
                ((Game1)base.Game).StartGame();
            }
        }
    }
}