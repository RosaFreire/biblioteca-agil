using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Biblioteca_Ágil
{
    class Leitor
    {
        //metodo para ler arquivo txt externo
        public string[] LerArquivo()
        {
            string[] lines = System.IO.File.ReadAllLines(@"arquivo.txt");
            return lines;
        }

        //metodo para alterar arquivo txt externo
        public void EscreverArquivo(ArrayList linhas) {
            string[] l = (string[])linhas.ToArray(typeof(string));

            System.IO.File.WriteAllLines(@"arquivo.txt", l);
        }

    }
}
