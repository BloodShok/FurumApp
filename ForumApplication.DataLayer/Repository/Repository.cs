using ForumApplication.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataLayer.Repository
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext Context { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public void AddNewItem(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void DeleteItem(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteItemById(object id)
        {
            var item = DbSet.Find(id);
            DeleteItem(item);
        }

        public TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.Select(x => x).Page().ToList();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispouse()
        {
            Context.Dispose();
        }
    }
}
