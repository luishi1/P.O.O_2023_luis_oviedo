using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Juego.Clases
{
    public static class Variables
    {
        public static GraphicsDevice _graphics { get; set; }

        public static SpriteBatch _spritebatch { get; set; }

        public static ContentManager content { get; set; }

        public static Viewport viewport { get; set; }

    }
}
