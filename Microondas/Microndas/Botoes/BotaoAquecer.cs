using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMicrondas
{
    class BotaoAquecer : Botao
    {
        private string NomeDoArquivo;
        private string Produto;
        private Funcionalidades Funcionalidade;

        public BotaoAquecer(string NomeDoArquivo, string Produto, Funcionalidades Funcionalidade, string Label) : base(Label)
        {
            this.NomeDoArquivo = NomeDoArquivo;
            this.Produto = Produto;
            this.Funcionalidade = Funcionalidade;

        }

        public void Aquecer()
        {
            Funcionalidade.Aquecer(Produto, NomeDoArquivo);
        }
    }
}
