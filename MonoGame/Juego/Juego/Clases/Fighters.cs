using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Juego.Clases
{
    internal class Fighters
    {
        private Texture2D prox;

        public Fighters() 
        {

        }

        public void LoadContent(ContentManager content) 
        {
            prox = content.Load<Texture2D>("Sprites/Totems/PROXIMAMENTE");
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(prox , new Vector2(0,0), Color.White);
        }

        public void Reset()
        {
          
        }
    }
}
