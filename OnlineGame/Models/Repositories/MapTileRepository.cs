using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class MapTileRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public void Add(MapTile mapTile)
        {
            db.MapTiles.InsertOnSubmit(mapTile);
        }

        public void Delete(MapTile mapTile)
        {
            db.MapTiles.DeleteOnSubmit(mapTile);
        }

        //public List<MapTile> GetMapTilesByMapId(int id)
        //{
        //    return db.MapTiles.Where(mt => mt.MapId == id).ToList();
        //}

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
