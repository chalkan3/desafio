using System;


namespace ClassMicrondas
{
    class BotaoAdicionarTempo : Botao
    {
        private Funcionalidades Funcionalidades { get; set; }
        private int Tempo;

        public BotaoAdicionarTempo(Funcionalidades Funcionalidades, int Tempo, string Label) : base(Label)
        {
            this.Funcionalidades = Funcionalidades;
            this.Tempo = Tempo;
        }

        public void AlterarTempo()
        {
            try
            {
                Funcionalidades.CalcularTempo(Tempo);
                Console.WriteLine("Tempo alterado");

            }
            catch (MicrondasException e)
            {
                Console.WriteLine(e.Message);

            }
        }

    }
}
