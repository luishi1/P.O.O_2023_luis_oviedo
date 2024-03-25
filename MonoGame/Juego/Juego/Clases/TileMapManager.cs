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
        public string MapaSeleccionado { get; set; }

        public TileMapManager()
        {

        }

        public void LoadContent()
        {
            ArchivoMap = AsepriteFile.Load(MapaSeleccionado);
            Mapa = TilemapProcessor.Process(Variables._graphics, ArchivoMap, 0);
        }

        public void Draw()
        {
            Mapa.Draw(Variables._spritebatch, Vector2.Zero, Color.White);
        }
    }
}