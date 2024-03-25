using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite;
using MonoGame.Aseprite.Tilemaps;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Reflection.Metadata;

namespace Juego.Clases
{
    internal class Carrera
    {
        //texturas
        private Texture2D Titulo;
        private Texture2D fondo;
        private Texture2D[] iniciar = new Texture2D[18];
        private Texture2D fondomapa;
        private Texture2D division;
        SpriteFont spriteFont;
        private Texture2D[] roster = new Texture2D[9];
        private Texture2D[] autos = new Texture2D[9];
        private Texture2D[] mapasid = new Texture2D[4];
        private Texture2D[] vueltasposibles = new Texture2D[5];
        private Texture2D[] fondoforo = new Texture2D[5];
        KeyboardState keyboardStatePlayer;


        //Bools y contadores
        private int opcionjugador1 = 0;
        private int opcionjugador2 = 1;
        private int opcionmapa;
        int ultimomapaelegiodo;
        private int opcionvueltas = 0;
        private int vueltasadar = 0;
        bool Seleccionado = false;
        bool Seleccionado2 = false;
        bool Mapaelegido = false;
        bool Vueltaselegidas = false;
        public bool IniciarCarrera = false;
        public bool configuracion = false;
        public bool mediavuelta1 = false;
        public bool mediavuelta2 = false;
        public bool Vueltacompleta = false;
        int Vueltasjugador1 = 0;
        int Vueltasjugador2 = 0;
        public bool ESTADOMENU = true;
        public bool AnuncionGanador = false;
        bool SemaforoActivado = true;
        private float tiempoCambioSemaforo = 1f;
        private float tiempoTranscurridoSemaforo = 0f;
        private int indiceImagenSemaforo = 0;
        float tiempoDeCambio = 0.15f;
        float tiempoTranscurrido = 0f;
        float tiempoCambioImagen = 0.1f;
        int indiceImagenActual = 0;

        //movimiento auto
        float tangentialVelocity = 2f;
        float friction = 0.03f;
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

        //OTROS
        TileMapManager Map;
        Viewport defaultview;
        Viewport Leftview;
        Viewport Rightview;
        Camera cameraOne;
        Camera cameraTwo;
        float zoomFactor = 1.3f;
        private GraphicsDevice graphicsDevice;

        

        //MUSICA
        private Song musicaMenu;
        private Song musicaCarrera;
        private SoundEffect sonidoMovimiento;
        private Song sonidoSemaforo;
        private bool sonidoSemaforoReproducido = false;


