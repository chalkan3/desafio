using System;
using System.Collections.Generic;

namespace ClassMicrondas
{
    class BotaoCriarNovo : Botao
    {
        private string Nome { get; set; }
        private int Tempo { get; set; }
        private int Potencia { get; set; }
        private string Instrucao { get; set; }
        private string Aquecimento { get; set; }
        private List<Funcionalidades> Produtos { get; set; }

        public BotaoCriarNovo(string Nome, int Tempo, int Potencia, string Instrucao, string Aquecimento, List<Funcionalidades> Produtos, string Label) : base(Label)
        {
            this.Nome = Nome;
            this.Tempo = Tempo;
            this.Potencia = Potencia;
            this.Instrucao = Instrucao;
            this.Aquecimento = Aquecimento;
            this.Produtos = Produtos;
        }


        public void CriarNovo()
        {
            try
            {
                Produtos.Add(new Funcionalidades(Tempo, Potencia, Instrucao, Nome, Aquecimento));
                Console.WriteLine("Criado");

            }
            catch (MicrondasException e)
            {
                Console.WriteLine(e.Message);

            }
        }


    }
}
