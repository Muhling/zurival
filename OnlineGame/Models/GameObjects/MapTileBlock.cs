using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameObjects
{
    public class MapTileBlockObject
    {
        public int Id { get; set; }
        public MapTileBlockTypeObject MapTileBlockType { get; set; }
        public int PositionIndex { get; set; }
        public List<MapTileObject> MapTiles { get; set; }

        public MapTileBlockObject(int id, int positionIndex, MapTileBlockType mapTileBlockType, List<MapTile> tiles)
        {
            Id = id;
            PositionIndex = positionIndex;
            MapTileBlockType = new MapTileBlockTypeObject(mapTileBlockType.Id, mapTileBlockType.Name);
            MapTiles = tiles.Select(mt => new MapTileObject(mt.Id, mt.X, mt.Y, mt.Width, mt.Height, mt.MapTileType, mapTileBlockType)).ToList();
        }
    }
}
