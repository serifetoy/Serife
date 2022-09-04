using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalUser : DalBase<User>
    {
        ChatAppContext chatAppContext = new ChatAppContext();
        public User? GetById(int id)
        {

            return chatAppContext.Set<User>().FirstOrDefault(x => x.UserId == id);
        }
        public List<User> GetUsers()
        {

            return chatAppContext.Set<User>().ToList();


        }

        public User? GetByUserName(string username)
        {

            return chatAppContext.Set<User>().FirstOrDefault(x => x.Username == username);
        }

        public bool Any(int? idExcept = null, string? email = null, string? userName = null)
        {

            return chatAppContext.Users.
                Any(x =>
                            (!idExcept.HasValue || x.UserId == idExcept) &&
                            (string.IsNullOrEmpty(email) || x.Email == email) &&
                            (string.IsNullOrEmpty(userName) || x.Username == userName)
                            );

        }

        public User? GetBy(int? id = null, string? email = null, string? userName = null)
        {

            return chatAppContext.Users.
                Where(x =>
                            (!id.HasValue || x.UserId == id) &&
                            (string.IsNullOrEmpty(email) || x.Email == email) &&
                            (string.IsNullOrEmpty(userName) || x.Username == userName)
                            ).FirstOrDefault();

        }


    }
}
