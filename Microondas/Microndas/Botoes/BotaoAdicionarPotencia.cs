using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMicrondas
{
    class BotaoAdicionarPotencia : Botao
    {
        private Funcionalidades Funcionalidades { get; set; }
        private int Potencia;

        public BotaoAdicionarPotencia(Funcionalidades Funcionalidades, int Potencia, string Label) : base(Label)
        {
            this.Funcionalidades = Funcionalidades;
            this.Potencia = Potencia;
        }

        public void AlterarPotencia()
        {
            try
            {
                Funcionalidades.CalcularPotencia(Potencia);
                Console.WriteLine("Potencia alterada");

            }
            catch (MicrondasException e)
            {
                Console.WriteLine(e.Message);


            }
        }
    }
}