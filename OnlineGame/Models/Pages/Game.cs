using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.GameObjects;

namespace Models.Pages
{
    public class GameViewModel
    {
        public MapObject Map { get; set; }

        public GameViewModel(MapObject map)
        {
            Map = map;
        }
    }
}
