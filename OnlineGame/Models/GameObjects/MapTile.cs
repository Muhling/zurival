using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameObjects
{

    public class MapTileObject
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public MapTileTypeObject MapTileType { get; set; }

        public MapTileObject(int id, int x, int y, int width, int height, MapTileType tileType, MapTileBlockType mapTileBlockType)
        {
            Id = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            MapTileType = new MapTileTypeObject(tileType.Id, tileType.Name, tileType.MovementAllowed, tileType.Background, mapTileBlockType);
            
        }
    }
}
