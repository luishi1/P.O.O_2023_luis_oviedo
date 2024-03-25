using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SharpDX.XAPO.Fx;
using SharpDX.Direct3D9;

//Ódiame por piedad yo te lo pido
//Ódiame sin medida ni clemencia
//Odio quiero más que indiferencia
//Porque el rencor quiere menos que el olvido
//Ódiame por piedad yo te lo pido
//Ódiame sin medida ni clemencia
//Odio quiero más que indiferencia
//Porque el rencor quiere menos que el olvido
//Si tú me odias quedare yo convencido
//De que me amaste mujer con insistencia
//Pero ten presente de acuerdo a la experiencia
//Que tan sólo se odia lo querido
//Pero ten presente de acuerdo a la experiencia
//Que tan sólo se odia lo querido
//¿Que vale más? yo humilde y tú orgullosa
//¿O vale más tu débil hermosura?
//Piensa que en el fondo de la fosa
//Llevaremos la misma vestidura
//¿Que vale más? yo humilde y tú orgullosa
//¿O vale más tu débil hermosura?
//Piensa que en el fondo de la fosa
//Llevaremos la misma vestidura
//Si tú me odias quedaré yo convencido
//De que me amaste mujer con insistencia
//Pero ten presente de acuerdo a la experiencia
//Que tan sólo se odia lo querido
//Pero ten presente de acuerdo a la experiencia
//Que tan sólo se odia lo querido

namespace Juego.Clases
{
    internal class MenuPlayers
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private bool nadajaja;
        //Plataformas / objetos?
        private Plataforma Suelo;
        private Plataforma Techo;
        public Plataforma PlataformaMadera;
        public Plataforma Palo;
        public Arcade Arcadesx;

        public List<Plataforma> PlataformasMadera = new List<Plataforma>();
        public List<Plataforma> Palos = new List<Plataforma>();
        public List<Arcade> Arcades = new List<Arcade>();

        public Texture2D Fondos;
        public int NumeroEscena = 0;
        public int EscenaActual = 0;

        public bool aparecejugador2 = false;
        public MenuPlayers(Vector2 posicionJugador1, string rutaSpritesheetJugador1, Vector2 posicionJugador2, string rutaSpritesheetJugador2)
        {
            jugador1 = new Jugador(posicionJugador1, rutaSpritesheetJugador1);
            jugador2 = new Jugador(posicionJugador2, rutaSpritesheetJugador2);

            jugador1.pos = new Vector2(10,200);
            jugador1.TeclaDerecha = Keys.D;
            jugador1.TeclaIzquierda = Keys.A;
            jugador1.TeclaAbajo = Keys.S;
            jugador1.TeclaArriba = Keys.W;
            jugador1.TeclaEnter = Keys.Y;
            jugador1.TeclaCorrer = Keys.LeftShift;

            jugador1.pos = new Vector2(10, 300);
            jugador2.TeclaDerecha = Keys.Right;
            jugador2.TeclaIzquierda = Keys.Left;
            jugador2.TeclaAbajo = Keys.Down;
            jugador2.TeclaArriba = Keys.Up;
            jugador2.TeclaEnter = Keys.NumPad1;
            jugador2.TeclaCorrer = Keys.RightShift;

            Suelo = new Plataforma(new Vector2(0,500), "Sprites/MenuTiles/Suelo" , true , false , false);
            Techo = new Plataforma(new Vector2(0,0), "Sprites/MenuTiles/Suelo", true , true , false);

            PlataformasMadera.Add(PlataformaMadera = new Plataforma(new Vector2(50,452), "Sprites/MenuTiles/PlataformaMadera", true, false, false));
            PlataformasMadera.Add(PlataformaMadera = new Plataforma(new Vector2(310,452), "Sprites/MenuTiles/PlataformaMadera", true, false, false));
            PlataformasMadera.Add(PlataformaMadera = new Plataforma(new Vector2(430,429), "Sprites/MenuTiles/PlataformaMadera", true, false, false));
            PlataformasMadera.Add(PlataformaMadera = new Plataforma(new Vector2(560,417), "Sprites/MenuTiles/PlataformaMadera", true, false, false));

            Palos.Add(Palo = new Plataforma(new Vector2(54,460), "Sprites/MenuTiles/Palosv1", false, false, false));
            Palos.Add(Palo = new Plataforma(new Vector2(314,460), "Sprites/MenuTiles/Palosv1", false, false, false));
            Palos.Add(Palo = new Plataforma(new Vector2(434,437), "Sprites/MenuTiles/Palosv2", false, false, false));
            Palos.Add(Palo = new Plataforma(new Vector2(564,425), "Sprites/MenuTiles/Palosv3", false, false, false));

            Arcades.Add(Arcadesx = new Arcade(new Vector2(584, 367), "Sprites/Arcades/arcadebase", true, false, false));
        }

