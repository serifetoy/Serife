using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalGroup : DalBase<Group>
    {
        ChatAppContext chatAppContext = new ChatAppContext();


        public List<Group> GetList(int id)
        {
            return chatAppContext.Set<Group>()
                                 .Where(x => x.GroupId == id)
                                 .ToList();
        }

        public bool Any(int? idExcept = null, string? name = null, int? createrUserId = null)
        {

            return chatAppContext.Groups.
                Any(x =>
                            (!idExcept.HasValue || x.GroupId == idExcept) &&
                            (!createrUserId.HasValue || x.CreaterUserId == createrUserId) &&
                            (string.IsNullOrEmpty(name) || x.Name == name)
                            );
        }

        public Group? GetBy(int? id = null, int? createrUserId = null, string? name = null)
        {

            return chatAppContext.Groups.
                Where(x =>
                            (!id.HasValue || x.GroupId == id) &&
                            (!createrUserId.HasValue || x.CreaterUserId == createrUserId) &&
                            (string.IsNullOrEmpty(name) || x.Name == name)).FirstOrDefault();

        }
    }
}