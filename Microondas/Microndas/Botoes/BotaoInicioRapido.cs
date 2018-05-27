using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMicrondas
{
    class BotaoInicioRapido : Botao
    {
        private Funcionalidades Funcionalidades { get; set; }
        private int Potencia { get; set; }
        private int Tempo { get; set; }
        private string Produto { get; set; }
        private string NomeArquivo { get; set; }

        public BotaoInicioRapido(Funcionalidades Funcionalidades, int Potencia, int Tempo, string Produto, string NomeArquivo, string Label) : base(Label)
        {
            this.Funcionalidades = Funcionalidades;
            this.Potencia = Potencia;
            this.Tempo = Tempo;
            this.Produto = Produto;
            this.NomeArquivo = NomeArquivo;  
        }

        public void IniciarRapido()
        {
            Funcionalidades.InicioRapido(3, 30);
            Funcionalidades.Aquecer(Produto, NomeArquivo);
        }




    }
}
