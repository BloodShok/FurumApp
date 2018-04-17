using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbContext Context { get; set; }
        DbSet<TEntity> DbSet { get; set; }
        TEntity GetByID(object id);                               
        IList<TEntity> GetAll(int pagenumber, int pageSize);     
        void AddNewItem(TEntity entity);
        void DeleteItem(TEntity entity);                          
        void DeleteItemById(object id);                           
    }
}
