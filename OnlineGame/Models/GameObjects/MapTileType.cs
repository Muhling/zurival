using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameObjects
{
    public class MapTileTypeObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool MovementAllowed { get; set; }
        public string Background { get; set; }
        public MapTileBlockTypeObject MapTileBlockType { get; set; }

        public MapTileTypeObject(int id, string name, bool movementAllowed, string background, MapTileBlockType mapTileBlockType)
        {
            Id = id;
            Name = name;
            MovementAllowed = movementAllowed;
            Background = background;
            MapTileBlockType = new MapTileBlockTypeObject(mapTileBlockType.Id, mapTileBlockType.Name);
        }
    }
}
