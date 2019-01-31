using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Ágil
{
    class Livros
    {
        //atributos da classe livro
        double numero, ano;
        string titulo, autor, emprestimo;
        bool disponivel;
        
        //construtor para definição de valores a atributos
        public Livros(double numero, string titulo, string autor, double ano, bool disponivel, string emprestimo) {
            this.numero = numero;
            this.titulo = titulo;
            this.autor = autor;
            this.ano = ano;
            this.disponivel = disponivel;
            this.emprestimo = emprestimo;
        }

        //métodos para acessar atributos com nivel de proteção
        public double GetNumero()
        {
            return this.numero;
        }

        public string GetTitulo()
        {
            return this.titulo;
        }

        public string GetAutor()
        {
            return this.autor;
        }
        public double GetAno()
        {
            return this.ano;
        }
        public bool GetDisponibilidade() {
            return this.disponivel;
        }
        public string GetEmprestimo() {
            return this.emprestimo;
        }
        public void SetDisponibilidade(bool disponibilidade) {
            disponivel = disponibilidade;
        }
        public void SetEmprestimo(string nome)
        {
            emprestimo = nome;
        }

        public string Registrar() {
            return GetNumero() + ";" + GetTitulo() + ";" + GetAutor() + ";" + GetAno() + ";" + GetDisponibilidade() + ";" + GetEmprestimo() + ";";
        }
    }

}

