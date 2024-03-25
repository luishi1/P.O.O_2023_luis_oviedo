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
        private MenuPlayers MenuInicial;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            MenuInicial = new MenuPlayers( new Vector2(212,471) , "Sprites/Players/Player1", new Vector2(212, 471) , "Sprites/Players/Player2") ;
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
            pong.LoadContent(Content);
            MenuInicial.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            MenuInicial.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (estadoActual)
            {
                case Juego.Menu:
                    MenuInicial.Draw(_spriteBatch);
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
        }

        static void Main(string[] args)
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}