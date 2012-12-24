using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace XNAGame
{
    class Paddle : GameUnit
    {
        public enum Player
        {
            Player1,
            Player2
        }

        private Player player;
        private GraphicsDevice graphicsDevice;

        public Paddle(Player player)
        {
            this.player = player;
        }

        public void Load(GraphicsDevice graphicsDevice, ContentManager content, string name)
        {
            SpriteTexture = content.Load<Texture2D>("Pattle");
            Name = name;
            base.Load(content); //this gives the size, so we can use it for the position
            this.graphicsDevice = graphicsDevice;

            float yPos = (graphicsDevice.Viewport.Bounds.Height + Size.Height) / 2;
            if (this.player == Player.Player1)
            {
                float xPos = 0f;
                Position = new Vector2(xPos, yPos);
            }
            else if (this.player == Player.Player2)
            {
                // position.x for player 2 is determined by the width
                // of screen minus the width of the paddle
                float xPos = graphicsDevice.Viewport.Bounds.Width - Size.Width;
                Position = new Vector2(xPos, yPos);
            }
            else
            {
                throw new Exception("Player constructor error: Player may only be player 1 or player 2.");
            }

            Speed = new Vector2(0f, 300f);  //arbitrary speed. TODO: add options for speed
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
            Direction = Vector2.Zero;

            // for player 1, we'll use w and s for movement
            if (player == Player.Player1)
            {
                if (currentKeyboardState.IsKeyDown(Keys.W))
                {
                    Direction.Y = up;
                }
                else if (currentKeyboardState.IsKeyDown(Keys.S))
                {
                    Direction.Y = down;
                }
            }
            else if (player == Player.Player2)
            {
                if (currentKeyboardState.IsKeyDown(Keys.O))
                {
                    Direction.Y = up;
                }
                else if (currentKeyboardState.IsKeyDown(Keys.L))
                {
                    Direction.Y = down;
                }
            }

            //ensures the game objects never go off the screen
            Position.X = MathHelper.Clamp(Position.X, 0, graphicsDevice.Viewport.Width - Size.Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, graphicsDevice.Viewport.Height - Size.Height);
        }

    }
}
