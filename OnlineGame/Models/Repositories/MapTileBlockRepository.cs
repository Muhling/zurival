using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class MapTileBlockRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public void Add(MapTileBlock mapTileBlock)
        {
            db.MapTileBlocks.InsertOnSubmit(mapTileBlock);
        }

        public void Delete(MapTileBlock mapTileBlock)
        {
            db.MapTileBlocks.DeleteOnSubmit(mapTileBlock);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
