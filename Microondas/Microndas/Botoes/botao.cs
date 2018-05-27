using System;

namespace ClassMicrondas
{
    class Botao
    {
        private string Label { get; set; }

        public Botao(string Label)
        {
            this.Label = Label;
        }

        public void BotaoLabelSet(string Label)
        {
            this.Label = Label;
        }

        public void MostrarLabel()
        {
            Console.WriteLine(Label);
        }

    }
}
