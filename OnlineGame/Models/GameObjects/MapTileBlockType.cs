using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameObjects
{
    public class MapTileBlockTypeObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MapTileBlockTypeObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
