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
        private Carrera carrera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            players = new Players();
            pong = new Pong();
            carrera = new Carrera();
        }

        protected override void Initialize()
        {
            estadoActual = Juego.Menu; 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            players.LoadContent(Content);
            pong.LoadContent(Content);
        }

        private void ResetMenu()
        {
            players.Reset(); 
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
                    if (players.CarreraActiva)
                    {
                        estadoActual = Juego.Carrera;
                        carrera.LoadContent(Content);
                    }
                    break;

                case Juego.Pong:
                    if (keyboardState.IsKeyDown(Keys.P))
                    {
                        estadoActual = Juego.Menu;
                        ResetMenu();
                        pong.Reset();
                        players.PongActivo = false;
                        if (pong != null)
                        {
                            pong.StopMusic();
                        }
                    }
                    else
                    {
                        pong.Update(gameTime);
                    }
                    break;

                case Juego.Quemados:
                    break;

                case Juego.Carrera:
                    if (keyboardState.IsKeyDown(Keys.P))
                    {
                        estadoActual = Juego.Menu;
                        //volver a menu
                    }
                    else
                    {
                        carrera.Update(gameTime);
                    }
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

                case Juego.Carrera:
                    GraphicsDevice.Clear(Color.Black);
                    carrera.Draw(_spriteBatch);
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
