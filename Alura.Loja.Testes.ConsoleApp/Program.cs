using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarUsandoEntity();
            //RemoverUsandoEntity();
            //RecuperarUsandoEntity();
        }

        private static void RecuperarUsandoEntity()
        {
            using (var context = new LojaContext())
            {
                //var produto = context.Produtos.First();
                //Console.WriteLine("Produto encontrado => " + produto.Nome);
                var dao = new ProdutoDAOEntity(context);
                var x = dao.Get("Harry Potter e a Ordem da Fênix");

            }
        }
        private static void RemoverUsandoEntity()
        {
            using (var context = new LojaContext())
            {
                context.Produtos.RemoveRange(context.Produtos);
                context.SaveChanges();
            }
        }
        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new LojaContext())
            {
                context.Produtos.Add(p);
                context.SaveChanges();
            }
        }

    }
}
