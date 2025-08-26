using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;
using Entity.Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       
        private DbSet<T> table = null;
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            table = _context.Set<T>();
        }

        IEnumerable<T> IGenericRepository<T>.GetAll()
        {
            return table.ToList();
        }

        IEnumerable<T> IGenericRepository<T>.GetAllMenus()
        {
            return table.ToList();
        }

        IEnumerable<T> IGenericRepository<T>.GetTypesOfItems()
        {
            return table.ToList();
        }

        public T GetById(object? id)
        {
            return table.Find(id);
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }

     
        public void Delete(object id)
        {
            T existing = GetById(id);
            table.Remove(existing);
        }

        public void Update(T entity)
        {
           table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        IList<T> IGenericRepository<T>.GetAllVendors()
        {
            return table.ToList(); // Assuming T is a type that represents vendors
        }



        // private static int _nextId = 1;


        //public GenericRepository()
        //{
        //    context = new List<Item>()
        //    {
        //        new Item
        //        {
        //            ID = 1,
        //            ItemName = "Laptop",
        //            ItemNo = 1001,
        //            Quantity = 10,
        //            Price = 1500.00m
        //        }
        //    };
        //}

        //public void Add(Item entity)
        //{


        //  //  entity.ItemNo = entity.ID;

        //    context.Add(entity);
        //}



        //public IList<Item> GetAll()
        //{
        //    return context.Items.ToList();
        //}

        //public Item GetById(int id)
        //{
        //    var item = context.Items.ToList().FirstOrDefault(i => i.ID == id);
        //    if (item == null)
        //    {
        //        throw new KeyNotFoundException($"Item with ID {id} not found.");
        //    }
        //    return item;
        //}

        //public void Update(Item entity , int id)
        //{
        //    var existingItem = GetById(id);
        //    if (existingItem != null)
        //    {
        //        existingItem.ItemName = entity.ItemName;
        //       // existingItem.ItemNo = entity.ItemNo;
        //        existingItem.Quantity = entity.Quantity;
        //        existingItem.Price = entity.Price;
        //        existingItem.ParchingPrice = entity.ParchingPrice;

        //    }
        //    else
        //    {
        //        throw new KeyNotFoundException($"Item with ID {entity.ID} not found.");
        //    }


        //}

        //public IList<Menus> GetAllMenus()
        //{
        //    return context.Menus.ToList();
        //}

        //IList<T> IGenericRepository<T>.GetAll()
        //{
        //    return context.Items.ToList().Cast<T>().ToList(); // Assuming T is Item or a derived type
        //}

        //IList<T> IGenericRepository<T>.GetAllMenus()
        //{
        //    return context.Menus.ToList().Cast<T>().ToList(); // Assuming T is Menus or a derived type
        //}

        //T IGenericRepository<T>.GetById(int id)
        //{
        //    var entity = context.Set<T>().FirstOrDefault(e => e.ID == id);
        //    return entity ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
        //}

        //void IGenericRepository<T>.Add(T entity)
        //{
        //  context.Set<T>().Add(entity);
        //}
        //public void Delete(int id)
        //{
        //    var item = context.Set<T>().FirstOrDefault(e => e.ID == id);
        //    if (item == null)
        //    {
        //        throw new KeyNotFoundException($"Item with ID {id} not found.");
        //    }
        //    context.Remove(item);
        //}
        //public void Update(T entity, int id)
        //{
        //    var existingEntity = context.Set<T>().FirstOrDefault(e => e.ID == id);
        //    if (existingEntity != null)
        //    {
        //        context.Entry(existingEntity).CurrentValues.SetValues(entity);
        //    }
        //    else
        //    {
        //        throw new KeyNotFoundException($"Entity with ID {id} not found.");
        //    }
        //}
    }
}
