using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Biblioteca_Ágil
{
    class Gerenciador
    {
        string line;

        private Leitor leitor;
        private string[] baseDados;

        public Gerenciador()
        {
            this.leitor = new Leitor();
            this.baseDados = this.leitor.LerArquivo();
        }

        //criar objetos "Livro" a partir de dados apurados
        public ArrayList GerarListaLivros()
        {

           ArrayList dados = ObterDadosPorLinha(this.baseDados);

            ArrayList livros = new ArrayList();
           
           foreach (string[] dado in dados)
           {
                
               double numero = ConversorDeString(dado[0]);
               string titulo = dado[1];
               string autor = dado[2];
               double ano = ConversorDeString(dado[3]);
               bool disponivel = ConversorDeStringParaBoolean(dado[4]);
               string emprestimo = dado[5];
          
               Livros livro = new Livros(numero, titulo, autor, ano, disponivel, emprestimo);
               livros.Add(livro);
            }

            return livros;
        }

       //converter string para bool
        private bool ConversorDeStringParaBoolean(string args)
        {
            return Convert.ToBoolean(args);
        }


        //converter string para double
        private double ConversorDeString(string args)
        {
           return Convert.ToDouble(args.Trim());
        }

        //metodos para seprar informções de arqquivo externo txt
        public string[] ObterDados(string args)
        {
            return args.Split(';');
        }

        private ArrayList ObterDadosPorLinha(string[] linhas)
        {
            ArrayList list = new ArrayList();
            foreach (string linha in linhas)
            {
                list.Add(ObterDados(linha));
            }
            return list;
        }
      
    }
}
