using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Juego.Clases
{
    public class Jugador
    {
        public enum Acciones
        {
            Idle,
            AFK,
            Caminar,
            Correr,
            Agacharse,
            Saltar,
            Desaparecer,
            Aparecer,
            Saltando,
            Aterrizando

        }
        public Arcade arcade;
        public Vector2 PosicionJugador;
        public Acciones EstadoActual = Acciones.Idle;
        public Acciones UltimoEstado = Acciones.Idle;
        public bool Derecha = true;
        public Texture2D Spritesheet;
        public Texture2D TexturaHitbox;
        public SpriteFont SpriteFont;
        public Vector2 pos = new Vector2(50, 200);
        public bool desaparecido;

        private string Ruta { get; set; }


        //Teclas
        public KeyboardState teclado;
        private KeyboardState TecladoAnterior;
        public Keys TeclaDerecha { get; set; }
        public Keys TeclaIzquierda { get; set; }
        public Keys TeclaAbajo { get; set; }
        public Keys TeclaArriba { get; set; }
        public Keys TeclaEnter { get; set; }
        public Keys TeclaCorrer { get; set; }

        private Dictionary<Acciones, List<Rectangle>> animaciones;

        private const int AnchoFrame = 32;
        private const int AltoFrame = 32;

        //Animaciones
        public int frameActual;
        public double tiempoEntreFrames = 1;
        public double tiempoTranscurrido;
        public double tiempoAFK;
        public double tiempoMaximoAFK = 60;

        //GRAVEDAD FLIPANTE
        public float VelocidadY;
        public const float Gravedad = 0.1f;
        public const float FuerzaSalto = -3.5f;
        public bool EnSuelo;
        public Vector2 UltimaPosicionEnPlataforma { get; set; }
        public bool EstabaSaltando { get; set; }
        public bool agachado = false;

        private Dictionary<Acciones, double> tiemposEntreFrames;

        public Jugador(Vector2 posicion, string rutadelarchivo)
        {
            PosicionJugador = posicion;
            Ruta = rutadelarchivo;
            VelocidadY = 0;
            EnSuelo = true;
            desaparecido = false;
            InicializarAnimaciones();
            InicializarTiemposEntreFrames();

        }

        private void InicializarAnimaciones()
        {
            animaciones = new Dictionary<Acciones, List<Rectangle>>();

            // Animación de Idle (fila 1)
            List<Rectangle> framesIdle = new List<Rectangle>();
            for (int i = 0; i < 2; i++)
            {
                framesIdle.Add(new Rectangle(i * AnchoFrame, 0, AnchoFrame, AltoFrame));
            }
            animaciones.Add(Acciones.Idle, framesIdle);

            // Animación de AFK (fila 2)
            List<Rectangle> framesAFK = new List<Rectangle>();
            for (int i = 0; i < 2; i++)
            {
                framesAFK.Add(new Rectangle(i * AnchoFrame, AltoFrame, AnchoFrame, AltoFrame));
            }
            animaciones.Add(Acciones.AFK, framesAFK);

            // Animación de Caminar (fila 3)
            List<Rectangle> framesCaminar = new List<Rectangle>();
            for (int i = 0; i < 4; i++)
            {
                framesCaminar.Add(new Rectangle(i * AnchoFrame, 2 * AltoFrame, AnchoFrame, AltoFrame));
            }
            animaciones.Add(Acciones.Caminar, framesCaminar);

            // Animación de Correr (fila 4)
            List<Rectangle> framesCorrer = new List<Rectangle>();
            for (int i = 0; i < 8; i++)
            {
                framesCorrer.Add(new Rectangle(i * AnchoFrame, 3 * AltoFrame, AnchoFrame, AltoFrame));
            }
            animaciones.Add(Acciones.Correr, framesCorrer);

            List<Rectangle> framesSaltoAire = new List<Rectangle>();
            framesSaltoAire.Add(new Rectangle(4 * AnchoFrame, 5 * AltoFrame, AnchoFrame, AltoFrame));
            animaciones.Add(Acciones.Saltando, framesSaltoAire);

            List<Rectangle> framaagachado = new List<Rectangle>();
            framaagachado.Add(new Rectangle(2 * AnchoFrame, 4 * AltoFrame, AnchoFrame, AltoFrame));
            animaciones.Add(Acciones.Agacharse, framaagachado);

        }
        private void InicializarTiemposEntreFrames()
        {
            tiemposEntreFrames = new Dictionary<Acciones, double>();
            tiemposEntreFrames[Acciones.Idle] = 1.0;
            tiemposEntreFrames[Acciones.AFK] = 1.0;
            tiemposEntreFrames[Acciones.Caminar] = 0.2;
            tiemposEntreFrames[Acciones.Correr] = 0.1;
            tiemposEntreFrames[Acciones.Saltar] = 0.1;
            tiemposEntreFrames[Acciones.Agacharse] = 1;
            tiemposEntreFrames[Acciones.Saltando] = 0.2;
        }

        public void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>(Ruta);
            TexturaHitbox = content.Load<Texture2D>("Sprites/textuhit");
            SpriteFont = content.Load<SpriteFont>("Sprites/Carrera/textos");
        }

        public void Update(GameTime gameTime)
        {
            teclado = Keyboard.GetState();

            ActualizarEstados(teclado, gameTime);

            if (EnSuelo)
            {
                VelocidadY = 0;
                EstabaSaltando = false;
            }
            else
            {
                VelocidadY += Gravedad;
            }

            Movimiento(teclado);
        }


        public void ActualizarEstados(KeyboardState TecladoEstado, GameTime gameTime)
        {
            UltimoEstado = EstadoActual;

            if (TecladoEstado.IsKeyDown(TeclaArriba))
            {
                if (TecladoEstado.IsKeyDown(TeclaDerecha))
                {
                    Derecha = true;
                }
                else if (TecladoEstado.IsKeyDown(TeclaIzquierda))
                {
                    Derecha = false;
                }
                EstadoActual = Acciones.Saltando;
            }
            else if (TecladoEstado.IsKeyDown(TeclaDerecha))
            {
                if (!agachado)
                {
                    EstadoActual = Acciones.Caminar;
                    Derecha = true;
                }
            }
            else if (TecladoEstado.IsKeyDown(TeclaIzquierda))
            {
                if (!agachado)
                {
                    EstadoActual = Acciones.Caminar;
                    Derecha = false;
                }
            }
            else if (TecladoEstado.IsKeyDown(TeclaCorrer) && (TecladoEstado.IsKeyDown(TeclaDerecha) || TecladoEstado.IsKeyDown(TeclaIzquierda)))
            {
                EstadoActual = Acciones.Correr;
            }
            else if (TecladoEstado.IsKeyDown(TeclaAbajo))
            {
                EstadoActual = Acciones.Agacharse;
                agachado = true;
            }
            else if (EstabaSaltando)
            {
                EstadoActual = Acciones.Saltando;
            }
            else
            {
                EstadoActual = Acciones.Idle;
            }

            tiempoTranscurrido += gameTime.ElapsedGameTime.TotalSeconds;
            if (tiempoTranscurrido > tiemposEntreFrames[EstadoActual])
            {
                tiempoTranscurrido -= tiemposEntreFrames[EstadoActual];
                if (UltimoEstado != EstadoActual)
                {
                    frameActual = 0;
                }
                else
                {
                    frameActual = (frameActual + 1) % animaciones[EstadoActual].Count;
                }
            }
           
            TecladoAnterior = TecladoEstado;
        }

        public void Movimiento(KeyboardState TecladoEstado)
        {
            if (TecladoEstado.IsKeyDown(TeclaDerecha))
            {
                if (!agachado)
                {
                    PosicionJugador.X += 2;
                }
                else
                {
                    EstadoActual = Acciones.Agacharse;
                }
            }
            if (TecladoEstado.IsKeyDown(TeclaIzquierda))
            {
                if (!agachado)
                {
                    PosicionJugador.X -= 2;
                }
                else
                {
                    EstadoActual = Acciones.Agacharse;
                }
            }

            if (EnSuelo)
            {
                if (TecladoEstado.IsKeyDown(TeclaArriba))
                {
                    EstadoActual = Acciones.Saltando;
                    VelocidadY = FuerzaSalto;
                    EnSuelo = false;
                    agachado = false;
                }
                else if (TecladoEstado.IsKeyDown(TeclaAbajo))
                {
                    frameActual = 2;
                    agachado = true;
                }
                else
                {
                    if (agachado)
                    {
                        agachado = false;
                        frameActual = 0;
                    }
                }
            }

            if (!EnSuelo)
            {
                VelocidadY += Gravedad;
            }

            PosicionJugador.Y += VelocidadY;
        }


        public Rectangle ObtenerHitboxJugador()
        {
            if (animaciones.ContainsKey(EstadoActual))
            {
                int indiceFrame = Math.Min(Math.Max(frameActual, 0), animaciones[EstadoActual].Count - 1);
                Rectangle frameRect = animaciones[EstadoActual][indiceFrame];

                int offsetX = 5;
                int offsetY = 5;
                int width = frameRect.Width - offsetX * 2;
                int height = frameRect.Height - offsetY * 1;
                if (EstadoActual == Acciones.Agacharse)
                {
                    offsetX = 5;
                    offsetY = 8;
                    width = frameRect.Width - offsetX * 2;
                    height = frameRect.Height - offsetY * 0;
                }
                return new Rectangle((int)PosicionJugador.X + offsetX, (int)PosicionJugador.Y + offsetY, width, height);
            }
            else
            {
                return Rectangle.Empty;
            }
        }

        public int ObtenerAlturaCuadroActual()
        {
            if (animaciones.ContainsKey(EstadoActual))
            {
                int indiceFrame = Math.Min(Math.Max(frameActual, 0), animaciones[EstadoActual].Count - 1);
                return animaciones[EstadoActual][indiceFrame].Height;
            }
            else
            {
                return 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (animaciones.ContainsKey(EstadoActual))
            {
                int indiceFrame = Math.Min(Math.Max(frameActual, 0), animaciones[EstadoActual].Count - 1);

                Rectangle frameRect = animaciones[EstadoActual][indiceFrame];

                SpriteEffects efectos = SpriteEffects.None;

                if (!Derecha)
                    efectos |= SpriteEffects.FlipHorizontally;

                spriteBatch.Draw(Spritesheet, PosicionJugador, frameRect, Color.White, 0f, Vector2.Zero, 1f, efectos, 0f);
                spriteBatch.DrawString(SpriteFont, $"Estado: {EstadoActual}, Frame: {frameActual}", pos, Color.White);
            }
            else
            {
            }
        }

        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            if (animaciones.ContainsKey(EstadoActual))
            {
                int indiceFrame = Math.Min(Math.Max(frameActual, 0), animaciones[EstadoActual].Count - 1);
                Rectangle frameRect = animaciones[EstadoActual][indiceFrame];

                int offsetX = 5;
                int offsetY = 5;
                int width = frameRect.Width - offsetX * 2;
                int height = frameRect.Height - offsetY * 1;
                if (EstadoActual == Acciones.Agacharse)
                {
                    offsetX = 5;
                    offsetY = 8;
                    width = frameRect.Width - offsetX * 2;
                    height = frameRect.Height - offsetY * 0;
                }
                spriteBatch.Draw(TexturaHitbox, new Rectangle((int)PosicionJugador.X + offsetX, (int)PosicionJugador.Y + offsetY, width, height), Color.White * 0.5f);
            }
            else
            {

            }
        }
    }
} 