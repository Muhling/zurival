using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories
{
    public class MapRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public void Add(Map map)
        {
            db.Maps.InsertOnSubmit(map);
        }

        public void Delete(Map map)
        {
            db.Maps.DeleteOnSubmit(map);
        }

        public Map GetMap()
        {
            return db.Maps.First();
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
