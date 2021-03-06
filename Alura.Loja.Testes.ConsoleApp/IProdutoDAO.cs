﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public interface IProdutoDAO
    {
        void Adicionar(Produto p);
        void Remover(Produto p);
        void Atualizar(Produto p);
        Produto Get(Produto p);
        IList<Produto> Produtos();
        IList<Produto> Get(string name);
    }
}
