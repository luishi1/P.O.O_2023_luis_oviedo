using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        private Vector2 lastPelotaVelocity;
        private Texture2D fondo;
        private Vector2 fondopos;
        SpriteFont spriteFont;
        private int ptsjugador1 = 0;
        private int ptsjugador2 = 0;
        //mecanicas
        private Texture2D[] powerups = new Texture2D[4];
        private bool powerUpActive = false;
        private int currentPowerUp = -1;
        private int powerUpSize = 30; 
       
        public Pong()
        {
            paleta1pos = new Vector2(20, 20);
            paleta2pos = new Vector2(760, 20);
            pelotapos = new Vector2(400, 300);
        }
        public void Update(GameTime gameTime)
        {
            //logica powerups


            //logica de la pelota
            Vector2 oldPelotapos = pelotapos;
            pelotapos += pelotaVelocity;
            if (pelotapos.Y < 0 || pelotapos.Y > 600)
            {
                pelotaVelocity.Y *= -1;
            }

            if (pelotapos.X < paleta1pos.X + paleta1.Width && pelotapos.X > paleta1pos.X && pelotapos.Y > paleta1pos.Y && pelotapos.Y < paleta1pos.Y + paleta1.Height)
            {
                pelotapos = oldPelotapos;
                pelotaVelocity.X *= -1;
            }
            if (pelotapos.X + pelota.Width > paleta2pos.X && pelotapos.X + pelota.Width < paleta2pos.X + paleta2.Width && pelotapos.Y > paleta2pos.Y && pelotapos.Y < paleta2pos.Y + paleta2.Height)
            {
                pelotapos = oldPelotapos;
                pelotaVelocity.X *= -1;
            }

            if (pelotapos.X < 0)
            {
                ptsjugador2++;
                lastPelotaVelocity = pelotaVelocity;
                ReiniciarPelota();
            }

            if (pelotapos.X > 800)
            {
                ptsjugador1++;
                lastPelotaVelocity = pelotaVelocity;
                ReiniciarPelota();
            }

            //movimiento paletas aka pedro
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                paleta1pos.Y -= 7;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                paleta1pos.Y += 7;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                paleta2pos.Y -= 7;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                paleta2pos.Y += 7;
            }
            paleta1pos.Y = MathHelper.Clamp(paleta1pos.Y, 0, 600 - paleta1.Height);
            paleta2pos.Y = MathHelper.Clamp(paleta2pos.Y, 0, 600 - paleta2.Height);
        }

        private void ReiniciarPelota()
        {
            pelotapos = new Vector2(400, 300);
            pelotaVelocity = lastPelotaVelocity;
        }


        public void LoadContent(ContentManager content)
        {
            paleta1 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            paleta2 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            pelota = content.Load<Texture2D>("Sprites/PongGame/pelota");
            fondo = content.Load<Texture2D>("Sprites/PongGame/fondo");
            //spriteFont = content.Load<SpriteFont>("");

            //powers
            for (int i = 0; i < powerups.Length; i++)
            {
                powerups[i] = content.Load<Texture2D>("Sprites/PongGame/powerups");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fondo, fondopos, Color.White);
            spriteBatch.Draw(paleta1, paleta1pos, Color.White);
            spriteBatch.Draw(paleta2, paleta2pos, Color.White);
            spriteBatch.Draw(pelota, pelotapos, Color.White);
            //spriteBatch.DrawString(spriteFont, "Jugador 1: " + ptsjugador1, new Vector2(20, 20), Color.White);
            //spriteBatch.DrawString(spriteFont, "Jugador 2: " + ptsjugador2, new Vector2(700, 20), Color.White);

            //rectangle
            Rectangle powerUpRectangle;

            switch (currentPowerUp)
            {
                case 0: // Fuego
                    powerUpRectangle = new Rectangle(0, 0, 10*3, 10*3);
                    break;
                case 1: // Lento
                    powerUpRectangle = new Rectangle(10*3, 0, 10*3, 10*3);
                    break;
                case 2: // Iman
                    powerUpRectangle = new Rectangle(20*3, 0, 10*3, 10*3);
                    break;
                case 3: // X2
                    powerUpRectangle = new Rectangle(30*3, 0, 10*3, 10*3);
                    break;
                default:
                    powerUpRectangle = Rectangle.Empty; 
                    break;
            }
            if (powerUpActive)
            {
                spriteBatch.Draw(powerups[currentPowerUp], new Vector2(400, 300), powerUpRectangle, Color.White);
            }
        }


    }
}