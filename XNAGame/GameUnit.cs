using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XNAGame
{
    abstract class GameUnit
    {
        protected Texture2D spriteTexture;
        protected Vector2 position;
        protected float scale = 1f;      // the factor by which to scale the unit

        public void Load(ContentManager Content)
        {
            spriteTexture = Content.Load<Texture2D>("i-am-error");
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(spriteTexture, new Vector2() { X=0, Y=0 }, Color.White); 
        }

    }
}
