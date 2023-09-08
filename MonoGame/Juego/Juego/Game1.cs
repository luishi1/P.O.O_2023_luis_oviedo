using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Juego
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _pruebasPosition;
        private Texture2D[] ProtaCamUp;
        private Texture2D[] ProtaCamDown;
        private Texture2D[] ProtaCamLeft;
        private Texture2D[] ProtaCamRight;
        private int frameactual = 0;
        private int frameWidth;
        private float animationTimer = 0f;
        private float frameDuration = 0.1f;
        private Direction currentDirection = Direction.Right;
        private Direction lastDirection = Direction.Right;

        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _pruebasPosition = new Vector2(100, 100);

            ProtaCamUp = new Texture2D[3];
            ProtaCamUp[0] = Content.Load<Texture2D>("Sprites/pc_up1");
            ProtaCamUp[1] = Content.Load<Texture2D>("Sprites/pc_up2");
            ProtaCamUp[2] = Content.Load<Texture2D>("Sprites/pc_up3");

            ProtaCamDown = new Texture2D[3];
            ProtaCamDown[0] = Content.Load<Texture2D>("Sprites/pc_down1");
            ProtaCamDown[1] = Content.Load<Texture2D>("Sprites/pc_down2");
            ProtaCamDown[2] = Content.Load<Texture2D>("Sprites/pc_down3");

            ProtaCamLeft = new Texture2D[3];
            ProtaCamLeft[0] = Content.Load<Texture2D>("Sprites/pc_left1");
            ProtaCamLeft[1] = Content.Load<Texture2D>("Sprites/pc_left2");
            ProtaCamLeft[2] = Content.Load<Texture2D>("Sprites/pc_left3");

            ProtaCamRight = new Texture2D[3];
            ProtaCamRight[0] = Content.Load<Texture2D>("Sprites/pc_right1");
            ProtaCamRight[1] = Content.Load<Texture2D>("Sprites/pc_right2");
            ProtaCamRight[2] = Content.Load<Texture2D>("Sprites/pc_right3");

            frameWidth = ProtaCamRight[0].Width / 3;
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            bool isMoving = false; // Variable para rastrear si el personaje se está moviendo

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                currentDirection = Direction.Up;
                _pruebasPosition.Y -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                currentDirection = Direction.Down;
                _pruebasPosition.Y += 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentDirection = Direction.Left;
                _pruebasPosition.X -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                currentDirection = Direction.Right;
                _pruebasPosition.X += 2;
                isMoving = true;
            }

            if (currentDirection != lastDirection)
            {
                lastDirection = currentDirection;
            }

            if (isMoving)
            {
                animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimer > frameDuration)
                {
                    frameactual = (frameactual + 1) % 3;
                    animationTimer = 0f;
                }
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            _spriteBatch.Begin();

            // Dibuja la animación en función de la dirección actual o la última dirección si no se está moviendo
            switch (currentDirection)
            {
                case Direction.Up:
                    _spriteBatch.Draw(ProtaCamUp[frameactual], _pruebasPosition, Color.White);
                    break;
                case Direction.Down:
                    _spriteBatch.Draw(ProtaCamDown[frameactual], _pruebasPosition, Color.White);
                    break;
                case Direction.Left:
                    _spriteBatch.Draw(ProtaCamLeft[frameactual], _pruebasPosition, Color.White);
                    break;
                case Direction.Right:
                    _spriteBatch.Draw(ProtaCamRight[frameactual], _pruebasPosition, Color.White);
                    break;
                default:

                    switch (lastDirection)
                    {
                        case Direction.Up:
                            _spriteBatch.Draw(ProtaCamUp[1], _pruebasPosition, Color.White);
                            break;
                        case Direction.Down:
                            _spriteBatch.Draw(ProtaCamDown[1], _pruebasPosition, Color.White);
                            break;
                        case Direction.Left:
                            _spriteBatch.Draw(ProtaCamLeft[1], _pruebasPosition, Color.White);
                            break;
                        case Direction.Right:
                            _spriteBatch.Draw(ProtaCamRight[1], _pruebasPosition, Color.White);
                            break;
                    }
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        static void Main(string[] args)
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
