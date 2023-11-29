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
            Fighters,
            Carrera,
        }

        private Juego estadoActual;
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        private Players players;
        private Pong pong;
        private Carrera carrera;
        private Fighters fighters;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            players = new Players();
            pong = new Pong();
            fighters = new Fighters();
        }

        protected override void Initialize()
        {
            estadoActual = Juego.Menu;
            base.Initialize();
            carrera = new Carrera(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Variables._graphics = GraphicsDevice;
            Variables._spritebatch = _spriteBatch; 
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
                    if (players.Fighters)
                    {
                        estadoActual = Juego.Fighters;
                        fighters.LoadContent(Content);
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

                case Juego.Fighters:
                    if (keyboardState.IsKeyDown(Keys.P))
                    {
                        estadoActual = Juego.Menu;
                        ResetMenu();
                        fighters.Reset();
                        players.Fighters = false;
                    }
                    else
                    {
                        fighters.Update(gameTime);
                    }
                    break;

                case Juego.Carrera:
                    if (keyboardState.IsKeyDown(Keys.P))
                    {
                        estadoActual = Juego.Menu;
                        ResetMenu();
                        carrera.Reset();
                        players.CarreraActiva = false;
                    }
                    else
                    {
                        carrera.Update(gameTime, Keyboard.GetState(), GraphicsDevice);
                    }
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
                case Juego.Fighters:
                    GraphicsDevice.Clear(Color.Black);
                    fighters.Draw(_spriteBatch);
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