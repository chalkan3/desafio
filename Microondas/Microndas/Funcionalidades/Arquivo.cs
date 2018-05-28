
using System;
using System.Collections.Generic;
using System.IO;


namespace ClassMicrondas
{
    class Arquivo
    {
        private bool existeArquivo { get; set; }


        public Arquivo()
        {
            existeArquivo = false;
        }

        public string[] LerArquivo(string caminho)
        {

            Stream arquivo = AbrirArquivo(caminho);
            List<string> listaInput = new List<string>();
            if (arquivo != null)

            {
                StreamReader leitor = new StreamReader(arquivo);
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    listaInput.Add(linha);
                    linha = leitor.ReadLine();
                }

                arquivo.Close();
                leitor.Close();

            }
            else
            {
                Console.WriteLine("Arquivo já está aberto.");
            }
            
            return listaInput.ToArray();
        }

        public StreamWriter EscreverArquivo(string caminho)
        {
            Stream arquivo = AbrirArquivo(caminho);

            if (arquivo != null)
            {
                StreamWriter escritor = new StreamWriter(arquivo);

                return escritor;

            }
            else
            {
                Console.WriteLine("Arquivo já está aberto.");
               
                return null;
            }


        }


        private Stream AbrirArquivo(string caminho)
        {
            Stream arquivo = null;
            try
            {
                arquivo = File.Open(caminho, FileMode.Open, FileAccess.ReadWrite);

            }
            catch (IOException) {
                return arquivo;
            }

            

            return arquivo;


        }

        public bool ArquivoExiste(string caminho)
        {
            return File.Exists(caminho);
        }

      
    }
}
