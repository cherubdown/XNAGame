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
    class Locke : GameUnit
    {


        public Locke()
        {
        }

        public Locke(Vector2 initPosition)
        {
            this.Position = initPosition;
            Speed = new Vector2(300f, 300f);
        }

        public void Load(ContentManager content, string name)
        {
            SpriteTexture = content.Load<Texture2D>("Locke-2");
            Name = name;
            Size = new Rectangle(0, 0, (int)(SpriteTexture.Width * Scale), (int)(SpriteTexture.Height * Scale));
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            UpdateMovement(currentKeyboardState);
            prevKeyboardState = currentKeyboardState;
            base.Update(gameTime);
        }

        private void UpdateMovement(KeyboardState currentKeyboardState)
        {
            if (this.state == GameUnitState.Walking)
            {
                Direction = Vector2.Zero;

                if (currentKeyboardState.IsKeyDown(Keys.Up))
                {
                    Direction.Y = up;
                }
                else if (currentKeyboardState.IsKeyDown(Keys.Down))
                {
                    Direction.Y = down;
                }

                if (currentKeyboardState.IsKeyDown(Keys.Left))
                {
                    Direction.X = left;
                }
                else if (currentKeyboardState.IsKeyDown(Keys.Right))
                {
                    Direction.X = down;
                }
            }
        }
        
    }
}