        public void ResetearPosicionesJugadores()
        {
            jugador1.PosicionJugador = new Vector2(10, 200); // Posición original del jugador 1
            jugador2.PosicionJugador = new Vector2(10, 300); // Posición original del jugador 2
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState teclado = Keyboard.GetState();

            if (jugador1.PosicionJugador.X > 800 && jugador2.PosicionJugador.X > 800)
            {
                if (NumeroEscena >= 0)
                {
                    NumeroEscena++;
                    ResetearPosicionesJugadores();
                }
                if (NumeroEscena == 3)
                {

                }
                EscenaActual = NumeroEscena;
            }


            // Actualizar jugador1 
            if (!jugador1.desaparecido)
            {
                jugador1.Update(gameTime);
                jugador1.ActualizarEstados(teclado, gameTime);
                jugador1.Movimiento(teclado);
            }

            if (teclado.IsKeyDown(Keys.NumPad2))
            {
                aparecejugador2 = true;
            }

            if (aparecejugador2)
            {
                if (!jugador2.desaparecido)
                {
                    // Actualizar jugador2
                    jugador2.Update(gameTime);
                    jugador2.ActualizarEstados(teclado, gameTime);
                    jugador2.Movimiento(teclado);
                }
            }

            VerificarColisionPlataformas(jugador1, teclado);
            VerificarColisionPlataformas(jugador2, teclado);


            jugador1.desaparecido = LogicaArcade(jugador1, teclado, Arcades[0] , nadajaja);
            if (aparecejugador2)
            {
                jugador2.desaparecido = LogicaArcade(jugador2, teclado, Arcades[0], nadajaja);
            }
            CambioIndiceArcade(Arcades[0]);


        }
        private void CambioIndiceArcade(Arcade arcade) 
        {
            if (jugador1.desaparecido && jugador2.desaparecido)
            {
                arcade.indicecambio = 3;
            }
            else if (jugador1.desaparecido)
            {
                arcade.indicecambio = 1;
            }
            else if (jugador2.desaparecido)
            {
                arcade.indicecambio = 2;
            }
            else
            {
                arcade.indicecambio = 0;
            }
        }
        private void VerificarColisionPlataformas(Jugador jugador , KeyboardState teclado)
        {
            Rectangle hitboxJugador = jugador.ObtenerHitboxJugador();

            // Colisión con el suelo
            if (Suelo.EsTangible && Suelo.ColisionaConJugador(hitboxJugador))
            {
                jugador.PosicionJugador.Y = Suelo.Posicion.Y - jugador.ObtenerAlturaCuadroActual();
                jugador.EnSuelo = true;
                jugador.VelocidadY = 0;
                jugador.EstabaSaltando = false;
            }
            // Colisión con el techo
            else if (Techo.EsTangible && Techo.ColisionaConJugador(hitboxJugador))
            {
                jugador.PosicionJugador.Y = Techo.Posicion.Y + Techo.Textura.Height;
                jugador.VelocidadY = 0;
            }
            // Colisión con las plataformas (superficie)
            else
            {
                bool jugadorSobrePlataforma = false;

                foreach (var platformacion in PlataformasMadera)
                {
                    if (platformacion.EsTangible)
                    {
                        if (platformacion.ColisionaConJugador(hitboxJugador))
                        {
                            jugadorSobrePlataforma = true;

                            if (hitboxJugador.Top < platformacion.Posicion.Y && hitboxJugador.Bottom > platformacion.Posicion.Y)
                            {
                                jugador.PosicionJugador.Y = platformacion.Posicion.Y - jugador.ObtenerAlturaCuadroActual();
                                jugador.EnSuelo = true;
                                jugador.VelocidadY = 0;
                            }
                            else if (hitboxJugador.Bottom > platformacion.Posicion.Y + platformacion.Textura.Height)
                            {
                                jugador.PosicionJugador.Y = platformacion.Posicion.Y + platformacion.Textura.Height;
                                jugador.VelocidadY = 0;
                                jugador.EnSuelo = false;
                            }
                        }
                    }
                }

                //palos para que sirvan como techo
                foreach (var palo in Palos)
                {
                    if (palo.EsTangible)
                    {
                        if (palo.ColisionaConJugador(hitboxJugador) && hitboxJugador.Bottom > palo.Posicion.Y)
                        {
                            jugador.PosicionJugador.Y = palo.Posicion.Y + palo.Textura.Height;
                            jugador.VelocidadY = 0;
                            jugador.EnSuelo = false;
                        }
                    }
                }

                if (!jugadorSobrePlataforma)
                {
                    jugador.EnSuelo = false;
                }
            }

        }

