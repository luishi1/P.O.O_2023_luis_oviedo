using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite;
using MonoGame.Aseprite.Tilemaps;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

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
        private GraphicsDevice graphicsDevice;

        //movimiento auto
        //por auto
        private Vector2 posicionAuto;
        private Vector2 posicionAuto2;
        Vector2 spriteorigin;
        Vector2 spriteorigin2;
        Rectangle spriteRectangle;
        Rectangle spriteRectangle2;
        float rotation;
        float rotation2;
        Vector2 spriteVelocity;
        Vector2 spriteVelocity2;
        float tangentialVelocity = 1.5f;
        float friction = 0.04f;

        //WEAS
        TileMapManager Map;

        public Carrera(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            posicionAuto = new Vector2(400, 520);
            posicionAuto2 = new Vector2(400, 540);
            Map = new TileMapManager();
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, GraphicsDevice graphicsDevice)
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
                if (opcionjugador2 >= 0 && opcionjugador2 <= 8 && !Seleccionado2)
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
                //Auto 1
                posicionAuto = spriteVelocity + posicionAuto;
                spriteRectangle = new Rectangle((int)posicionAuto.X, (int)posicionAuto.Y, autos[opcionjugador1].Width, autos[opcionjugador1].Height);
                if (Keyboard.GetState().IsKeyDown(Keys.D)) rotation += 0.1f;
                if (Keyboard.GetState().IsKeyDown(Keys.A)) rotation -= 0.1f;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    spriteVelocity.X = (float)Math.Cos(rotation) * tangentialVelocity;
                    spriteVelocity.Y = (float)Math.Sin(rotation) * tangentialVelocity;
                }
                else if (spriteVelocity != Vector2.Zero)
                {
                    float i = spriteVelocity.X;
                    float j = spriteVelocity.Y;
                    spriteVelocity.X = i -= friction * i;
                    spriteVelocity.Y = j -= friction * j;
                }

                //Auto 2
                posicionAuto2 = spriteVelocity2 + posicionAuto2;
                spriteRectangle2 = new Rectangle((int)posicionAuto2.X, (int)posicionAuto2.Y, autos[opcionjugador2].Width, autos[opcionjugador2].Height);
                if (Keyboard.GetState().IsKeyDown(Keys.Right)) rotation2 += 0.1f;
                if (Keyboard.GetState().IsKeyDown(Keys.Left)) rotation2 -= 0.1f;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    spriteVelocity2.X = (float)Math.Cos(rotation2) * tangentialVelocity;
                    spriteVelocity2.Y = (float)Math.Sin(rotation2) * tangentialVelocity;
                }
                else if (spriteVelocity2 != Vector2.Zero)
                {
                    float i = spriteVelocity2.X;
                    float j = spriteVelocity2.Y;
                    spriteVelocity2.X = i -= friction * i;
                    spriteVelocity2.Y = j -= friction * j;
                }

                ColisionCapas();
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
                Map.Draw();
                spriteBatch.DrawString(spriteFont, $"Auto 1: Tile ({PosicionJugadorTile(posicionAuto).X}, {PosicionJugadorTile(posicionAuto).Y})", new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(spriteFont, $"Auto 2: Tile ({PosicionJugadorTile(posicionAuto2).X}, {PosicionJugadorTile(posicionAuto2).Y})", new Vector2(10, 30), Color.White);
                List<Rectangle> rectanguloautos = new List<Rectangle>();
                for (int i = 0; i < autos.Length; i++)
                {
                    Rectangle rectangulo = new Rectangle(i * 125, 0, 125, 75);
                    rectanguloautos.Add(rectangulo);
                }
                spriteBatch.Draw(autos[opcionjugador1], posicionAuto, rectanguloautos[opcionjugador1], Color.White, rotation, spriteorigin, 0.2f, SpriteEffects.None, 0);
                spriteBatch.Draw(autos[opcionjugador2], posicionAuto2, rectanguloautos[opcionjugador2], Color.White, rotation2, spriteorigin2, 0.2f, SpriteEffects.None, 0);
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
                    if (i == opcionjugador2 && i == opcionjugador1 && Seleccionado && Seleccionado2)
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

        private Point PosicionJugadorTile(Vector2 posicionJugador)
        {
            int columna = MathHelper.Clamp((int)(posicionJugador.X / 16), 0, Map.ArchivoMap.CanvasWidth - 1);
            int fila = MathHelper.Clamp((int)(posicionJugador.Y / 16), 0, Map.ArchivoMap.CanvasHeight - 1);

            return new Point(columna, fila);
        }


        private void ColisionCapas()
        {
            TilemapLayer capaPista = Map.Mapa["Pista"];
            TilemapLayer capaSuelo = Map.Mapa["Suelo"];
            TilemapLayer CapaMedio = Map.Mapa["MetaMedio"];
            TilemapLayer CapaFinal = Map.Mapa["MetaFinal"];

            // Obtener las posiciones de los jugadores en términos de tiles
            Point posicionJugador1 = PosicionJugadorTile(posicionAuto);
            Point posicionJugador2 = PosicionJugadorTile(posicionAuto2);

            if (!capaPista.GetTile(posicionJugador1.X, posicionJugador1.Y).IsEmpty)
            {

            }
            else if (!capaSuelo.GetTile(posicionJugador1.X, posicionJugador1.Y).IsEmpty)
            {
                spriteVelocity *= 0.5f;
            }
            else if (!CapaMedio.GetTile(posicionJugador1.X, posicionJugador1.Y).IsEmpty || !CapaFinal.GetTile(posicionJugador1.X, posicionJugador1.Y).IsEmpty)
            {

            }

            if (!capaPista.GetTile(posicionJugador2.X, posicionJugador2.Y).IsEmpty)
            {

            }
            else if (!capaSuelo.GetTile(posicionJugador2.X, posicionJugador2.Y).IsEmpty)
            {
                spriteVelocity2 *= 0.5f;
            }
            else if (!CapaMedio.GetTile(posicionJugador2.X, posicionJugador2.Y).IsEmpty || !CapaFinal.GetTile(posicionJugador2.X, posicionJugador2.Y).IsEmpty)
            {

            }
        }

        public void Reset()
        {
            opcionjugador1 = 0;
            opcionjugador2 = 1;
            tiempoTranscurrido = 0f;
            Seleccionado = false;
            Seleccionado2 = false;
            IniciarCarrera = false;
            posicionAuto = new Vector2(400, 520);
            posicionAuto2 = new Vector2(400, 540);
            spriteVelocity = Vector2.Zero;
            spriteVelocity2 = Vector2.Zero;
        }

    }
}
