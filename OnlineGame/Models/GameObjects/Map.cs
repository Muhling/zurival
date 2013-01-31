using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameObjects
{
    public class MapObject
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<MapTileBlockObject> MapTileBlocks { get; set; }

        public MapObject(Map map)
        {
            Id = map.Id;
            Created = map.Created;

            MapTileBlocks = map.MapTileBlocks.Select(mt => new MapTileBlockObject(mt.Id, mt.PositionIndex, mt.MapTileBlockType, mt.MapTiles.ToList())).ToList();
        }
    }
}
