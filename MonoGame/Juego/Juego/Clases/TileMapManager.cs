using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite;
using MonoGame.Aseprite.Content.Processors;
using MonoGame.Aseprite.Tilemaps;


namespace Juego.Clases
{
    internal class TileMapManager
    {
        public AsepriteFile ArchivoMap;
        public Tilemap Mapa;
        public TileMapManager()
        {
            LoadContent();
        }

        public void LoadContent() 
        {
            ArchivoMap = AsepriteFile.Load("C:\\Users\\Alejandro Oviedo\\Desktop\\P.O.O_2023_luis_oviedo\\MonoGame\\Juego\\Juego\\Content\\Mapas\\MapaCarrera\\MapaPista01.aseprite");
            Mapa = TilemapProcessor.Process(Variables._graphics, ArchivoMap, 0);
        }

        public void Draw()
        {
            Mapa.Draw(Variables._spritebatch,Vector2.Zero,Color.White);
        }
    }
}
