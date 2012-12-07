using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAGame
{
    class Edgar : GameUnit
    {
        public Edgar()
        {
        }

        public Edgar(Vector2 initPosition)
        {
            position = initPosition;
        }

        public void Load(ContentManager Content)
        {
            spriteTexture = Content.Load<Texture2D>("Edgar-1");
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(spriteTexture, position, Color.White);
        }
    }
}
