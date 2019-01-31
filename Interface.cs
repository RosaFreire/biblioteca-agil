using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Biblioteca_Ágil
{
    class Interface
    {
        private Gerenciador gerenciador;
        private ArrayList livros;
        private Leitor leitor;
        

        public Interface()
        {
            this.gerenciador = new Gerenciador();
            this.livros = gerenciador.GerarListaLivros();
            this.leitor = new Leitor();
        }

        //Inicializando menu
        public void Inicio()
        {
            bool controle = true;
            do
            {
                Console.WriteLine("Pressione: ");
                Console.WriteLine("1 para CONSULTAR a lista de livros");
                Console.WriteLine("2 para RETIRAR um livro");
                Console.WriteLine("3 para DEVOLVER um livro");
                Console.WriteLine("4 para DOAR um livro");
                Console.WriteLine("5 para SAIR");

                //int key = int.Parse(Console.ReadLine());
                string key = Console.ReadLine();

                Console.Clear();
                int numero = 0;

                //verificando se entrada é compativel
                if (int.TryParse(key, out numero))
                {
                        //atribuindo entrada a metodos
                        switch (int.Parse(key))
                        {
                            case 1:
                                ConsultarLista();
                                Console.WriteLine("1) Deseja retirar um livro?");
                                Console.WriteLine("2) Voltar ao menu inicial. ");
                                int op = int.Parse(Console.ReadLine());

                                switch (op)
                                {
                                    case 1:
                                        Console.Clear();
                                        RetirarLivro();
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 2:
                                Console.Clear();
                                RetirarLivro();
                                break;

                            case 3:
                                DevolverLivro();
                                break;

                            case 4:
                                DoarLivro();
                                break;

                            default:
                                controle = false;
                                break;
                        }                    
                }
                else
                {
                    Console.WriteLine("Digite um valor valido.");
                }

            } while (controle);
        }

    //metodo para gerar lista de livros existentes
    public void ConsultarLista()
        {
            foreach (Livros livro in this.livros)
            {
                Console.WriteLine("Numero: " + livro.GetNumero());
                Console.WriteLine("Título: " + livro.GetTitulo());
                Console.WriteLine("Autor: " + livro.GetAutor());
                Console.WriteLine("Ano: " + livro.GetAno());
                string dispo = "Disponível";
                if (livro.GetDisponibilidade()== false) {
                    dispo = "Indisponível";
                }
                Console.WriteLine("Disponibilidade: " + dispo);
                Console.WriteLine("Emprestimo: " + livro.GetEmprestimo());
                Console.WriteLine();
            }
        }

        // metodo para realizar retirada
        public void RetirarLivro()
        {
            double numeroLivro;
            string nome;
            
            ConsultarLista();
            
            Console.WriteLine("Digite o numero do livro desejado");

            numeroLivro = double.Parse(Console.ReadLine());

            foreach (Livros livro in this.livros)
            {
                if (numeroLivro == livro.GetNumero())
                {
                    if (livro.GetDisponibilidade())
                    {
                        livro.SetDisponibilidade(false);
                        Console.Write("Digite o Seu nome: ");
                        nome = Console.ReadLine();
                        livro.SetEmprestimo(nome);
                        Console.WriteLine(livro.GetEmprestimo() + ", você retirou o livro: " + livro.GetTitulo() + " de " + livro.GetAutor());
                        Console.WriteLine("Pressione Enter.");
                    }
                    else
                    {
                        Console.WriteLine("Este livro está indisponível.");
                        Console.WriteLine("Esta com: " + livro.GetEmprestimo());
                        Console.WriteLine("Pressione Enter.");
                    }
                }
                
            }
            Console.ReadLine();
            Console.Clear();

            Registrar();
        }

        //metodo para possibilitar devolução
        public void DevolverLivro()
        {
            Console.WriteLine("Digite o número do livro");
            int numeroDevolucao = int.Parse(Console.ReadLine());

            foreach (Livros livro in this.livros)
            {
                if (numeroDevolucao == livro.GetNumero())
                {
                    livro.SetDisponibilidade(true);
                    livro.SetEmprestimo(" - ");
                Console.WriteLine("Você devolveu o livro: " + livro.GetTitulo() + " de " + livro.GetAutor());
                }
            }
            Console.WriteLine("Obrigado(a)!");
            Console.WriteLine("Pressione Enter.");
            Console.ReadLine();
            Console.Clear();

            Registrar();
        }

       // alterar adicionando livro a lista de livros
        public void DoarLivro()
        {
          
            Console.WriteLine("Ensira as informações nos campos abaixo: ");

            double num = livros.Count;
            double numero = num + 1;

            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Console.WriteLine("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            bool disponivel = true;
            string emprestimo = " -";

            Livros livro = new Livros(numero, titulo, autor, ano, disponivel, emprestimo);
            livros.Add(livro);

            ConsultarLista();

            Console.WriteLine("Pressione Enter.");
            Console.ReadLine();
            Console.Clear();

            Registrar();
        } 

        //alterar arquivo txt
        public void Registrar()
        {
            ArrayList linhas = new ArrayList();
            foreach (Livros livro in this.livros)
            {
                linhas.Add(livro.Registrar());
            }
            leitor.EscreverArquivo(linhas);
        }

    }   
}
