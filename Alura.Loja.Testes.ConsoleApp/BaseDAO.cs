using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Alura.Loja.Testes.ConsoleApp
{
    public abstract class BaseDAO<T> where T : class
    {
        private DbSet<T> _table;
        public BaseDAO(DbSet<T> table)
        {
            _table = table;
        }
        protected IList<T> Get(Expression<Func<T, bool>> filterFunction)
        {
            return _table.Where(filterFunction).ToList();
        }

        protected IList<T> GetAll()
        {
            return _table.ToList();
        }

        protected void Add(T input) 
        {
            _table.Add(input);
        }

        protected void Update(T input)
        {
            _table.Update(input);
        }

        protected void Remove(T input)
        {
            _table.Remove(input);
        }
    }
}