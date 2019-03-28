using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projLivrosLista
{
    class Program
    {
        static Livros livros = new Livros();

        static void Main(string[] args)
        {
            
            string op = "";
            Console.BackgroundColor = ConsoleColor.DarkGray;

            do
            {
        

                Console.Clear();
                Console.SetCursorPosition(19, 3);
                Console.WriteLine("--------------------------------------");
                Console.SetCursorPosition(19, 4);
                Console.WriteLine("| (0) Sair                           |");
                Console.SetCursorPosition(19, 5);
                Console.WriteLine("--------------------------------------");
                Console.SetCursorPosition(19, 6);
                Console.WriteLine("| (1) Adicionar um livro             |");
                Console.SetCursorPosition(19, 7);
                Console.WriteLine("| (2) Buscar por um livro de análise |");
                Console.SetCursorPosition(19, 8);
                Console.WriteLine("| (3) Buscar por um livro de síntese |");
                Console.SetCursorPosition(19, 9);
                Console.WriteLine("| (4) Adicionar um exemplar          |");
                Console.SetCursorPosition(19, 10);
                Console.WriteLine("| (5) Registrar empréstimo           |");
                Console.SetCursorPosition(19, 11);
                Console.WriteLine("| (6) Lançar uma devolução           |");
                Console.SetCursorPosition(19, 12);
                Console.WriteLine("--------------------------------------");
                Console.SetCursorPosition(19, 14);
                Console.Write("Digite uma opção: ");
               

                

                try
                {

                    op = Console.ReadLine();
                    
                    switch (op)
                    {
                        case "0": break;
                        case "1": adicionarLivro(); break;
                        case "2": pesquisarLivroSintetico(); break;
                        case "3": pesquisarLivroAnalitico(); break;
                        case "4": adicionarExemplar(); break;
                        case "5": registrarEmprestimo(); break;
                        case "6": registrarDevolucao(); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
             
            } while (op != "0");

            System.Environment.Exit(0);
        }

        static void adicionarLivro()
        {

            Console.Write("\n FORNEÇA O ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());
            if (livros.pesquisar(new Livro(isbn)) != null) throw new Exception("Já existe um livro com esse ISBN");

            Console.Write("\n Forneça as informações a seguir do livro correspondente... ");
            Console.Write("\nTÍTULO: ");
            string titulo = Console.ReadLine();
            Console.Write("AUTOR: ");
            string autor = Console.ReadLine();
            Console.Write("EDITORA: ");
            string editora = Console.ReadLine();

            livros.adicionar(new Livro(isbn, titulo, autor, editora));
            Console.WriteLine("Seu livro foi cadastrado com sucesso.");
            Console.ReadKey();
        }

        static void pesquisarLivroSintetico()
        {

            Console.Write("\nISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());
            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null) throw new Exception("Livro não encontrado.");

            Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
            Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");

            Console.ReadKey();
        }

        static void pesquisarLivroAnalitico()
        {

            Console.Write("\nISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());
            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null) throw new Exception("LIVRO NÃO ENCONTRADO, VERIFIQUE AS INFORMAÇÕES E TENTE NOVAMENTE.");

            Console.WriteLine("Total de exemplares: " + livro.qtdeExemplares());
            Console.WriteLine("Total de exemplares disponíveis: " + livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + livro.qtdeEmprestimos());
            Console.WriteLine("Percentual de disponibilidade: " + livro.percDisponibilidade().ToString("0.00") + "%");

            Console.ReadKey();

            livro.Exemplares.ForEach(i => {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Tombo: " + i.Tombo);
                i.Emprestimos.ForEach(j => {
                    String devolucao = (j.DtDevolucao != DateTime.MinValue) ? j.DtDevolucao.ToString() : "-------------------";
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Data Empréstimo: " + j.DtEmprestimo);
                    Console.WriteLine("Data Devolução:  " + devolucao);
                });
            });

            Console.ReadKey();
        }

        static void adicionarExemplar()
        {

            Console.Write("\nDigite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null) throw new Exception("Livro não encontrado.");

            Console.Write("Digite o Tombo: ");
            int tombo = Int32.Parse(Console.ReadLine());
            livro.adicionarExemplar(new Exemplar(tombo));
            Console.WriteLine("Exemplar cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void registrarEmprestimo()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null) throw new Exception("Livro não encontrado.");

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.emprestar());
            if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " emprestado com sucesso!");
            else throw new Exception("Não há exemplares disponíveis.");

            Console.ReadKey();
        }

        static void registrarDevolucao()
        {
            Console.Write("\nDigite o ISBN: ");
            int isbn = Int32.Parse(Console.ReadLine());

            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null) throw new Exception("Livro não encontrado.");

            Exemplar exemplar = livro.Exemplares.FirstOrDefault(i => i.devolver());
            if (exemplar != null) Console.WriteLine("Exemplar " + exemplar.Tombo + " devolvido com sucesso!");
            else Console.WriteLine("Não há exemplares emprestados.");
            Console.ReadKey();
        }
    }
}