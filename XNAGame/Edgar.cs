using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAGame
{
    class Edgar : GameUnit
    {

        

        public Edgar()
        {
        }

        public Edgar(Vector2 initPosition)
        {
            Position = initPosition;
            Speed = new Vector2(100.0f, 100.0f);
        }

        public void Load(ContentManager Content, string name)
        {
            SpriteTexture = Content.Load<Texture2D>("Edgar-1");
            Name = name;
            Size = new Rectangle(0, 0, (int)(SpriteTexture.Width * Scale), (int)(SpriteTexture.Height * Scale));

            //Position = new Vector2(100f, 100f);
            //base.Load(Content, name);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();

            UpdateMovement(currentState);

            prevKeyboardState = currentState;

            base.Update(gameTime);
        }

        private void UpdateMovement(KeyboardState currentState)
        {
            if (state == GameUnitState.Walking)
            {
                Direction = Vector2.Zero;

                if (currentState.IsKeyDown(Keys.A))
                {
                    Direction.X = left;
                }
                else if (currentState.IsKeyDown(Keys.D))
                {
                    Direction.X = right;
                }

                if (currentState.IsKeyDown(Keys.W))
                {
                    Direction.Y = up;
                }
                else if (currentState.IsKeyDown(Keys.S))
                {
                    Direction.Y = down;
                }
            }
        }

    }
}
