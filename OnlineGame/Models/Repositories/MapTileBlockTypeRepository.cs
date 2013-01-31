using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class MapTileBlockTypeRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public void Add(MapTileBlockType mapTileBlockType)
        {
            db.MapTileBlockTypes.InsertOnSubmit(mapTileBlockType);
        }

        public void Delete(MapTileBlockType mapTileBlockType)
        {
            db.MapTileBlockTypes.DeleteOnSubmit(mapTileBlockType);
        }

        public List<MapTileBlockType> GetBlockTypes()
        {
            return db.MapTileBlockTypes.ToList();
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
