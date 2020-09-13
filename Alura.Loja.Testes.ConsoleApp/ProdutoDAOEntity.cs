using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDAOEntity : BaseDAO<Produto>, IProdutoDAO, IDisposable
    {
        private LojaContext _context;
        public ProdutoDAOEntity(LojaContext context) : base(context.Produtos)
        {
            _context = new LojaContext();
        }
        public void Adicionar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            _context.Produtos.Update(p);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return _context.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            _context.Remove(p);
            _context.SaveChanges();
        }

        public Produto Get(Produto p)
        {
            return _context.Produtos.Find(p.Id);
        }
        public Produto Get(int id)
        {
            return _context.Produtos.Find(id);
        }

        private Expression<Func<Produto, bool>> filterByNameExpression(string name)
        {
            Expression<Func<Produto, bool>> exp = (p) => name == p.Nome;
            return exp;
        }

        public IList<Produto> Get(string name)
        {
            return Get(filterByNameExpression(name));
        }

        //private IList<Produto> Get<T>(Func<T, Produto, bool> filterFunction, T input)
        //{
        //    return Get(_context.Produtos, filterFunction, input);
        //}

        //private IList<Produto> Get<T>(Func<T, Produto, bool> filterFunction, T input)
        //{
        //    return context.Produtos.Where(w => filterFunction(input, w)).ToList();
        //}

        //private void LockOperation(Action<Produto> operation, Produto p)
        //{
        //    operation(p);
        //    context.SaveChanges();
        //}

    }
}
