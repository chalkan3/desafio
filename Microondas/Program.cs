using System;
using System.Collections.Generic;
using ClassMicrondas;

namespace MicroondasMain
{
    class Program
    {
        static void Main(string[] args)
        {

            string Opcao;
            string Produto;
            int Potencia;
            int Tempo;

            Funcionalidades Unico;

            List<Funcionalidades> produtos = new List<Funcionalidades>();


            produtos.Add(new Funcionalidades(30, 10, "Padrao", "Padrao","."));
            produtos.Add(new Funcionalidades(2, 2, "Isso e um frango", "Frango","F"));
            produtos.Add(new Funcionalidades(3, 3, "Isso é uma pipica", "Pipoca","P"));
            produtos.Add(new Funcionalidades(4, 4, "Isso é um ovo", "Ovo","O"));
            produtos.Add(new Funcionalidades(5, 5, "Isso é marmelada", "marmelada","M"));



            Console.WriteLine("Informe o nome do produto");
            Produto = Console.ReadLine();

            if (Produto != "")
            {

                Console.WriteLine("Bem vindo ao menu interativo do microndas. Por Favor Digite uma das opçoes");
                Console.WriteLine("Digite mostrar_todos para mostrar todas as programaçoes ");
                Console.WriteLine("Digite escolher_um para escolher uma programacao");
                Console.WriteLine("Digite t para escolher o tempo do programa padrão");
                Console.WriteLine("Digite p para escolher a potencia do programa padrão");
                Console.WriteLine("Deseja utilizar o modo rapido aperte R ");



                do
                {
                    Opcao = Console.ReadLine();
                    switch (Opcao.ToLower())
                    {
                        case "mostrar_todos":
                            foreach (Funcionalidades item in produtos)
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case "escolher_um":
                            string Line = Console.ReadLine().ToLower();

                            Unico = produtos.Find(p => p.Nome.ToLower() == Line.ToLower());
                            Console.WriteLine("O Produto escolhido tem essas especificações");
                            Console.WriteLine(Unico);
                            Console.WriteLine("Deseja usar este? S ou N");

                            string Disparar = Console.ReadLine().ToLower();

                            if ( Disparar == "s")
                            {
                                Unico.Aquecer(Produto);
                            }

                            break;
                        case "criar_novo":

                            Console.WriteLine("Insira o nome");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o tempo");
                            int tempo = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira a potencia");
                            int potencia = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira a instrucao");
                            string instrucao = Console.ReadLine();
                            Console.WriteLine("Insira o caractere de aquecimento");
                            string arquecimento = Console.ReadLine();

                            produtos.Add(new Funcionalidades(tempo, potencia, instrucao, nome, arquecimento));


                            break;
                        case "t":
                            Console.WriteLine("Escolha o valor do novo Tempo");
                            Tempo = int.Parse(Console.ReadLine());

                            try
                            {
                                produtos[0].CalcularTempo(Tempo);
                                Console.WriteLine("Tempo alterado");

                            }
                            catch (MicrondasException e)
                            {
                                Console.WriteLine(e.Message);

                            }

                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) ou a(Aquecer) ou se deseja sair S(Sair)");
                            break;

                        case "p":
                            Console.WriteLine("Escolha o valor  da nova potencia");

                            Potencia = int.Parse(Console.ReadLine());

                            try
                            {
                                produtos[0].CalcularPotencia(Potencia);
                                Console.WriteLine("Potencia alterada");

                            }
                            catch (MicrondasException e)
                            {
                                Console.WriteLine(e.Message);

                            }


                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) a(Aquecer) ou se deseja sair S(Sair)");

                            break;
                        case "r":
                            Console.WriteLine("O inicio rapido foi ativo.");

                            produtos[0].InicioRapido(3, 30);
                            produtos[0].Aquecer(Produto);

                            Console.WriteLine("Escolha T(tempo), P(potencia) ou R(inializcao rapida) ou a(Aquecer) ou se deseja sair S(Sair)");

                            break;
                        case "a":
                            produtos[0].Aquecer(Produto);
                            break;


                        default:
                            Console.WriteLine("Opção invalida. Escolha T(tempo), P(potencia) ou R(inializcao rapida) Ou se deseja sair S(Sair)");
                            break;
                    }
                } while (Opcao.ToLower() != "sim");

            }
            else
            {
                Console.WriteLine("Informe o nome do produto");
                Produto = Console.ReadLine();
            }




            Console.ReadLine();




        }
    }
}
