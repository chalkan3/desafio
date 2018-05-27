using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMicrondas
{
    class BotaoTrocarProduto : Botao
    {
        private string NovoProduto { get; set; }
        private Arquivo Arquivo { get; set; }
        private string NomeArquivo { get; set; }
        private string Produto { get; set; }

        public BotaoTrocarProduto(string NovoProduto, Arquivo Arquivo, string Label) : base(Label)
        {
            this.NovoProduto = NovoProduto;
            this.Arquivo = Arquivo;
        }

        public Tuple<string,string> TrocarProduto()
        {
           bool Earquivo = Arquivo.ArquivoExiste(NovoProduto);
            if (Earquivo)
            {
                string[] linhas = Arquivo.LerArquivo(NovoProduto);
                if (linhas.Length > 0)
                {
                    NomeArquivo = NovoProduto;
                    Produto = linhas[0];

                    return Tuple.Create(NomeArquivo, Produto);
                    
                }
                else
                {
                    return Tuple.Create("", "");
                }
            }

            return Tuple.Create("", NovoProduto);

        }


    }
}
