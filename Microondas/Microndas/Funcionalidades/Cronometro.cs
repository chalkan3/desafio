using System;
using System.IO;
using System.Threading;


namespace ClassMicrondas
{
    class Cronometro
    {
        private int minuto { get; set; }
        private int segundo { get; set; }
        private int qtdTotal { get; set; }
        private int qtdPausada { get; set; }

        private int qtdMaximaMin { get; set; }
        private int qtdMinimaMin { get; set; }
        private Arquivo arquivo { get; set; }
        private StreamWriter escritor;
        


        public Cronometro(int QtdHorasTotal, int qtdMaximaMin , int qtdMinimaMin )
        {
            qtdTotal = QtdHorasTotal;
            segundo = 0;
            minuto = 0;
            qtdPausada = 0;
            arquivo = new Arquivo();
            this.qtdMaximaMin = qtdMaximaMin;
            this.qtdMinimaMin = qtdMinimaMin;

        }


        public void LancarCronometro(string stringaCozinhar,string caminho)
        {
            var sec = this.segundo = 0;
            var min = this.minuto = 0;
            bool parar = false;


            Console.WriteLine("Digite <ESC>  para cancelar a contagem, Digite <F1> para pausar.");

            if(qtdPausada != 0)
            {
                Console.WriteLine("Deseja retornar da pausa S/N. ");
                if(Console.ReadLine().ToLower() == "s")
                {
                    ReordernarTempo(qtdPausada);
                }

                qtdPausada = 0;


            }

            if (arquivo.ArquivoExiste(caminho))
            {
                escritor = arquivo.EscreverArquivo(caminho) ;
            }
           

            for (int i = 0; i < this.qtdTotal; i++)
            {   
                //lança a tread para poder ficar lendo o input 

                Thread thread = new Thread(() => {
                    parar = CancelarCronometro();
                    parar = PausarCronometro(this.qtdTotal, i);

                });

                thread.Start();

                if (parar)
                {
                    break;
                }

               
                if(escritor != null)
                {
                    escritor.WriteLine(stringaCozinhar);
                }
                Console.WriteLine(stringaCozinhar);
                Thread.Sleep(1000);
                sec++;

                if(sec == 60)
                {
                    sec = 0;
                    minuto++;
                }




            }
            Console.WriteLine("aquecida");

            if (escritor != null)
            {
                escritor.WriteLine("aquecida");
                // escritor.Close();
               
    
            }
           
        }


        public void ReordernarTempo(int qtdTotal)
        {
            this.qtdTotal = qtdTotal;
        }


        public void RecomecarCronometro(string stringaCozinhar, string caminho)
        {
            LancarCronometro(stringaCozinhar,caminho);
        }


        private bool PausarCronometro(int total, int interador)
        {
            if(Console.ReadKey(true).Key == ConsoleKey.F1)
            {
                this.qtdPausada = (total - interador) - 1;
                return true;
            }

            return false;
        }

       
        private bool CancelarCronometro()
        {
               
           if(Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                this.segundo = 0;
                this.minuto = 0;
                Console.WriteLine("Cancelado.");

                return true;
            }


            return false;
        
           
        }

    }
}
