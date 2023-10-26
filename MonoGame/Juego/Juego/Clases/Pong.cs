using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Resources;

namespace Juego.Clases
{
    public class PowerUp
    {
        public Vector2 Position;
        public int Type;
    }

    internal class Pong
    {
        //musica
        private Song backgroundMusic;
        private bool isMusicPlaying = false;
        private SoundEffect tuki;
        private SoundEffect score;
        private SoundEffect poweup;
        //textura
        private Texture2D paleta1;
        private Vector2 paleta1pos;
        private Texture2D paleta2;
        private Vector2 paleta2pos;
        private Texture2D pelota;
        private Vector2 pelotapos;
        private Vector2 pelotaVelocity = new Vector2(5, 5);
        private Vector2 lastPelotaVelocity;
        private Vector2 lastDuplicatePelotaVelocity;
        private Texture2D fondo;
        private Vector2 fondopos;
        SpriteFont spriteFont;
        private int ptsjugador1 = 0;
        private int ptsjugador2 = 0;
        private string ptsjugador1Text = "0";
        private string ptsjugador2Text = "0";
        // Mecánicas
        private Texture2D[] powerups = new Texture2D[8];
        private List<PowerUp> activePowerUps = new List<PowerUp>();
        private float powerUpTimer = 0f;
        private Random random = new Random();
        private bool isPowerUpActive = false;
        private int activePowerUpType = -1;
        private float powerUpActivationTime = 0f;
        private Vector2 duplicatePelotaPosition;
        private Vector2 duplicatePelotaVelocity;
        private bool PelotaDuplicada = false;
        private float powerUpStartTime = 0f;
        private Vector2 originalPelotaVelocity = new Vector2(5, 5); 
        private bool ultimaPaletaTocadaPorPaleta1 = false;
        private bool Pelotavisible = true;
        private bool isInvisiblePowerUpActive = false;
        private float invisiblePowerUpActivationTime = 0f;

        public Pong()
        {
            paleta1pos = new Vector2(20, 20);
            paleta2pos = new Vector2(760, 520);
            pelotapos = new Vector2(400, 300);
        }

