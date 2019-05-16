using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolStudents.Domain;
using SchoolStudents.Domain.Models;

namespace SchoolStudentsApi.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SchoolContext context;
        internal DbSet<TEntity> dbset;


        public GenericRepository(SchoolContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeproperties in includeProperties.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeproperties);
            }

            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        
        public virtual TEntity GetById(object id)
        {
            return dbset.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbset.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delet(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }

            dbset.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
