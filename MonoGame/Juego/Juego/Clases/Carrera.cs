using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Juego.Clases
{
    public class Autos
    {
        public Texture2D autoTexture;
        public Vector2 posAuto;

        public Autos(Texture2D autoTexture)
        {
            this.autoTexture = autoTexture;
        }
        public void Movimiento()
        {
            // Lógica de movimiento del auto.
        }

        public void Acelerar()
        {
            // Lógica de aceleración.
        }

        public void Colisiones()
        {
            // Lógica de detección de colisiones.
        }
    }

    internal class Carrera
    {
        private Texture2D Titulo;
        private Texture2D fondo;
        private Texture2D[] roster = new Texture2D[17];
        private int opcionjugador1 = 0;
        private int opcionjugador2 = 0;
        Autos auto;
        Autos auto2;
        KeyboardState keyboardStatePlayer;
        float tiempoDeCambio = 0.15f;
        float tiempoTranscurrido = 0f;

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            keyboardStatePlayer = keyboardState;
            auto.Movimiento();
            auto.Colisiones();

            tiempoTranscurrido += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (tiempoTranscurrido >= tiempoDeCambio)
            {
                if (opcionjugador1 >= 0 && opcionjugador1 <= 8)
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
                tiempoTranscurrido = 0f; 
            }
        }

        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < roster.Length; i++)
            {
                roster[i] = content.Load<Texture2D>("Sprites/Carrera/roster_auto");
            }
            fondo = content.Load<Texture2D>("Sprites/Carrera/fondo_menu");
            Titulo = content.Load<Texture2D>("Sprites/Carrera/Titulo");
            auto = new Autos(content.Load<Texture2D>("Sprites/Carrera/autos"));
            auto2 = new Autos(content.Load<Texture2D>("Sprites/Carrera/autos"));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Titulo, new Vector2(20, 10), Color.White);
            List<Rectangle> sinelegir = new List<Rectangle>();
            List<Rectangle> elegidos = new List<Rectangle>();
            for (int i = 0; i < roster.Length; i++)
            {
                Rectangle sourceRect = new Rectangle(i * 45 * 3, 0, 45 * 3, 45 * 3);

                if (i < 9)
                {
                    sinelegir.Add(sourceRect);
                }
                else
                {
                    elegidos.Add(sourceRect);
                }
            }
            // autos pa elegir
            int autosPorFila = 3;
            int espaciadoVertical = 2;
            int espaciadoHorizontal = 2;
            int fila = 0;
            int columna = 0;
            for (int i = 0; i < sinelegir.Count; i++)
            {
                Vector2 posicionAuto = new Vector2(columna * (45 * 3 + espaciadoHorizontal), fila * (45 * 3 + espaciadoVertical) + 100);

                if (i == opcionjugador1)
                {
                    spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Red);
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
            }
        }
    }

}