        public Carrera(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            Map = new TileMapManager();
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, GraphicsDevice graphicsDevice)
        {
            keyboardStatePlayer = keyboardState;
            tiempoTranscurrido += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //ELEGIR AUTO DE CARRERA 
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(musicaMenu);
            }

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
                    }
                    else
                    {
                        Seleccionado = true;
                    }
                }
                if (keyboardStatePlayer.IsKeyDown(Keys.L))
                {
                    if (Seleccionado2)
                    {
                        Seleccionado2 = false;
                    }
                    else
                    {
                        Seleccionado2 = true;
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


                //ELEGIR EL MAPA QUE SE VA JUGAR
                if (opcionmapa >= 0 && opcionmapa <= 3 && !Mapaelegido && Seleccionado && Seleccionado2)
                {
                    if (keyboardStatePlayer.IsKeyDown(Keys.A))
                    {
                        opcionmapa--;
                        if (opcionmapa < 0)
                        {
                            opcionmapa = 3;
                        }
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.D))
                    {
                        opcionmapa++;
                        if (opcionmapa > 3)
                        {
                            opcionmapa = 0;
                        }
                    }
                    ultimomapaelegiodo = opcionmapa;
                }

                switch (opcionmapa)
                {
                    case 0:
                        Map.MapaSeleccionado = "C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera//MapaPista01.aseprite";
                        break;
                    case 1:
                        Map.MapaSeleccionado = "C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera//MapaPista02.aseprite";
                        break;
                    case 2:
                        Map.MapaSeleccionado = "C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera//MapaPista03.aseprite";
                        break;
                    case 3:
                        Map.MapaSeleccionado = "C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera//MapaPista04.aseprite";
                        break;
                    default:
                        Map.MapaSeleccionado = "C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera//MapaPista01.aseprite";
                        break;
                }

                if (keyboardStatePlayer.IsKeyDown(Keys.M))
                {
                    if (Mapaelegido)
                    {
                        Mapaelegido = false;
                    }
                    else
                    {
                        Mapaelegido = true;
                    }
                    PosicionarAutosMapas(opcionmapa);
                }

                if (Mapaelegido)
                {
                    Map.LoadContent();
                }

                //ELEGIR LA CANTIDAD DE VUELTAS POSIBLES
                if (opcionvueltas >= 0 && opcionvueltas <= 4 && !Vueltaselegidas && Seleccionado && Seleccionado2)
                {
                    if (keyboardStatePlayer.IsKeyDown(Keys.Left))
                    {
                        opcionvueltas--;
                        if (opcionvueltas < 0)
                        {
                            opcionvueltas = 4;
                        }
                    }
                    else if (keyboardStatePlayer.IsKeyDown(Keys.Right))
                    {
                        opcionvueltas++;
                        if (opcionvueltas > 4)
                        {
                            opcionvueltas = 0;
                        }
                    }

                    vueltasadar = opcionvueltas + 1;
                }
                if (keyboardStatePlayer.IsKeyDown(Keys.Space))
                {
                    if (Vueltaselegidas)
                    {
                        Vueltaselegidas = false;
                    }
                    else
                    {
                        Vueltaselegidas = true;
                    }
                }

                //"GIF" INICIAR
                if (tiempoTranscurrido > tiempoCambioImagen)
                {
                    indiceImagenActual = (indiceImagenActual + 1) % iniciar.Length;
                }
                tiempoTranscurrido = 0f;

            }

            //UNA VeZ TODO SELECCIONADO ACTIVAR EL BOTON DE INICIAR PARA INICIAR LA CARRERA
            if (Seleccionado && Seleccionado2 && Mapaelegido && Vueltaselegidas && !sonidoSemaforoReproducido && keyboardStatePlayer.IsKeyDown(Keys.Enter))
            {
                IniciarCarrera = true;
                MediaPlayer.Play(sonidoSemaforo);
                sonidoSemaforoReproducido = true;
            }

            tiempoTranscurridoSemaforo += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (IniciarCarrera && !AnuncionGanador)
            {
                if (SemaforoActivado && tiempoTranscurridoSemaforo >= tiempoCambioSemaforo)
                {
                    indiceImagenSemaforo = (indiceImagenSemaforo + 1) % fondoforo.Length;
                    tiempoTranscurridoSemaforo = 0f;
                    if (indiceImagenSemaforo == fondoforo.Length - 1)
                    {
                        SemaforoActivado = false;
                        MediaPlayer.Play(musicaCarrera);
                    }
                }
                if (!SemaforoActivado)
                {
                    posicionAuto = spriteVelocity + posicionAuto;
                    spriteRectangle = new Rectangle((int)posicionAuto.X, (int)posicionAuto.Y, autos[opcionjugador1].Width, autos[opcionjugador1].Height);
                    if (Keyboard.GetState().IsKeyDown(Keys.D)) rotation += 0.1f;
                    if (Keyboard.GetState().IsKeyDown(Keys.A)) rotation -= 0.1f;
                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        sonidoMovimiento.Play();
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
                        sonidoMovimiento.Play();
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
                    cameraOne.Update(posicionAuto, zoomFactor);
                    cameraTwo.Update(posicionAuto2, zoomFactor);
                    ColisionTiles();

                    if (Vueltasjugador1 == vueltasadar || Vueltasjugador2 == vueltasadar)
                    {
                        AnuncionGanador = true;
                    }
                }

            }
        }

        public void PosicionarAutosMapas(int opciondelmapa)
        {
            switch (opciondelmapa)
            {
                case 0:
                    posicionAuto = new Vector2(514, 562);
                    posicionAuto2 = new Vector2(514, 594);
                    break;
                case 1:
                    posicionAuto = new Vector2(529, 626);
                    posicionAuto2 = new Vector2(529, 658);
                    break;
                case 2:
                    posicionAuto = new Vector2(321, 579);
                    posicionAuto2 = new Vector2(321, 610);
                    break;
                case 3:
                    posicionAuto = new Vector2(529, 626);
                    posicionAuto2 = new Vector2(529, 658);
                    break;
                default:
                    posicionAuto = new Vector2(0, 0);
                    posicionAuto2 = new Vector2(0, 10);
                    break;
            }
        }


        public void LoadContent(ContentManager content)
        {

            defaultview = graphicsDevice.Viewport;
            Leftview = defaultview;
            Rightview = defaultview;
            Leftview.Width = Leftview.Width / 2;
            Rightview.Width = Rightview.Width / 2;
            Rightview.X = Leftview.Width;
            cameraOne = new Camera();
            cameraTwo = new Camera();

            for (int i = 0; i < roster.Length; i++)
            {
                roster[i] = content.Load<Texture2D>("Sprites/Carrera/roster_auto");
                autos[i] = content.Load<Texture2D>("Sprites/Carrera/autos");
            }
            for (int i = 0; i < mapasid.Length; i++)
            {
                mapasid[i] = content.Load<Texture2D>("Sprites/Carrera/mapaselector");
            }
            for (int i = 0; i < vueltasposibles.Length; i++)
            {
                vueltasposibles[i] = content.Load<Texture2D>("Sprites/Carrera/numeros");
            }
            for (int i = 0; i < iniciar.Length; i++)
            {
                iniciar[i] = content.Load<Texture2D>("Sprites/Carrera/iniciar");
            }
            for (int i = 0; i < fondoforo.Length; i++)
            {
                fondoforo[i] = content.Load<Texture2D>("Sprites/Carrera/fodoforo");
            }
            fondo = content.Load<Texture2D>("Sprites/Carrera/fondo_menu");
            Titulo = content.Load<Texture2D>("Sprites/Carrera/Titulo");
            fondomapa = content.Load<Texture2D>("Mapas/MapaCarrera/fondomapa");
            division = content.Load<Texture2D>("Sprites/Carrera/limite");
            spriteFont = content.Load<SpriteFont>("Sprites/Carrera/textos");

            musicaMenu = content.Load<Song>("Sprites/Carrera/MusicaMenu");
            musicaCarrera = content.Load<Song>("Sprites/Carrera/MusicaCarrera");
            sonidoMovimiento = content.Load<SoundEffect>("Sprites/Carrera/AutoMotor");
            sonidoSemaforo = content.Load<Song>("Sprites/Carrera/InicioContadorCarreraYaGOOHYEAHLOCURA");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IniciarCarrera)
            {
                graphicsDevice.Viewport = Leftview;
                graphicsDevice.Clear(new Color(20, 160, 46));
                Camaradibujo(cameraOne, spriteBatch);
                graphicsDevice.Viewport = Rightview;
                Camaradibujo(cameraTwo, spriteBatch);
                graphicsDevice.Viewport = defaultview;
                spriteBatch.Begin();
                spriteBatch.Draw(division, new Vector2(400, 0), Color.White);
                List<Rectangle> sema = new List<Rectangle>();
                for (int i = 0; i < fondoforo.Length; i++)
                {
                    Rectangle semafororect = new Rectangle(i * 800, 0, 800, 600);
                    sema.Add(semafororect);
                }
                if (SemaforoActivado)
                {
                    spriteBatch.Draw(fondoforo[indiceImagenSemaforo], new Vector2(0, 0), sema[indiceImagenSemaforo], Color.White);
                }
                //spriteBatch.DrawString(spriteFont, $"Auto 1: X={posicionAuto.X}, Y={posicionAuto.Y}", new Vector2(10, 10), Color.White);
                //spriteBatch.DrawString(spriteFont, $"Auto 2: X={posicionAuto2.X}, Y={posicionAuto2.Y}", new Vector2(10, 30), Color.White);

                spriteBatch.End();

                float scale = 1.2f;

                spriteBatch.Begin();

                if (AnuncionGanador)
                {
                    if (Vueltasjugador1 == vueltasadar)
                    {
                        spriteBatch.DrawString(spriteFont, "GANADOR JUGADOR 1", new Vector2(200, 100), Color.Red, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        scale = 1f;
                        spriteBatch.DrawString(spriteFont, "APRIETE 'E' PARA VOLVER AL MENU DE AUTOS ", new Vector2(100, 170), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        spriteBatch.DrawString(spriteFont, "APRIETE 'R' PARA REINICIAR LA CARRERA ", new Vector2(100, 240), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        spriteBatch.DrawString(spriteFont, "APRIETE 'P' PARA SALIR DEL JUEGO ", new Vector2(100, 310), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                    }
                    if (Vueltasjugador2 == vueltasadar)
                    {
                        spriteBatch.DrawString(spriteFont, "GANADOR JUGADOR 2", new Vector2(200, 100), Color.SkyBlue, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        scale = 1f;
                        spriteBatch.DrawString(spriteFont, "APRIETE 'E' PARA VOLVER AL MENU DE AUTOS ", new Vector2(100, 170), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        spriteBatch.DrawString(spriteFont, "APRIETE 'R' PARA REINICIAR LA CARRERA ", new Vector2(100, 240), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                        spriteBatch.DrawString(spriteFont, "APRIETE 'P' PARA SALIR DEL JUEGO ", new Vector2(100, 310), Color.DarkMagenta, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                    }
                }
                spriteBatch.End();

            }
            //seleccion del auto
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(Titulo, new Vector2(20, 10), Color.White);
                spriteBatch.DrawString(spriteFont, "Jugador 1 : WASD , Y , M", new Vector2(10, 540), Color.DeepSkyBlue, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                spriteBatch.DrawString(spriteFont, "Jugador 2 : Flechas , L , Espacio", new Vector2(10, 560), Color.DeepSkyBlue, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                spriteBatch.End();

                List<Rectangle> sinelegir = new List<Rectangle>();
                for (int i = 0; i < roster.Length; i++)
                {
                    Rectangle sourceRect = new Rectangle(i * 45 * 3, 0, 45 * 3, 45 * 3);
                    sinelegir.Add(sourceRect);
                }

                List<Rectangle> cuadradospamapas = new List<Rectangle>();
                for (int i = 0; i < mapasid.Length; i++)
                {
                    Rectangle cuadrosmapas = new Rectangle(i * 135, 0, 135, 135);
                    cuadradospamapas.Add(cuadrosmapas);
                }

                List<Rectangle> rectangulosiniciar = new List<Rectangle>();
                for (int i = 0; i < iniciar.Length; i++)
                {
                    Rectangle iniciar = new Rectangle(i * 28, 0, 28, 11);
                    rectangulosiniciar.Add(iniciar);
                }

                List<Rectangle> rectangulosnumeros = new List<Rectangle>();
                for (int i = 0; i < vueltasposibles.Length; i++)
                {
                    Rectangle numeros = new Rectangle(i * 64, 0, 64, 64);
                    rectangulosnumeros.Add(numeros);
                }

                // autos pa elegir
                int itmesPorFila = 3;
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
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Gold);
                        spriteBatch.End();
                    }
                    else if (Seleccionado && i == opcionjugador1)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], new Color(139, 90, 43));
                        spriteBatch.End();
                    }
                    else if (Seleccionado2 && i == opcionjugador2)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], new Color(192, 192, 192));
                        spriteBatch.End();
                    }
                    else if (i == opcionjugador2 && i == opcionjugador1)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Peru);
                        spriteBatch.End();
                    }
                    else if (i == opcionjugador1)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Red);
                        spriteBatch.End();
                    }
                    else if (i == opcionjugador2)
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.Blue);
                        spriteBatch.End();
                    }
                    else
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(roster[i], posicionAuto, sinelegir[i], Color.White);
                        spriteBatch.End();
                    }
                    columna++;
                    if (columna >= itmesPorFila)
                    {
                        columna = 0;
                        fila++;
                    }
                }

                //ELEGIR MAPA
                itmesPorFila = 4;
                espaciadoVertical = 0;
                fila = 0;
                columna = 0;
                int anchoElemento = 135;
                int separacionPixel = 1;
                float escala = 0.5f;
                for (int i = 0; i < cuadradospamapas.Count; i++)
                {
                    if (Seleccionado && Seleccionado2)
                    {
                        Vector2 posicionCuadroMapas = new Vector2(columna * (anchoElemento * escala - separacionPixel) + 460, fila * (anchoElemento * escala - separacionPixel) + 135);
                        if (i == opcionmapa && Mapaelegido)
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(mapasid[i], posicionCuadroMapas, cuadradospamapas[i], Color.Beige, 0f, Vector2.Zero, escala, SpriteEffects.None, 0);
                            spriteBatch.End();
                        }
                        else if (i == opcionmapa)
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(mapasid[i], posicionCuadroMapas, cuadradospamapas[i], Color.White, 0f, Vector2.Zero, escala, SpriteEffects.None, 0);
                            spriteBatch.End();
                        }
                        else
                        {
                            spriteBatch.Begin();
                            spriteBatch.Draw(mapasid[i], posicionCuadroMapas, cuadradospamapas[i], Color.Gray, 0f, Vector2.Zero, escala, SpriteEffects.None, 0);
                            spriteBatch.End();
                        }
                        columna++;
                        if (columna >= itmesPorFila)
                        {
                            columna = 0;
                            fila++;
                        }
                    }
                }

                //ELEGIR CANTIDAD DE VUELTAS
                if (Seleccionado && Seleccionado2)
                {
                    for (int i = 0; i < rectangulosnumeros.Count; i++)
                    {
                        Vector2 Posicionnumeros = new Vector2(830 * 0.7f, 500 * 0.7f);
                        if (opcionvueltas == i)
                        {
                            spriteBatch.Begin();
                            if (Mapaelegido)
                            {
                                spriteBatch.DrawString(spriteFont, "SELECCIONE EL MAPA", new Vector2(470, 100), Color.DeepSkyBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.DrawString(spriteFont, "SELECCIONE EL MAPA", new Vector2(470, 100), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
                            }
                            if (Vueltaselegidas)
                            {
                                spriteBatch.DrawString(spriteFont, "CANTIDAD DE VUELTAS", new Vector2(470, 320), Color.DeepSkyBlue, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
                            }
                            else
                            {
                                spriteBatch.DrawString(spriteFont, "CANTIDAD DE VUELTAS", new Vector2(470, 320), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
                            }
                            spriteBatch.Draw(vueltasposibles[i], Posicionnumeros, rectangulosnumeros[i], Color.White, 0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
                            spriteBatch.End();
                        }
                    }
                }

                //DIBUJAR START
                if (Mapaelegido && Vueltaselegidas && Seleccionado && Seleccionado2)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(spriteFont, "INICIAR CARRERA", new Vector2(480, 500), Color.DeepSkyBlue);
                    spriteBatch.End();

                    spriteBatch.Begin();
                    spriteBatch.Draw(iniciar[indiceImagenActual], new Vector2(530, 540), rectangulosiniciar[indiceImagenActual], Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0);
                    spriteBatch.End();
                }
            }
        }

        void Camaradibujo(Camera camera, SpriteBatch spriteBatch)
        {
            List<Rectangle> rectanguloautos = new List<Rectangle>();
            for (int i = 0; i < autos.Length; i++)
            {
                Rectangle rectangulo = new Rectangle(i * 125, 0, 125, 75);
                rectanguloautos.Add(rectangulo);
            }

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            spriteBatch.Draw(fondomapa, new Vector2(0, 0), Color.White);
            Map.Draw();
            spriteBatch.Draw(autos[opcionjugador1], posicionAuto, rectanguloautos[opcionjugador1], Color.White, rotation, spriteorigin, 0.16f, SpriteEffects.None, 0);
            spriteBatch.Draw(autos[opcionjugador2], posicionAuto2, rectanguloautos[opcionjugador2], Color.White, rotation2, spriteorigin2, 0.16f, SpriteEffects.None, 0);
            spriteBatch.End();
        }
        private void ColisionTiles()
        {
            // Limites
            float nuevaPosXAuto1 = Math.Clamp(posicionAuto.X, 2, 1170);
            float nuevaPosYAuto1 = Math.Clamp(posicionAuto.Y, 2, 687);
            float nuevaPosXAuto2 = Math.Clamp(posicionAuto2.X, 2, 1170);
            float nuevaPosYAuto2 = Math.Clamp(posicionAuto2.Y, 2, 687);

            if (nuevaPosXAuto1 != posicionAuto.X || nuevaPosYAuto1 != posicionAuto.Y)
            {
                posicionAuto.X = nuevaPosXAuto1;
                posicionAuto.Y = nuevaPosYAuto1;
                spriteVelocity = Vector2.Zero;
            }
            if (nuevaPosXAuto2 != posicionAuto2.X || nuevaPosYAuto2 != posicionAuto2.Y)
            {
                posicionAuto2.X = nuevaPosXAuto2;
                posicionAuto2.Y = nuevaPosYAuto2;
                spriteVelocity2 = Vector2.Zero;
            }

            //Colision tiles
            TilemapLayer capaMapa = Map.Mapa["Mapa"];
            int idAuto1 = capaMapa[(int)posicionAuto.X / capaMapa.Tileset.TileWidth, (int)posicionAuto.Y / capaMapa.Tileset.TileHeight].TilesetTileID;
            int idAuto2 = capaMapa[(int)posicionAuto2.X / capaMapa.Tileset.TileWidth, (int)posicionAuto2.Y / capaMapa.Tileset.TileHeight].TilesetTileID;


            if (idAuto1 == 48)
            {
                spriteVelocity *= 0.1f;
            }
            if (idAuto2 == 48)
            {
                spriteVelocity2 *= 0.1f;
            }
            if (idAuto1 == 71)
            {
                mediavuelta1 = true;
            }
            if (idAuto2 == 71)
            {
                mediavuelta2 = true;
            }
            if (idAuto1 == 3 && mediavuelta1 == true)
            {
                Vueltasjugador1 += 1;
                mediavuelta1 = false;
            }
            if (idAuto2 == 3 && mediavuelta2 == true)
            {
                Vueltasjugador2 += 1;
                mediavuelta2 = false;
            }


        }

        //REINICIA TODOOOOOO
        public void Reset()
        {
            MediaPlayer.Stop();
            ESTADOMENU = true;
            sonidoSemaforoReproducido = false;
            opcionjugador1 = 0;
            opcionjugador2 = 1;
            opcionvueltas = 0;
            vueltasadar = 0;
            PosicionarAutosMapas(opcionmapa);
            Seleccionado = false;
            Seleccionado2 = false;
            Mapaelegido = false;
            Vueltaselegidas = false;
            IniciarCarrera = false;
            configuracion = false;
            mediavuelta1 = false;
            mediavuelta2 = false;
            Vueltacompleta = false;
            Vueltasjugador1 = 0;
            Vueltasjugador2 = 0;
            AnuncionGanador = false;
            SemaforoActivado = true;
            tiempoCambioSemaforo = 1f;
            tiempoTranscurridoSemaforo = 0f;
            indiceImagenSemaforo = 0;
            tiempoDeCambio = 0.15f;
            tiempoTranscurrido = 0f;
            tiempoCambioImagen = 0.1f;
            indiceImagenActual = 0;
            tangentialVelocity = 2f;
            friction = 0.03f;

        }
        //DEVUELVE A LOS JUGADORES AL MENU
        public void ResetalMenu()
        {
            MediaPlayer.Stop();
            sonidoSemaforoReproducido = false;
            tiempoTranscurrido = 0f;
            Seleccionado = false;
            Seleccionado2 = false;
            IniciarCarrera = false;
            configuracion = false;
            mediavuelta1 = false;
            mediavuelta2 = false;
            Vueltasjugador1 = 0;
            Vueltasjugador2 = 0;
            AnuncionGanador = false;
            Vueltacompleta = false;
            Vueltaselegidas = false;
            Mapaelegido = false;
            PosicionarAutosMapas(ultimomapaelegiodo);
            rotation = 0f;
            rotation2 = 0f;
            spriteVelocity = Vector2.Zero;
            spriteVelocity2 = Vector2.Zero;
            ESTADOMENU = true;
            AnuncionGanador = false;
            SemaforoActivado = true;
            tiempoCambioSemaforo = 1f;
            tiempoTranscurridoSemaforo = 0f;
            indiceImagenSemaforo = 0;
            tiempoDeCambio = 0.15f;
            tiempoTranscurrido = 0f;
            tiempoCambioImagen = 0.1f;
            indiceImagenActual = 0;
        }

        //REINICIA LA PARTIDA ACTUAL
        public void ResetPartida()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(sonidoSemaforo);
            tiempoCambioSemaforo = 1f;
            tiempoTranscurridoSemaforo = 0f;
            sonidoSemaforoReproducido = false;
            indiceImagenSemaforo = 0;
            SemaforoActivado = true;
            tiempoTranscurrido = 0f;
            mediavuelta1 = false;
            mediavuelta2 = false;
            Vueltasjugador1 = 0;
            Vueltasjugador2 = 0;
            AnuncionGanador = false;
            Vueltacompleta = false;
            opcionvueltas = vueltasadar;
            PosicionarAutosMapas(ultimomapaelegiodo);
            rotation = 0f;
            rotation2 = 0f;
            spriteVelocity = Vector2.Zero;
            spriteVelocity2 = Vector2.Zero;
        }


    }
}
