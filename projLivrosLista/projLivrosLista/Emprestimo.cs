using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;


        public Emprestimo(DateTime dtEmp)
        {
            this.dtEmprestimo = dtEmp;
        }

        public DateTime DtEmprestimo
        {
            get { return this.dtEmprestimo; }
            set { this.dtEmprestimo = value; }
        }

        public DateTime DtDevolucao
        {
            get { return this.dtDevolucao; }
            set { this.dtDevolucao = value; }
        }
    }
}