        public void StopMusic()
        {
            if (isMusicPlaying)
            {
                MediaPlayer.Stop();
                isMusicPlaying = false;
            }
        }
        private Rectangle GetPelotaRect()
        {
            return new Rectangle((int)pelotapos.X, (int)pelotapos.Y, pelota.Width, pelota.Height);
        }
        public void Update(GameTime gameTime)
        {
            powerUpTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (powerUpTimer >= 10f)
            {
                int randomType = random.Next(0, powerups.Length);
                PowerUp newPowerUp = new PowerUp
                {
                    Position = new Vector2(random.Next(50, 750), 0),
                    Type = randomType
                };
                activePowerUps.Add(newPowerUp);
                powerUpTimer = 0f;
            }

            if (!isMusicPlaying)
            {
                MediaPlayer.Play(backgroundMusic);
                isMusicPlaying = true;
                MediaPlayer.IsRepeating = true;
            }

            foreach (PowerUp powerUp in activePowerUps)
            {
                powerUp.Position.Y += 2;

                Rectangle powerUpRect = new Rectangle((int)powerUp.Position.X, (int)powerUp.Position.Y, 30, 30);

                if (powerUpRect.Intersects(GetPelotaRect()))
                {
                    switch (powerUp.Type)
                    {
                        case 0: // Fuego 
                            if (!isPowerUpActive)
                            {
                                originalPelotaVelocity = pelotaVelocity; 
                                pelotaVelocity *= 2;
                                isPowerUpActive = true;
                                activePowerUpType = powerUp.Type;
                                powerUpActivationTime = (float)gameTime.TotalGameTime.TotalSeconds;
                                powerUpStartTime = (float)gameTime.TotalGameTime.TotalSeconds;
                            }
                            break;

                        case 1: // Lento 
                            if (!isPowerUpActive)
                            {
                                originalPelotaVelocity = pelotaVelocity; 
                                pelotaVelocity /= 2;
                                isPowerUpActive = true;
                                activePowerUpType = powerUp.Type;
                                powerUpActivationTime = (float)gameTime.TotalGameTime.TotalSeconds;
                                powerUpStartTime = (float)gameTime.TotalGameTime.TotalSeconds;
                            }
                            break;

                        case 2: // Cambio de Dirección en X / Iman
                            if (!isPowerUpActive)
                            {
                                originalPelotaVelocity = pelotaVelocity;
                                pelotaVelocity = -pelotaVelocity;
                            }
                            break;

                        case 3: // Duplicar
                            if (!isPowerUpActive)
                            {
                                originalPelotaVelocity = pelotaVelocity;
                                isPowerUpActive = true;
                                activePowerUpType = powerUp.Type;
                                powerUpActivationTime = (float)gameTime.TotalGameTime.TotalSeconds;
                                PelotaDuplicada = true;
                                duplicatePelotaPosition = new Vector2(pelotapos.X, pelotapos.Y);
                                duplicatePelotaVelocity = new Vector2(-pelotaVelocity.X, pelotaVelocity.Y);
                                powerUpStartTime = (float)gameTime.TotalGameTime.TotalSeconds;
                            }
                            break;
                        case 4: // Cambio de Dirección en Y
                            if (!isPowerUpActive)
                            {
                               pelotaVelocity.Y = -pelotaVelocity.Y;  
                            }
                            break;
                        case 5: //suma un punto al jugador 
                            if (!isPowerUpActive)
                            {
                                if (ultimaPaletaTocadaPorPaleta1)
                                {
                                    ptsjugador1++;
                                    score.Play();
                                }
                                else
                                {
                                    ptsjugador2++;
                                    score.Play();
                                }
                            }
                            break;
                        case 6: //resta un punto al jugador
                            if (!isPowerUpActive)
                            {
                                if (ultimaPaletaTocadaPorPaleta1)
                                {
                                    ptsjugador1--;
                                    score.Play();
                                }
                                else
                                {
                                    ptsjugador2--;
                                    score.Play();
                                }
                            }
                            break;
                        case 7: // invisible
                            if (!isInvisiblePowerUpActive)
                            {
                                originalPelotaVelocity = pelotaVelocity;
                                isInvisiblePowerUpActive = true;
                                invisiblePowerUpActivationTime = (float)gameTime.TotalGameTime.TotalSeconds;
                                Pelotavisible = false;
                            }
                            break;
                        default:
                            break;
                    }
                    poweup.Play();
                    activePowerUps.Remove(powerUp);
                    break;
                }
            }

            if (isPowerUpActive && (gameTime.TotalGameTime.TotalSeconds - powerUpActivationTime >= 15))
            {
                if (ultimaPaletaTocadaPorPaleta1)
                {
                    pelotaVelocity = -originalPelotaVelocity;
                }
                else
                {
                    pelotaVelocity = originalPelotaVelocity;
                }
                isPowerUpActive = false;
                activePowerUpType = -1;
                PelotaDuplicada = false;
                Pelotavisible = true;
            }
            if (isInvisiblePowerUpActive && (gameTime.TotalGameTime.TotalSeconds - invisiblePowerUpActivationTime >= 6))
            {
                Pelotavisible = true;
            }
            activePowerUps.RemoveAll(powerUp => powerUp.Position.Y > 600);

            Vector2 oldPelotapos = pelotapos;
            pelotapos += pelotaVelocity;
            if (pelotapos.Y < 0 || pelotapos.Y > 600)
            {
                pelotaVelocity.Y *= -1;
            }
            if (pelotapos.X < paleta1pos.X + paleta1.Width && pelotapos.X + pelota.Width > paleta1pos.X && pelotapos.Y < paleta1pos.Y + paleta1.Height && pelotapos.Y + pelota.Height > paleta1pos.Y)
            {
                pelotapos = oldPelotapos;
                pelotaVelocity.X = Math.Abs(pelotaVelocity.X);
                ultimaPaletaTocadaPorPaleta1 = true;
                tuki.Play();
            }
            if (pelotapos.X < paleta2pos.X + paleta2.Width && pelotapos.X + pelota.Width > paleta2pos.X && pelotapos.Y < paleta2pos.Y + paleta2.Height && pelotapos.Y + pelota.Height > paleta2pos.Y)
            {
                pelotapos = oldPelotapos;
                pelotaVelocity.X = -Math.Abs(pelotaVelocity.X);
                ultimaPaletaTocadaPorPaleta1 = false;
                tuki.Play();
            }
            if (pelotapos.X < 0)
            {
                ptsjugador2++;
                lastPelotaVelocity = pelotaVelocity;
                ReiniciarPelota();
                score.Play();
            }
            if (pelotapos.X > 800)
            {
                ptsjugador1++;
                lastPelotaVelocity = pelotaVelocity;
                ReiniciarPelota();
                score.Play();
            }
            if (PelotaDuplicada)
            {
                Vector2 oldDuplicatePelotaPosition = duplicatePelotaPosition;
                duplicatePelotaPosition += duplicatePelotaVelocity;
                if (duplicatePelotaPosition.Y < 0 || duplicatePelotaPosition.Y > 600)
                {
                    duplicatePelotaVelocity.Y *= -1;
                }
                if (duplicatePelotaPosition.X < paleta1pos.X + paleta1.Width && duplicatePelotaPosition.X + pelota.Width > paleta1pos.X &&
                    duplicatePelotaPosition.Y < paleta1pos.Y + paleta1.Height && duplicatePelotaPosition.Y + pelota.Height > paleta1pos.Y)
                {
                    duplicatePelotaPosition = oldDuplicatePelotaPosition;
                    duplicatePelotaVelocity.X = Math.Abs(duplicatePelotaVelocity.X);
                    tuki.Play();
                }
                if (duplicatePelotaPosition.X < paleta2pos.X + paleta2.Width && duplicatePelotaPosition.X + pelota.Width > paleta2pos.X &&
                    duplicatePelotaPosition.Y < paleta2pos.Y + paleta2.Height && duplicatePelotaPosition.Y + pelota.Height > paleta2pos.Y)
                {
                    duplicatePelotaVelocity.X = -Math.Abs(duplicatePelotaVelocity.X);
                    tuki.Play();
                }
                if (duplicatePelotaPosition.X < 0)
                {
                    ptsjugador2++;
                    lastDuplicatePelotaVelocity = duplicatePelotaVelocity;
                    ReiniciarPelotaDuplicada();
                    score.Play();
                }
                if (duplicatePelotaPosition.X > 800)
                {
                    ptsjugador1++;
                    lastDuplicatePelotaVelocity = duplicatePelotaVelocity;
                    ReiniciarPelotaDuplicada();
                    score.Play();
                }
            }
            //Pedros
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

            ptsjugador1Text =  ptsjugador1.ToString();
            ptsjugador2Text =  ptsjugador2.ToString();
        }
        private void ReiniciarPelota()
        {
            pelotapos = new Vector2(400, 300);
            pelotaVelocity = lastPelotaVelocity;
        }
        private void ReiniciarPelotaDuplicada()
        {
            duplicatePelotaPosition = new Vector2(400, 300);
            duplicatePelotaVelocity = lastDuplicatePelotaVelocity;
        }
        public void LoadContent(ContentManager content)
        {
            backgroundMusic = content.Load<Song>("Sprites/PongGame/pongmusic");
            tuki = content.Load<SoundEffect>("Sprites/PongGame/pongbip");
            poweup = content.Load<SoundEffect>("Sprites/PongGame/poweup");
            score = content.Load<SoundEffect>("Sprites/PongGame/score");
            paleta1 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            paleta2 = content.Load<Texture2D>("Sprites/PongGame/pedro");
            pelota = content.Load<Texture2D>("Sprites/PongGame/pelota");
            fondo = content.Load<Texture2D>("Sprites/PongGame/fondo");
            spriteFont = content.Load<SpriteFont>("Sprites/PongGame/Puntos");
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
            if (Pelotavisible)
            {
                spriteBatch.Draw(pelota, pelotapos, Color.White);
            }
            else
            {
                spriteBatch.Draw(pelota, pelotapos, Color.Transparent);
            }
            spriteBatch.DrawString(spriteFont, ptsjugador1Text, new Vector2(240, 15), Color.White);
            spriteBatch.DrawString(spriteFont, ptsjugador2Text, new Vector2(560, 15), Color.White);

            foreach (PowerUp powerUp in activePowerUps)
            {
                Rectangle sourceRect = new Rectangle(powerUp.Type * 30, 0, 30, 30);
                spriteBatch.Draw(powerups[powerUp.Type], powerUp.Position, sourceRect, Color.White);
            }
            if (PelotaDuplicada)
            {
                spriteBatch.Draw(pelota, duplicatePelotaPosition, Color.White);
            }
        }
        public void Reset()
        {
            paleta1pos = new Vector2(20, 20);
            paleta2pos = new Vector2(760, 520);
            pelotapos = new Vector2(400, 300);
            ptsjugador1 = 0;
            ptsjugador2 = 0;
            ptsjugador1Text = "0";
            ptsjugador2Text = "0";
            activePowerUps.Clear();
            powerUpTimer = 0f;
            isPowerUpActive = false;
            activePowerUpType = -1;
            pelotaVelocity = new Vector2(5, 5);
            lastPelotaVelocity = new Vector2(5, 5);
            lastDuplicatePelotaVelocity = new Vector2(5, 5);
            PelotaDuplicada = false;
            originalPelotaVelocity = new Vector2(5, 5);
            ultimaPaletaTocadaPorPaleta1 = false;
            Pelotavisible = true;
            isInvisiblePowerUpActive = false;
            invisiblePowerUpActivationTime = 0f;
        }
    }
}
