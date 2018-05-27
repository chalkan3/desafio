using System;
using System.Collections.Generic;

namespace ClassMicrondas
{
    class BotaoMostrarTodos : Botao
    {
        private List<Funcionalidades> Funcionalidades { get; set; }

        public BotaoMostrarTodos(List<Funcionalidades> Funcionalidades, string Label) : base(Label)
        {
            this.Funcionalidades = Funcionalidades;
        }

        public void MostrarTodos()
        {
            foreach (Funcionalidades item in Funcionalidades)
            {
                Console.WriteLine(item);
            }
        }
    }
}
