﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Data;
using Entity.Interfaces;
using Services.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _context;
       
        private IGenericRepository<T> _entity;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_context));
            }
        }
        //public IGenericRepository<T> Entity => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
