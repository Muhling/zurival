using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineGame.Models;

namespace Models.Repositories
{
    public class AccountRepository
    {
        OnlineGameDataContext db = new OnlineGameDataContext();

        public bool UserIsValid(string email, string password)
        {
            var user = GetUserByEmail(email);
            if (user != null)
            {
                var salt = user.Salt;
                var passwordHash = Encrypting.GetMd5Hash(password, salt);

                return db.Users.Any(u => u.Email == email && u.Password == passwordHash);
            }
            else
                return false;
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            db.Users.InsertOnSubmit(user);
        }

        public void Delete(User user)
        {
            db.Users.DeleteOnSubmit(user);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
