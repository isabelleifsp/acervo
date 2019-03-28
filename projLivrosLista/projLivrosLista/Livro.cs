using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public List<Exemplar> Exemplares { get { return this.exemplares; } }

        // Apenas para pesquisas
        public Livro(int i) { this.isbn = i; }

        public Livro(int i, string t, string a, string e)
        {
            this.isbn = i;
            this.titulo = t;
            this.autor = a;
            this.editora = e;
            this.exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            foreach (Exemplar exemp in this.exemplares)
                if (exemp.Equals(exemplar)) throw new Exception("Já existe um exemplar com este tombo.");
            this.exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return this.exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            int disponiveis = 0;
            this.exemplares.ForEach(item => { if (item.disponivel()) disponiveis++; });
            return disponiveis;
        }

        public int qtdeEmprestimos()
        {
            int emprestados = 0;
            this.exemplares.ForEach(item => emprestados += item.qtdeEmprestimos());
            return emprestados;
        }

        public double percDisponibilidade()
        {
            double exemp = this.qtdeExemplares();
            double disp = this.qtdeDisponiveis();
            return (exemp == 0 || disp == 0) ? 0 : (disp / exemp) * 100;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.isbn.Equals(((Livro)obj).isbn);
            return false;
        }
    }
}
