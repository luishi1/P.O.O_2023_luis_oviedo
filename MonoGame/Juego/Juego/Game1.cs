using Juego.Clases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Juego
{
    public class Game1 : Game
    {
        public enum Juego
        {
            Menu,
            Pong,
            BudokaiBrawl,
            Quemados,
            Carrera,
        }

        private Juego estadoActual;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Players players;
        private Pong pong;
        private bool returnToMenu = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            // Pantalla resolución
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            players = new Players();
            pong = new Pong();
        }

        protected override void Initialize()
        {
            estadoActual = Juego.Menu; // Comienza en el menú
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            players.LoadContent(Content);
            pong.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            switch (estadoActual)
            {
                case Juego.Menu:
                    KeyboardState keyboardStateJugador1 = Keyboard.GetState();
                    KeyboardState keyboardStateJugador2 = Keyboard.GetState();
                    bool isMovingJugador1 = players.UpdateJugador1(keyboardStateJugador1, gameTime);
                    bool isMovingJugador2 = players.UpdateJugador2(keyboardStateJugador2, gameTime);
                    players.Update(gameTime);

                    if (players.PongActivo)
                    {
                        estadoActual = Juego.Pong;
                        pong.LoadContent(Content);
                    }
                    break;

                case Juego.Pong:
                    pong.Update(gameTime);

                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        returnToMenu = true;
                    }
                    if (returnToMenu)
                    {
                        estadoActual = Juego.Menu;
                        returnToMenu = false;
                    }
                    break;

                case Juego.Quemados:
                    break;

                case Juego.Carrera:
                    break;

                case Juego.BudokaiBrawl:
                    break;

                default:
                    break;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            switch (estadoActual)
            {
                case Juego.Menu:
                    players.Draw(_spriteBatch);
                    break;

                case Juego.Pong:
                    GraphicsDevice.Clear(Color.Black);
                    pong.Draw(_spriteBatch);
                    break;

                default:
                    break;
            }

            _spriteBatch.End();
        }

        static void Main(string[] args)
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
