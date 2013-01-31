using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class MapTileTypeRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public void Add(MapTileType mapTileType)
        {
            db.MapTileTypes.InsertOnSubmit(mapTileType);
        }

        public void Delete(MapTileType mapTileType)
        {
            db.MapTileTypes.DeleteOnSubmit(mapTileType);
        }

        public List<MapTileType> GetMapTileTypes()
        {
            return db.MapTileTypes.ToList();
        }

        public MapTileType GetMapTileTypeById(int id)
        {
            return db.MapTileTypes.SingleOrDefault(mtt => mtt.Id == id);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
