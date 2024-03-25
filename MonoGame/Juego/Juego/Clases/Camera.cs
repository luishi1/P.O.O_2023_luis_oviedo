using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Juego.Clases
{
    internal class Camera
    {
        public Matrix transform;
        Vector2 position;

        public Camera()
        {

        }

        public void Update(Vector2 playerPosition, float newZoom)
        {
            position = playerPosition - new Vector2(12 / (2 * newZoom), 510 / (2 * newZoom));
            transform = Matrix.CreateScale(new Vector3(newZoom, newZoom, 0)) *
                        Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
        }
    }
}

//Those who inherited the curse of the Zen'in family...
//The one who couldn't fully leave behind that curse...
//They would all bear witness to the bare flesh of the one who is free. To the one who left it all behind! And his overwhelming intensity!