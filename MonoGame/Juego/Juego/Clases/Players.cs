using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Juego.Clases
{
    internal class Players
    {
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        //jugador1
        private Vector2 jugador1Position;
        private Texture2D[] ProtaCamUp;
        private Texture2D[] ProtaCamDown;
        private Texture2D[] ProtaCamLeft;
        private Texture2D[] ProtaCamRight;
        private int frameactualJugador1 = 0;
        private int frameWidth;
        private float animationTimerJugador1 = 0f;
        private float frameDuration = 0.1f;
        private Direction currentDirectionJugador1 = Direction.Right;
        private Direction lastDirectionJugador1 = Direction.Right;
        private KeyboardState lastKeyboardStateJugador1;
        //jugador2
        private bool jugador2Activo = false;
        private Vector2 jugador2Position;
        private Texture2D[] ProtaCamUpJugador2;
        private Texture2D[] ProtaCamDownJugador2;
        private Texture2D[] ProtaCamLeftJugador2;
        private Texture2D[] ProtaCamRightJugador2;
        private int frameactualJugador2 = 0;
        private float animationTimerJugador2 = 0f;
        private Direction currentDirectionJugador2 = Direction.Right;
        private Direction lastDirectionJugador2 = Direction.Right;
        //Totems
        private Texture2D[] Totem = new Texture2D[4];
        private Vector2[] TotemPos = new Vector2[4];

        //CIRCULOOOS
        Texture2D[] circuloR = new Texture2D[4];
        Texture2D[] circuloA = new Texture2D[4];
        Vector2[] circuloRpos = new Vector2[4];
        Vector2[] circuloApos = new Vector2[4];
        //voy a tener que re hacer esto jaja me cago en dios

        //constructor players
        public Players()
        {
            jugador1Position = new Vector2(350, 480);
            jugador2Position = new Vector2(400, 480);
            //totems
            TotemPos[0] = new Vector2(80, 250);
            TotemPos[1] = new Vector2(200, 100);
            TotemPos[2] = new Vector2(620, 250);
            TotemPos[3] = new Vector2(500, 100);
            //CIRCULOS

            //Azul
            circuloApos[0] = new Vector2(30, 370);
            circuloApos[1] = new Vector2(150, 220);
            circuloApos[2] = new Vector2(570, 370);
            circuloApos[3] = new Vector2(450, 220);

            //Rojos
            circuloRpos[0] = new Vector2(155, 370);
            circuloRpos[1] = new Vector2(275, 220);
            circuloRpos[2] = new Vector2(695, 370);
            circuloRpos[3] = new Vector2(575, 220);
        }

        public void LoadContent(ContentManager content)
        {
            // Cargar los sprites para el Jugador 1
            ProtaCamUp = LoadSprites(content, "Sprites/SpritePlayers", "player1_up");
            ProtaCamDown = LoadSprites(content, "Sprites/SpritePlayers", "player1_down");
            ProtaCamLeft = LoadSprites(content, "Sprites/SpritePlayers", "player1_left");
            ProtaCamRight = LoadSprites(content, "Sprites/SpritePlayers", "player1_right");
            // Cargar los sprites para el Jugador 2
            ProtaCamUpJugador2 = LoadSprites(content, "Sprites/SpritePlayers", "player2_up");
            ProtaCamDownJugador2 = LoadSprites(content, "Sprites/SpritePlayers", "player2_down");
            ProtaCamLeftJugador2 = LoadSprites(content, "Sprites/SpritePlayers", "player2_left");
            ProtaCamRightJugador2 = LoadSprites(content, "Sprites/SpritePlayers", "player2_right");
            frameWidth = ProtaCamRight[0].Width / 4;

            //cargar totem
            for (int i = 0; i <= 3; i++)
            {
                Totem[i] = content.Load<Texture2D>("Sprites/Totems/totem");
            }


            for (int i = 0; i <= 3; i++)
            {
                circuloR[i] = content.Load<Texture2D>("Sprites/Totems/O");
                circuloA[i] = content.Load<Texture2D>("Sprites/Totems/O");
            }

        }

        //metodos falopa no lo volvere a hacer , creo
        private Texture2D[] LoadSprites(ContentManager content, string ruta, string jugadormov)
        {
            Texture2D[] sprites = new Texture2D[4];
            for (int i = 0; i < 4; i++)
            {
                string assetPath = $"{ruta}/{jugadormov}{i + 1}";
                sprites[i] = content.Load<Texture2D>(assetPath);
            }
            return sprites;
        }

        //UPDATES
        public bool UpdateJugador1(KeyboardState keyboardState, GameTime gameTime)
        {
            bool isMoving = false;

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                currentDirectionJugador1 = Direction.Up;
                jugador1Position.Y -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                currentDirectionJugador1 = Direction.Down;
                jugador1Position.Y += 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentDirectionJugador1 = Direction.Left;
                jugador1Position.X -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                currentDirectionJugador1 = Direction.Right;
                jugador1Position.X += 2;
                isMoving = true;
            }

            if (keyboardState.IsKeyDown(Keys.Enter) && !lastKeyboardStateJugador1.IsKeyDown(Keys.Enter))
            {
                jugador2Activo = true;
            }

            if (currentDirectionJugador1 != lastDirectionJugador1)
            {
                lastDirectionJugador1 = currentDirectionJugador1;
            }

            if (isMoving)
            {
                animationTimerJugador1 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimerJugador1 > frameDuration)
                {
                    frameactualJugador1 = (frameactualJugador1 + 1) % 4;
                    animationTimerJugador1 = 0f;
                }
            }

            lastKeyboardStateJugador1 = keyboardState;

            return isMoving;
        }
        public bool UpdateJugador2(KeyboardState keyboardState, GameTime gameTime)
        {
            bool isMoving = false;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                currentDirectionJugador2 = Direction.Up;
                jugador2Position.Y -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                currentDirectionJugador2 = Direction.Down;
                jugador2Position.Y += 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                currentDirectionJugador2 = Direction.Left;
                jugador2Position.X -= 2;
                isMoving = true;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                currentDirectionJugador2 = Direction.Right;
                jugador2Position.X += 2;
                isMoving = true;
            }

            if (currentDirectionJugador2 != lastDirectionJugador2)
            {
                lastDirectionJugador2 = currentDirectionJugador2;
            }

            if (isMoving)
            {
                animationTimerJugador2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (animationTimerJugador2 > frameDuration)
                {
                    frameactualJugador2 = (frameactualJugador2 + 1) % 4;
                    animationTimerJugador2 = 0f;
                }
            }

            return isMoving;
        }

        //COLISIONES , ACTIVACIONES , ETC
        bool[] circuloRojoActivo = new bool[4];
        bool[] circuloAzulActivo = new bool[4];
        public bool PongActivo = false;
        public void Update(GameTime gameTime)
        {
            Rectangle[] totemRects = new Rectangle[4];
            for (int i = 0; i < 4; i++)
            {
                totemRects[i] = new Rectangle((int)TotemPos[i].X, (int)TotemPos[i].Y, Totem[0].Width, Totem[0].Height);
                circuloRojoActivo[i] = false;
                circuloAzulActivo[i] = false;
            }

            Rectangle player1Rect = new Rectangle((int)jugador1Position.X, (int)jugador1Position.Y, frameWidth, ProtaCamUp[0].Height);
            Rectangle player2Rect = new Rectangle((int)jugador2Position.X, (int)jugador2Position.Y, frameWidth, ProtaCamUpJugador2[0].Height);

            Rectangle[] circuloRRects = new Rectangle[4];
            Rectangle[] circuloARects = new Rectangle[4];
            for (int i = 0; i < 4; i++)
            {
                circuloRRects[i] = new Rectangle((int)circuloRpos[i].X, (int)circuloRpos[i].Y, circuloR[i].Width, circuloR[i].Height);
                circuloARects[i] = new Rectangle((int)circuloApos[i].X, (int)circuloApos[i].Y, circuloA[i].Width, circuloA[i].Height);
            }

            // Verificar colisiones y activar eventos
            for (int i = 0; i < 4; i++)
            {
                if (player1Rect.Intersects(circuloRRects[i]))
                {
                    circuloRojoActivo[i] = true;
                }
                else
                {
                    circuloRojoActivo[i] = false;
                }

                if (player2Rect.Intersects(circuloARects[i]))
                {
                    circuloAzulActivo[i] = true;
                }
                else
                {
                    circuloAzulActivo[i] = false;
                }
            }

            bool circuloRojo0Activo = circuloRojoActivo[0];
            bool circuloAzul0Activo = circuloAzulActivo[0];

            // Verificar si ambos jugadores están en la posición adecuada y "Enter" fue presionado
            if (circuloRojo0Activo && circuloAzul0Activo && Keyboard.GetState().IsKeyDown(Keys.Enter) && !PongActivo)
            {
                PongActivo = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //circulos
            Rectangle CirculoAzul = new Rectangle(0, 0, 24 * 2, 19 * 2);
            Rectangle CirculoRojo = new Rectangle(24 * 2, 0, 24 * 2, 19 * 2);
            for (int i = 0; i <= 3; i++)
            {
                spriteBatch.Draw(circuloR[i], circuloRpos[i], CirculoRojo, Color.White);
                spriteBatch.Draw(circuloA[i], circuloApos[i], CirculoAzul, Color.White);
            }

            DrawPlayer(spriteBatch, jugador1Position, ProtaCamUp, ProtaCamDown, ProtaCamLeft, ProtaCamRight, frameactualJugador1, currentDirectionJugador1);

            if (jugador2Activo)
            {
                DrawPlayer(spriteBatch, jugador2Position, ProtaCamUpJugador2, ProtaCamDownJugador2, ProtaCamLeftJugador2, ProtaCamRightJugador2, frameactualJugador2, currentDirectionJugador2);
            }

            //totems 
            Rectangle Inactivo = new Rectangle(0, 0, 24 * 3, 46 * 3);
            Rectangle RojoA = new Rectangle(24 * 3, 0, 24 * 3, 46 * 3);
            Rectangle AzulA = new Rectangle(48 * 3, 0, 24 * 3, 46 * 3);
            Rectangle Activo = new Rectangle(72 * 3, 0, 24 * 3, 46 * 3);

            //Eventos en caso de que los jugadores se posicionen encima de los circulos correspondientes
            for (int i = 0; i < 4; i++)
            {
                if (circuloRojoActivo[i] && circuloAzulActivo[i])
                {
                    spriteBatch.Draw(Totem[0], TotemPos[i], Activo, Color.White);
                }
                else if (circuloRojoActivo[i])
                {
                    spriteBatch.Draw(Totem[0], TotemPos[i], RojoA, Color.White);
                }
                else if (circuloAzulActivo[i])
                {
                    spriteBatch.Draw(Totem[0], TotemPos[i], AzulA, Color.White);
                }
                else
                {
                    spriteBatch.Draw(Totem[0], TotemPos[i], Inactivo, Color.White);
                }
            }

        }

        private void DrawPlayer(SpriteBatch spriteBatch, Vector2 position, Texture2D[] up, Texture2D[] down, Texture2D[] left, Texture2D[] right, int frameactual, Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    spriteBatch.Draw(up[frameactual], position, Color.White);
                    break;
                case Direction.Down:
                    spriteBatch.Draw(down[frameactual], position, Color.White);
                    break;
                case Direction.Left:
                    spriteBatch.Draw(left[frameactual], position, Color.White);
                    break;
                case Direction.Right:
                    spriteBatch.Draw(right[frameactual], position, Color.White);
                    break;
                default:
                    spriteBatch.Draw(right[frameactual], position, Color.White);
                    break;
            }
        }

        public void Reset()
        {
            jugador1Position = new Vector2(350, 480);
            frameactualJugador1 = 0;
            animationTimerJugador1 = 0f;
            currentDirectionJugador1 = Direction.Right;
            lastDirectionJugador1 = Direction.Right;
            lastKeyboardStateJugador1 = new KeyboardState();
            jugador2Activo = false;
            jugador2Position = new Vector2(400, 480);
            frameactualJugador2 = 0;
            animationTimerJugador2 = 0f;
            currentDirectionJugador2 = Direction.Right;
            lastDirectionJugador2 = Direction.Right;
        }
    }
}