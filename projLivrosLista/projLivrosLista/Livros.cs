using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Livros
    {
        private List<Livro> acervo;

        public List<Livro> Acervo { get { return this.acervo; } }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            if (this.pesquisar(livro) != null) throw new Exception("Já existe um livro com esse ISBN.");
            this.acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            return this.acervo.FirstOrDefault(item => item.Equals(livro));
        }
    }
}
