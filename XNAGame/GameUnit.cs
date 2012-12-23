using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAGame
{
    enum GameUnitState
    {
        Walking
    }

    abstract class GameUnit
    {
        protected Texture2D SpriteTexture;
        protected Vector2 Position;
        protected Vector2 Direction;
        public Vector2 Speed;
        protected const int speed = 160;
        

        public string Name = "IAmError";
        public Rectangle Size;
        private float scale = 1.0f;

        protected const int up = -1;
        protected const int down = 1;
        protected const int left = -1;
        protected const int right = 1;

        public GameUnitState state = GameUnitState.Walking;
        protected KeyboardState prevKeyboardState;

        public float Scale
        {
            get { return scale; }
            set
            {
                this.Scale = value;
                Size = new Rectangle(0, 0, (int)(SpriteTexture.Width * scale), (int)(SpriteTexture.Height * scale));
            }
        }

        public void Load(ContentManager Content, string name)
        {
            SpriteTexture = Content.Load<Texture2D>("i-am-error");
            Name = name;
            Size = new Rectangle(0, 0, (int)(SpriteTexture.Width * scale), (int)(SpriteTexture.Height * scale));
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(SpriteTexture, Position, new Rectangle(0, 0, SpriteTexture.Width, SpriteTexture.Height),
                Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
        public void Update(GameTime gameTime)
        {
            Position += Speed * Direction * (float)(gameTime.ElapsedGameTime.TotalSeconds);
        }

    }
}
