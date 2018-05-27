using System;


namespace ClassMicrondas
{
    class Funcionalidades
    {

        private int Tempo { get; set; }
        private int Potencia { get; set; }
        private string Instrucoes { get; set; }
        public string Nome { get; protected set; }
        private string CozimentoString { get; set; }
        private Cronometro Cronometro { get; set; }


        public Funcionalidades(int Tempo, int Potencia, string Instrucoes, string Nome, string CozimentoString)
        {

            if (Tempo > 120 || Tempo < 1) {
                throw new MicrondasException("Tempo Não valido. O tempo deve ser menor ou igual a 2 minutos ou maior que 1 segundo");
            }
            else
            {
                this.Tempo = Tempo;
            }
            if (Potencia > 10 || Potencia < 1)
            {
                this.Potencia = 1;
                throw new MicrondasException("Potencia não está dentro dos padrões definido. a potencia vai de 1 a 10");


            }
            else
            {
                this.Potencia = Potencia;

            }

            if (Instrucoes == "")
            {
                throw new MicrondasException("Instruções não podem ser vazias.");

            }
            else
            {
                this.Instrucoes = Instrucoes;

            }


            if(Nome == "")
            {
                throw new MicrondasException("Nome Não pode estar em branco.");

            }
            else
            {
                this.Nome = Nome;

            }

            if(CozimentoString == "")
            {
                throw new MicrondasException("String de cozimento nao pode ficar vazia");

            }
            else
            {
                this.CozimentoString = CozimentoString;

            }

            Cronometro = new Cronometro(this.Tempo, 1, 2);

        }


        //Aquecer Action para aquecer a string 
        public void Aquecer(string produto,string caminho)
        {
            string StringCozinhada;
            StringCozinhada = CozinharString();

            Cronometro.ReordernarTempo(this.Tempo);
            Cronometro.LancarCronometro(produto + StringCozinhada,caminho);
            

        }


        //CalcularTempo Cria um novo tempo e valida se for maior que 2 minutos ou menor que 1 segundo
        public void CalcularTempo(int Tempo)
        {
            if (Tempo > 120 || Tempo < 1)
            {
                throw new MicrondasException("Tempo Não valido. O tempo deve ser menor ou igual a 2 minutos ou maior que 1 segundo");
            }
            else
            {
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
            if (Potencia != 8)
            {
                this.Potencia = Potencia;
            }
            else
            {
                this.Potencia = 8;
            }


            if (Tempo != 3)
            {
                this.Tempo = Tempo;
            }
            else
            {
                this.Tempo = 3;

            }
        }


        //Cria a quantidade de pontos na string cozinhada
        public string CozinharString()
        {
            string StringCozinhada = "";

            for (int i = 0; i < this.Potencia; i++)
            {
                StringCozinhada = StringCozinhada + this.CozimentoString;
            }
            return StringCozinhada;
        }





        public override string ToString()

        {

            return string.Format("Potencia: {0}, Tempo: {1}, Nome: {2}, Intrucoes: {3}", Potencia, Tempo, Nome, Instrucoes);

        }

    }
}






