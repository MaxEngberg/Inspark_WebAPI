using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InsparkWebApi.Repositories.Base
{
    public class Repository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public virtual DbSet<T> Items => context.Set<T>();
        //Method for adding an item to the database. 
        public virtual void Add(T item)
        {
            Items.Add(item);
        }
        //Method for editing an item in the database.
        public virtual void Edit(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        //Method for getting an item with a specific id in the database.
        public virtual T GetById(int id)
        {
            return Items.Find(id);
        }
        //Method for removing an item with a specific id in the database.
        public virtual void Remove(int id)
        {
            var entity = GetById(id);
            Items.Remove(entity);
        }
        //Method for saving the changes made in the database.
        public virtual void SaveChanges(T item)
        {
            context.SaveChanges();
        }
        //Method for searching inside the provided Model-Item.
        public virtual IQueryable<T> SearchFor(Expression<Func<T, bool>> text)
        {
            return Items.Where(text);
        }
        //Method for showing all items.
        public virtual IQueryable<T> ShowAll()
        {
            return Items;
        }
    }
}

