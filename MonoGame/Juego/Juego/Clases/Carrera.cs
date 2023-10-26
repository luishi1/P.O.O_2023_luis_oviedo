using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Juego.Clases
{
    public class Autos
    {
        public Texture2D autoTexture;
        public Texture2D imagen;
        public Vector2 posAuto;
        public Vector2 posImagen;

        public Autos(Texture2D autoTexture, Texture2D imagen)
        {
            this.autoTexture = autoTexture;
            this.imagen = imagen;
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
        Autos auto;
        Autos auto2;

        public void Update(GameTime gameTime)
        {
            // Lógica de actualización del juego (movimiento, colisiones, etc.).
            auto.Movimiento();
            auto.Colisiones();
        }

        public void LoadContent(ContentManager content)
        {
            // Carga las texturas de los autos
            //nt
            auto = new Autos(content.Load<Texture2D>("Sprites/Carrera/autos"), content.Load<Texture2D>("Sprites/Carrera/autos"));
            auto2 = new Autos(content.Load<Texture2D>("Sprites/Carrera/autos"), content.Load<Texture2D>("Sprites/Carrera/autos"));
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // Rectangulos

            // Dibuja los autos
            spriteBatch.Draw(auto.autoTexture, auto.posAuto, Color.White);
            spriteBatch.Draw(auto2.autoTexture, auto2.posAuto, Color.White);
        }
    }
}
