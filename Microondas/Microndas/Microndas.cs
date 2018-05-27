using System;
using System.Collections.Generic;

namespace ClassMicrondas
{
    class Microondas
    {
        private Display Display;

        public Microondas()
        {
            Display = new Display();
        }


        public void LigarMicroondas()
        {
            Display.mostrarPainelInterativo();
        }
       
    }
}






