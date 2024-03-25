using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Aseprite;

namespace Juego.Clases
{
    public class Plataforma
    {
        public Vector2 Posicion { get; set; }
        public Texture2D Textura { get; set; }
        public bool EsTangible { get; set; }

        public string Ruta { get; set; }
        public bool VolteadoVerticalmente { get; set; }
        public bool VolteadoHorizontalmente { get; set; }

        public int AlturaColision { get; set; }

        public Texture2D TexturaHitbox;

        public Plataforma(Vector2 posicion, string texturaruta, bool esTangible = true, bool volteadoVerticalmente = false, bool volteadoHorizontalmente = false)
        {
            Posicion = posicion;
            Ruta = texturaruta;
            EsTangible = esTangible;
            VolteadoVerticalmente = volteadoVerticalmente;
            VolteadoHorizontalmente = volteadoHorizontalmente;
            AlturaColision = (int)posicion.Y;
        }

        public void LoadContent(ContentManager content)
        {
            Textura = content.Load<Texture2D>(Ruta);
            TexturaHitbox = content.Load<Texture2D>("Sprites/textuhit");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects efectos = SpriteEffects.None;

            if (VolteadoVerticalmente)
                efectos |= SpriteEffects.FlipVertically;

            if (VolteadoHorizontalmente)
                efectos |= SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(Textura, Posicion, null, Color.White, 0f, Vector2.Zero, 1f, efectos, 0f);
        }

        public void DrawHitbox(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TexturaHitbox, new Rectangle((int)Posicion.X, (int)Posicion.Y, Textura.Width, Textura.Height), Color.White * 0.5f);
        }

        public bool ColisionaConJugador(Rectangle hitboxJugador)
        {
            Rectangle hitboxPlataforma = new Rectangle((int)Posicion.X, (int)Posicion.Y, Textura.Width, Textura.Height);
            return hitboxPlataforma.Intersects(hitboxJugador);
        }
    }
    public class Arcade : Plataforma
    {
        public bool Jugador1Interactua;
        public bool Jugador2Interactua;
        public int indicecambio { get; set; }

        public List<Rectangle> CuadradosArcadeHitbox { get; private set; }

        public Arcade(Vector2 posicion, string texturaRuta, bool esTangible = true, bool volteadoVerticalmente = false, bool volteadoHorizontalmente = false, bool jugador1 = false, bool jugador2 = false)
            : base(posicion, texturaRuta, esTangible, volteadoVerticalmente, volteadoHorizontalmente)
        {
            Posicion = posicion;
            Ruta = texturaRuta;
            EsTangible = esTangible;
            VolteadoVerticalmente = volteadoVerticalmente;
            VolteadoHorizontalmente = volteadoHorizontalmente;
            AlturaColision = (int)posicion.Y;
            Jugador1Interactua = jugador1;
            Jugador2Interactua = jugador2;
            indicecambio = 0;
            CuadradosArcadeHitbox = new List<Rectangle>();
            for (int i = 0; i < 5; i++)
            {
                Rectangle cuadro = new Rectangle(i * 36, 0, 36, 50);
                CuadradosArcadeHitbox.Add(cuadro);
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects efectos = SpriteEffects.None;

            if (VolteadoVerticalmente)
                efectos |= SpriteEffects.FlipVertically;

            if (VolteadoHorizontalmente)
                efectos |= SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(Textura, Posicion, CuadradosArcadeHitbox[indicecambio], Color.White, 0f, Vector2.Zero, 1f, efectos, 0f);

            //spriteBatch.Draw(TexturaHitbox, new Rectangle((int)Posicion.X + CuadradosArcadeHitbox[indicecambio].X, (int)Posicion.Y + CuadradosArcadeHitbox[indicecambio].Y, CuadradosArcadeHitbox[indicecambio].Width, CuadradosArcadeHitbox[indicecambio].Height), Color.White * 0.5f);
        }

        public Rectangle ObtenerHitboxArcade()
        {
            if (CuadradosArcadeHitbox.Count > 0 && indicecambio >= 0 && indicecambio < CuadradosArcadeHitbox.Count)
            {
                Rectangle hitbox = CuadradosArcadeHitbox[indicecambio];
                return new Rectangle((int)Posicion.X + hitbox.X, (int)Posicion.Y + hitbox.Y, hitbox.Width, hitbox.Height);
            }
            else
            {
                // En caso de índice incorrecto, devolver un hitbox vacío
                return Rectangle.Empty;
            }
        }
    }
}