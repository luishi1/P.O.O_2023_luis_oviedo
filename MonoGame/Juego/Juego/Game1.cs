using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace Juego
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Encarga de dibujar las texturas en pantalla.
        private SpriteBatch _spriteBatch;
        // Crea la variable de textura 2D "pruebas".
        private Texture2D _pruebasTexture;
        // Crea la variable de posición de "pruebas"
        private Vector2 _pruebasPosition;
        // Crea la variable de la velocidad en la que se moverá el sprite.
        private Vector2 _pruebasSpeed = new Vector2(3, 3);

        private Texture2D _manzanaTexture;
        private Vector2 _manzanaPosition;

        private Song _backgroundMusic;

        private bool _manzanaTocada = false; // Bandera para controlar si se tocó la manzana


        //mostrar todos los sprites

        private Texture2D charaset;
        // A timer that stores milliseconds.
        float timer;
        // An int that is the threshold for the timer.
        int threshold;
        // A Rectangle array that stores sourceRectangles for animations.
        Rectangle[] sourceRectangles;
        // These bytes tell the spriteBatch.Draw() what sourceRectangle to display.
        byte previousAnimationIndex;
        byte currentAnimationIndex;


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
            _pruebasTexture = Content.Load<Texture2D>("Sprites/Pf1");
            _pruebasPosition = new Vector2(100, 100);
            charaset = Content.Load<Texture2D>("Sprites/charaset");
            _manzanaTexture = Content.Load<Texture2D>("Sprites/SpriteTrainer");
            _manzanaPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - _manzanaTexture.Width / 2, GraphicsDevice.Viewport.Height / 2 - _manzanaTexture.Height / 2);

            timer = 0;
            threshold = 250;
            sourceRectangles = new Rectangle[3];
            sourceRectangles[0] = new Rectangle(0, 128, 48, 64);
            sourceRectangles[1] = new Rectangle(48, 128, 48, 64);
            sourceRectangles[2] = new Rectangle(96, 128, 48, 64);
            previousAnimationIndex = 2;
            currentAnimationIndex = 1;

        }

        protected override void Update(GameTime gameTime)
        {
            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();

            // Se ejecuta cuando la variable _manzanaTocada es "false".
            if (!_manzanaTocada)
            {
                // Movimiento del sprite "pruebas" controlado por las flechas del teclado

                // Cuando se aprieta la tecla "left" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Left))
                    // Se resta la posición actual en "X" por el valor de la velocidad. Si velocidad es 2 se restan 2 posiciones.
                    _pruebasPosition.X -= 2;

                // Cuando se aprieta la tecla "right" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Right))
                    // Se suma la posición actual en "X" por el valor de la velocidad.
                    _pruebasPosition.X += 2;

                // Cuando se aprieta la tecla "up" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Up))
                    // Se resta la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y -= 2;

                // Cuando se aprieta la tecla "down" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Down))
                    // Se suma la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y += 2;

                // Verificar colisión con la manzana
                Rectangle pruebasRectangle = new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, _pruebasTexture.Width, _pruebasTexture.Height);
                // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
                Rectangle manzanaRectangle = new Rectangle((int)_manzanaPosition.X, (int)_manzanaPosition.Y, _manzanaTexture.Width, _manzanaTexture.Height);
                // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.

                if (pruebasRectangle.Intersects(manzanaRectangle))
                {
                    _manzanaTocada = true;
                }
            }

            if (timer > threshold)
            {
                if (currentAnimationIndex == 1)
                {
                    if (previousAnimationIndex == 0)
                    {
                        currentAnimationIndex = 2;
                    }
                    else
                    {
                        currentAnimationIndex = 0;
                    }
                    previousAnimationIndex = currentAnimationIndex;
                }
                else
                {
                    currentAnimationIndex = 1;
                }
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.
            _spriteBatch.Begin();
            _spriteBatch.Draw(charaset, new Vector2(0, 100), sourceRectangles[currentAnimationIndex], Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);

        }


    }
}