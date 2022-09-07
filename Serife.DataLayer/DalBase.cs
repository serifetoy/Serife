using Serife.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.DataLayer
{
    public class DalBase<TEntity> where TEntity:class
    {
        ChatAppContext chatAppContext = new ChatAppContext();

        public int Add(TEntity entity)
        {
            chatAppContext.Set<TEntity>().Add(entity);
            return chatAppContext.SaveChanges();
        }
        public int Delete(TEntity entity)
        {
            chatAppContext.Set<TEntity>().Remove(entity);
            return chatAppContext.SaveChanges();

            //DalBase baseToDelete = chatAppContext.FirstOrDefault(p => p.ProductId== _dalBase.ProductId);
            //chatAppContext.Remove(baseToDelete);
        }
        public int Update(TEntity entity)
        {
            chatAppContext.Set<TEntity>().Update(entity);
            return chatAppContext.SaveChanges();

        }

    }
}