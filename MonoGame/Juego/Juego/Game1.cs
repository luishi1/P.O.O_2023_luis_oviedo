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
        private Vector2 _jugador1Position;
        private Texture2D[] ProtaCamUp;
        private Texture2D[] ProtaCamDown;
        private Texture2D[] ProtaCamLeft;
        private Texture2D[] ProtaCamRight;
        private int frameactualJugador1 = 0;
        private Vector2 _jugador2Position;
        private Texture2D[] ProtaCamUpJugador2;
        private Texture2D[] ProtaCamDownJugador2;
        private Texture2D[] ProtaCamLeftJugador2;
        private Texture2D[] ProtaCamRightJugador2;
        private int frameactualJugador2 = 0;
        private int frameWidth;
        private float animationTimerJugador1 = 0f;
        private float animationTimerJugador2 = 0f;
        private float frameDuration = 0.1f;
        private Direction currentDirectionJugador1 = Direction.Right;
        private Direction lastDirectionJugador1 = Direction.Right;
        private Direction currentDirectionJugador2 = Direction.Right;
        private Direction lastDirectionJugador2 = Direction.Right;
        private bool jugador2Activo = false;  // Variable para controlar si el jugador 2 está activo

        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private KeyboardState lastKeyboardStateJugador1;
        private KeyboardState lastKeyboardStateJugador2;

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

            _jugador1Position = new Vector2(100, 100);
            _jugador2Position = new Vector2(200, 200);

            // Cargar los sprites para el Jugador 1
            ProtaCamUp = LoadSprites("Sprites", "player1_up");
            ProtaCamDown = LoadSprites("Sprites", "player1_down");
            ProtaCamLeft = LoadSprites("Sprites", "player1_left");
            ProtaCamRight = LoadSprites("Sprites", "player1_right");

            // Cargar los sprites para el Jugador 2
            ProtaCamUpJugador2 = LoadSprites("Sprites", "player2_up");
            ProtaCamDownJugador2 = LoadSprites("Sprites", "player2_down");
            ProtaCamLeftJugador2 = LoadSprites("Sprites", "player2_left");
            ProtaCamRightJugador2 = LoadSprites("Sprites", "player2_right");

            frameWidth = ProtaCamRight[0].Width / 4;
        }

        private Texture2D[] LoadSprites(string ruta, string jugadormov)
        {
            Texture2D[] sprites = new Texture2D[4];
            for (int i = 0; i < 4; i++)
            {
                string assetPath = $"{ruta}/{jugadormov}{i + 1}";
                sprites[i] = Content.Load<Texture2D>(assetPath);
            }
            return sprites;
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardStateJugador1 = Keyboard.GetState();
            KeyboardState keyboardStateJugador2 = Keyboard.GetState();

            bool isMovingJugador1 = false;
            bool isMovingJugador2 = false;

            // Jugador 1
            if (keyboardStateJugador1.IsKeyDown(Keys.Up))
            {
                currentDirectionJugador1 = Direction.Up;
                _jugador1Position.Y -= 2;
                isMovingJugador1 = true;
            }
            else if (keyboardStateJugador1.IsKeyDown(Keys.Down))
            {
                currentDirectionJugador1 = Direction.Down;
                _jugador1Position.Y += 2;
                isMovingJugador1 = true;
            }
            else if (keyboardStateJugador1.IsKeyDown(Keys.Left))
            {
                currentDirectionJugador1 = Direction.Left;
                _jugador1Position.X -= 2;
                isMovingJugador1 = true;
            }
            else if (keyboardStateJugador1.IsKeyDown(Keys.Right))
            {
                currentDirectionJugador1 = Direction.Right;
                _jugador1Position.X += 2;
                isMovingJugador1 = true;
            }

            // Jugador 2
            if (keyboardStateJugador2.IsKeyDown(Keys.W))
            {
                currentDirectionJugador2 = Direction.Up;
                _jugador2Position.Y -= 2;
                isMovingJugador2 = true;
            }
            else if (keyboardStateJugador2.IsKeyDown(Keys.S))
            {
                currentDirectionJugador2 = Direction.Down;
                _jugador2Position.Y += 2;
                isMovingJugador2 = true;
            }
            else if (keyboardStateJugador2.IsKeyDown(Keys.A))
            {
                currentDirectionJugador2 = Direction.Left;
                _jugador2Position.X -= 2;
                isMovingJugador2 = true;
            }
            else if (keyboardStateJugador2.IsKeyDown(Keys.D))
            {
                currentDirectionJugador2 = Direction.Right;
                _jugador2Position.X += 2;
                isMovingJugador2 = true;
            }

            if (keyboardStateJugador1.IsKeyDown(Keys.Enter) && !lastKeyboardStateJugador1.IsKeyDown(Keys.Enter))
            {
                jugador2Activo = true;
            }

            if (currentDirectionJugador1 != lastDirectionJugador1)
            {
                lastDirectionJugador1 = currentDirectionJugador1;
            }

            if (currentDirectionJugador2 != lastDirectionJugador2)
            {
                lastDirectionJugador2 = currentDirectionJugador2;
            }

            if (isMovingJugador1)
            {
                animationTimerJugador1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimerJugador1 > frameDuration)
                {
                    frameactualJugador1 = (frameactualJugador1 + 1) % 4;
                    animationTimerJugador1 = 0f;
                }
            }

            if (jugador2Activo && isMovingJugador2)
            {
                animationTimerJugador2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimerJugador2 > frameDuration)
                {
                    frameactualJugador2 = (frameactualJugador2 + 1) % 4;
                    animationTimerJugador2 = 0f;
                }
            }

            lastKeyboardStateJugador1 = keyboardStateJugador1;
            lastKeyboardStateJugador2 = keyboardStateJugador2;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            _spriteBatch.Begin();

            DrawPlayer(_jugador1Position, ProtaCamUp, ProtaCamDown, ProtaCamLeft, ProtaCamRight, frameactualJugador1, currentDirectionJugador1);

            if (jugador2Activo)
            {
                DrawPlayer(_jugador2Position, ProtaCamUpJugador2, ProtaCamDownJugador2, ProtaCamLeftJugador2, ProtaCamRightJugador2, frameactualJugador2, currentDirectionJugador2);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawPlayer(Vector2 position, Texture2D[] up, Texture2D[] down, Texture2D[] left, Texture2D[] right, int frameactual, Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    _spriteBatch.Draw(up[frameactual], position, Color.White);
                    break;
                case Direction.Down:
                    _spriteBatch.Draw(down[frameactual], position, Color.White);
                    break;
                case Direction.Left:
                    _spriteBatch.Draw(left[frameactual], position, Color.White);
                    break;
                case Direction.Right:
                    _spriteBatch.Draw(right[frameactual], position, Color.White);
                    break;
                default:
                    _spriteBatch.Draw(right[frameactual], position, Color.White);
                    break;
            }
        }

        static void Main(string[] args)
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
