using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Juego.Clases
{
    internal class Pong
    {
        private Texture2D paleta1;
        private Vector2 paleta1pos;
        private Texture2D paleta2;
        private Vector2 paleta2pos;
        private Texture2D pelota;
        private Vector2 pelotapos;
        private Vector2 pelotaVelocity = new Vector2(5, 5);

        public Pong()
        {
            paleta1pos = new Vector2(1, 20);
            paleta2pos = new Vector2(900, 20);
            pelotapos = new Vector2(600, 300);
        }

        public void Update(GameTime gameTime)
        {
            // Actualizar la posición de la pelota
            pelotapos += pelotaVelocity;

            // Colisiones con las paredes superior e inferior
            if (pelotapos.Y < 0 || pelotapos.Y > 600)
            {
                pelotaVelocity.Y *= -1;
            }

            // Colisiones con las paletas
            if (pelotapos.X < paleta1pos.X + paleta1.Width && pelotapos.X > paleta1pos.X && pelotapos.Y > paleta1pos.Y && pelotapos.Y < paleta1pos.Y + paleta1.Height)
            {
                pelotaVelocity.X *= -1;
            }
            if (pelotapos.X + pelota.Width > paleta2pos.X && pelotapos.X + pelota.Width < paleta2pos.X + paleta2.Width && pelotapos.Y > paleta2pos.Y && pelotapos.Y < paleta2pos.Y + paleta2.Height)
            {
                pelotaVelocity.X *= -1;
            }
        }

        public void LoadContent(ContentManager content)
        {
            paleta1 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            paleta2 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            pelota = content.Load<Texture2D>("Sprites/PongGame/pelota");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(paleta1, paleta1pos, Color.White);
            spriteBatch.Draw(paleta2, paleta2pos, Color.White);
            spriteBatch.Draw(pelota, pelotapos, Color.White);
        }
    }
}

