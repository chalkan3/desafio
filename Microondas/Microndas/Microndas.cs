


using System;

namespace ClassMicrondas
{
    class Microndas {
        private int Tempo { get; set; }
        private int Potencia { get; set; }

        public Microndas(int Tempo, int Potencia) {
            this.Tempo = Tempo;
            this.Potencia = Potencia;
        }

        //Aquecer Action para aquecer a string 
        public void Aquecer(string produto) {
            string StringCozinhada;
            StringCozinhada = CozinharString();

            for (int i = 0; i < this.Tempo; i++) {
                Console.WriteLine(produto + StringCozinhada);
            }

            Console.WriteLine("aquecida");
        }


        //CalcularTempo Cria um novo tempo e valida se for maior que 2 minutos ou menor que 1 segundo
        public void CalcularTempo(int Tempo) {
            if (Tempo > 120 || Tempo < 1)
            {
                throw new MicrondasException("Tempo Não valido. O tempo deve ser menor ou igual a 2 minutos ou maior que 1 segundo");
            }
            else {
                this.Tempo = Tempo;
            }

        }
        //CalcularPotencia Troca o valor da potencia e valida caso for menor que 1 ou maior que 10
        public void CalcularPotencia(int Potencia)
        {
            if (Potencia > 10 || Potencia < 1)
            {
                this.Potencia = 1;
                throw new MicrondasException("Potencia não está dentro dos padrões definido. a potencia vai de 1 a 10");
            }
            else
            {
                this.Potencia = Potencia;
            }

        }

        //InicioRapido Opção de inicio rapido do usuario , deixei os parametros para caso queira mudar o programador terá a liberade Não era necessario pois o contrutor já faz isso
        //Porem queria criar uma função para isso.

        public void InicioRapido(int Potencia, int Tempo)
        {
            if (Potencia != 8) {
                this.Potencia = Potencia;
            }
            else {
                this.Potencia = 8;
            }


            if (Tempo != 3) {
                this.Tempo = Tempo;
            }
            else {
                this.Tempo = 3;

            }
        }

        //PainelInterativo Função estatica para gerar o painel principal de escolhas
        public static void PainelInterativo(Microndas Micro)
        {
            char Opcao;
            string Produto;
            int Potencia;
            int Tempo;

            Console.WriteLine("Informe o nome do produto");
            Produto = Console.ReadLine();

            if (Produto != ""){
                Console.WriteLine("Bem vindo ao menu interativo do microndas. Por Favor Digite uma das opçoes");
                Console.WriteLine("Digite T para mudar o tempo (Tempo inicial: 1 segundo) ");
                Console.WriteLine("Digite P para mudar a potencia (Potencia inicial: 10 watts)");
                Console.WriteLine("Deseja utilizar o modo rapido aperte R ");


                do
                {
                    Opcao = char.Parse(Console.ReadLine());
                    switch (char.ToLower(Opcao))
                    {
                        case 't':
                            Console.WriteLine("Escolha o valor do novo Tempo");
                            Tempo = int.Parse(Console.ReadLine());

                            try
                            {
                                Micro.CalcularTempo(Tempo);
                                Console.WriteLine("Tempo alterado");

                            }
                            catch (MicrondasException e)
                            {
                                Console.WriteLine(e.Message);

                            }

                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) ou a(Aquecer) ou se deseja sair S(Sair)");
                            break;

                        case 'p':
                            Console.WriteLine("Escolha o valor  da nova potencia");

                            Potencia = int.Parse(Console.ReadLine());

                            try {
                                Micro.CalcularPotencia(Potencia);
                                Console.WriteLine("Potencia alterada");

                            }
                            catch (MicrondasException e)
                            {
                                Console.WriteLine(e.Message);

                            }


                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) a(Aquecer) ou se deseja sair S(Sair)");

                            break;
                        case 'r':
                            Console.WriteLine("O inicio rapido foi ativo.");

                            Micro.InicioRapido(3,30);
                            Micro.Aquecer(Produto);

                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) ou a(Aquecer) ou se deseja sair S(Sair)");

                            break;
                        case 'a':
                            Micro.Aquecer(Produto);
                            break;

                        default:
                            Console.WriteLine("Opção invalida. Escolha T(tempo), P(potencia) ou R(inializcao rapida) Ou se deseja sair S(Sair)");
                            break;
                    }
                } while (char.ToLower(Opcao) != 's');
                
            }
            else
            {
                Console.WriteLine("Informe o nome do produto");
                Produto = Console.ReadLine();
            }
           
        }

        //Cria a quantidade de pontos na string cozinhada
        private string CozinharString()
        {
            string StringCozinhada = "";
               
            for (int i = 0; i < this.Potencia; i++){
                StringCozinhada = StringCozinhada + ".";
            }
            return StringCozinhada;
        }


        public override string ToString(){
            return Tempo
                + ", "
                + Potencia;
        }

    }
}