        public bool VerificarColisionArcade(Jugador jugador, KeyboardState teclado, Arcade arcade)
        {
            Rectangle hitboxJugador = jugador.ObtenerHitboxJugador();
            Rectangle hitboxArcade = arcade.ObtenerHitboxArcade();

            bool colision = hitboxJugador.Intersects(hitboxArcade);
            bool interaccion = colision;
            return interaccion;
        }

        public bool LogicaArcade(Jugador jugador, KeyboardState teclado, Arcade arcade , bool juegoactivado)
        {
            bool enterPresionado = teclado.IsKeyDown(jugador.TeclaEnter);
            bool colisionArcade = VerificarColisionArcade(jugador, teclado, arcade);
            if ((colisionArcade && enterPresionado) || (jugador.desaparecido && enterPresionado))
            {
                jugador.desaparecido = !jugador.desaparecido;
                juegoactivado = !juegoactivado;
                arcade.indicecambio = jugador.desaparecido ? 1 : 0;
            }


            return jugador.desaparecido;
        }

        public void LoadContent(ContentManager content)
        { 
             
            Fondos = content.Load<Texture2D>("Sprites/MenuTiles/Fondos");
            jugador1.LoadContent(content);
            jugador2.LoadContent(content);
            Suelo.LoadContent(content);
            Techo.LoadContent(content);
            foreach (var plataformas in PlataformasMadera)
            {
                plataformas.LoadContent(content);
            }
            foreach (var paloss in Palos)
            {
                paloss.LoadContent(content);
            }
            foreach (var arcadess in Arcades)
            {
                arcadess.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<Rectangle> Escenarios = new List<Rectangle>();
            for (int i = 0; i < 4; i++)
            {
                Rectangle Escenario = new Rectangle(i * 800, 0, 800, 600);
                Escenarios.Add(Escenario);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Fondos, new Vector2(0, 0), Escenarios[NumeroEscena], Color.White); 


            foreach (var arcades in Arcades)
            {
                arcades.Draw(spriteBatch);
            }

            if (jugador1.desaparecido == false)
            {
                jugador1.Draw(spriteBatch);
            }
            if (jugador2.desaparecido == false)
            {
                if (aparecejugador2)
                {
                    jugador2.Draw(spriteBatch);
                }
            }
            Suelo.Draw(spriteBatch);
            Techo.Draw(spriteBatch);

            foreach (var plataformasss in PlataformasMadera)
            {
                plataformasss.Draw(spriteBatch);
            }

            foreach (var paloss in Palos)
            {
                paloss.Draw(spriteBatch);
            }

            spriteBatch.End();
            //hitbox
            spriteBatch.Begin();
            //jugador1.DrawHitbox(spriteBatch);
            //jugador2.DrawHitbox(spriteBatch);
            //Suelo.DrawHitbox(spriteBatch);
            //Techo.DrawHitbox(spriteBatch);
            spriteBatch.End();

        }
    }
}
//Anotarme : si quiero modificar algo en varias lineas uso ALT y luego selecciono k kpo que soy