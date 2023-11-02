using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Juego.Clases
{
    internal class Carrera
    {
        private Texture2D Titulo;
        private Texture2D fondo;
        private Texture2D iniciar;
        SpriteFont spriteFont;
        private Texture2D[] roster = new Texture2D[9];
        private Texture2D[] autos = new Texture2D[9];
        private int opcionjugador1 = 0;
        private int opcionjugador2 = 1;
        KeyboardState keyboardStatePlayer;
        float tiempoDeCambio = 0.15f;
        float tiempoTranscurrido = 0f;
        bool Seleccionado = false;
        bool Seleccionado2 = false;
        bool IniciarCarrera = false;

        private Vector2 posicionAuto = new Vector2(20, 10); 
        private GraphicsDevice graphicsDevice;

        //movimiento auto
        //por auto
        private bool rotando = false;
        private float rotacionManual = 0f; 

        public Carrera(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState , GraphicsDevice graphicsDevice)
        {
            keyboardStatePlayer = keyboardState;

            tiempoTranscurrido += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tiempoTranscurrido >= tiempoDeCambio)
            {
                if (opcionjugador1 >= 0 && opcionjugador1 <= 8 && !Seleccionado)
                {
                    if (keyboardStatePlayer.IsKeyDown(Keys.W) && opcionjugador1 >= 3)
                    {
                        opcionjugador1 -= 3;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.S) && opcionjugador1 <= 5)
                    {
                        opcionjugador1 += 3;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.A) && opcionjugador1 % 3 > 0)
                    {
                        opcionjugador1--;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.D) && opcionjugador1 % 3 < 2)
                    {
                        opcionjugador1++;
                    }
                }
                else
                {
                    Console.WriteLine("Opción de jugador 1 no válida");
                }
                if (keyboardStatePlayer.IsKeyDown(Keys.Y))
                {
                    if (Seleccionado)
                    {
                        Seleccionado = false;
                        tiempoTranscurrido = 0f;
                    }
                    else
                    {
                        Seleccionado = true;
                        tiempoTranscurrido = 0f;
                    }
                }
                if (keyboardStatePlayer.IsKeyDown(Keys.L))
                {
                    if (Seleccionado2)
                    {
                        Seleccionado2 = false;
                        tiempoTranscurrido = 0f;
                    }
                    else
                    {
                        Seleccionado2 = true;
                        tiempoTranscurrido = 0f;
                    }
                }
                if (opcionjugador2 >= 0 && opcionjugador2 <= 8)
                {
                    if (keyboardStatePlayer.IsKeyDown(Keys.Up) && opcionjugador2 >= 3)
                    {
                        opcionjugador2 -= 3;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.Down) && opcionjugador2 <= 5)
                    {
                        opcionjugador2 += 3;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.Left) && opcionjugador2 % 3 > 0)
                    {
                        opcionjugador2--;
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.Right) && opcionjugador2 % 3 < 2)
                    {
                        opcionjugador2++;
                    }
                }
                else
                {
                    Console.WriteLine("Opción de jugador 2 no válida");
                }
                tiempoTranscurrido = 0f;
            }

            if (Seleccionado && Seleccionado2 && keyboardStatePlayer.IsKeyDown(Keys.Enter))
            {
                IniciarCarrera = true;
            }
            if (IniciarCarrera)
            {
                Vector2 velocidad = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    velocidad.Y -= 2;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    velocidad.Y += 2;
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    velocidad.X -= 2;
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    velocidad.X += 2;
                }
                if (velocidad != Vector2.Zero)
                {
                    velocidad.Normalize();
                }
                float velocidadTotal = 2f;
                velocidad *= velocidadTotal;

                posicionAuto += velocidad;
            }

        }

        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < roster.Length; i++)
            {
                roster[i] = content.Load<Texture2D>("Sprites/Carrera/roster_auto");
                autos[i] = content.Load<Texture2D>("Sprites/Carrera/autos");
            }
            fondo = content.Load<Texture2D>("Sprites/Carrera/fondo_menu");
            Titulo = content.Load<Texture2D>("Sprites/Carrera/Titulo");
            iniciar = content.Load<Texture2D>("Sprites/Carrera/iniciar");
            spriteFont = content.Load<SpriteFont>("Sprites/Carrera/textos");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //CARRERA OFICIALMENTE
            
            if (IniciarCarrera)
            {
                List<Rectangle> rectanguloautos = new List<Rectangle>();
                for (int i = 0; i < autos.Length; i++)
                {
                    Rectangle rectangulo = new Rectangle(i * 80, 0, 80, 125);
                    rectanguloautos.Add(rectangulo);
                }
                spriteBatch.Draw(autos[opcionjugador1], posicionAuto, rectanguloautos[opcionjugador1], Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0);

            }
            //seleccion del auto
            else 
            { 
                spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(Titulo, new Vector2(20, 10), Color.White);
                List<Rectangle> sinelegir = new List<Rectangle>();
                for (int i = 0; i < roster.Length; i++)
                {
                    Rectangle sourceRect = new Rectangle(i * 45 * 3, 0, 45 * 3, 45 * 3);
                    sinelegir.Add(sourceRect);
                }
                // autos pa elegir
                int autosPorFila = 3;
                int espaciadoVertical = 2;
                int espaciadoHorizontal = 2;
                int fila = 0;
                int columna = 0;
                //dibujamos los autos
                for (int i = 0; i < sinelegir.Count; i++)
                {
                    Vector2 posicionAuto = new Vector2(columna * (45 * 3 + espaciadoHorizontal), fila * (45 * 3 + espaciadoVertical) + 100);
                    if(i == opcionjugador2 && i == opcionjugador1 && Seleccionado && Seleccionado2)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Gold);
                    }
                    else if (Seleccionado && i == opcionjugador1)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], new Color(139, 90, 43)); 
                    }
                    else if (Seleccionado2 && i == opcionjugador2)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], new Color(192, 192, 192)); 
                    }
                    else if (i == opcionjugador2 && i == opcionjugador1)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Peru);
                    }
                    else if (i == opcionjugador1)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Red);
                    }
                    else if (i == opcionjugador2)
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Blue);
                    }
                    else
                    {
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.White);
                    }
                    columna++;
                    if (columna >= autosPorFila)
                    {
                        columna = 0;
                        fila++;
                    }
                    if (Seleccionado && Seleccionado2)
                    {
                        spriteBatch.DrawString(spriteFont, "INICIAR CARRERA", new Vector2(460, 250), Color.White);
                        spriteBatch.Draw(iniciar, new Vector2(530, 360), null, Color.White, 0f, Vector2.Zero, 3.5f, SpriteEffects.None, 0);
                    }
                }
            }
        }
    }

}
