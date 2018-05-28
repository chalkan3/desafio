using System;
using System.Collections.Generic;

namespace ClassMicrondas
{
    class Display
    {
        private string Menssagem { get; set; }
        private string nomeArquivo { get; set; }
        private bool Earquivo;
        private string Opcao;
        private string Produto;
        private int Potencia;
        private int Tempo;
        private Arquivo arquivoObj;

        private BotaoTrocarProduto BotaoTrocar;
        private BotaoMostrarTodos BotaoMostrarTodos;
        private BotaoEscolherUm BotaoEscolherUm;
        private BotaoCriarNovo BotaoCriarNovo;
        private BotaoAdicionarTempo BotaoAdicionarTempo;
        private BotaoAdicionarPotencia BotaoAdicionarPotencia;
        private BotaoInicioRapido BotaoInicioRapido;
        private BotaoAquecer BotaoAquecer;

        public Display()
        {
            Menssagem = "";
        }

        public void AlterarMsg(string Menssagem)
        {
            this.Menssagem = Menssagem;
        }

        public void MostrarMenssagem()
        {
            Console.WriteLine(this.Menssagem);
        }

        private void DisplayCabecalho()
        {
            Console.WriteLine("Bem vindo ao menu interativo do microndas. Por Favor Digite uma das opçoes");
            Console.WriteLine("Digite mostrar_todos para mostrar todas as programaçoes ");
            Console.WriteLine("Digite criar_novo para mostrar todas as programaçoes ");
            Console.WriteLine("Digite escolher_um para escolher uma programacao");
            Console.WriteLine("Digite t para escolher o tempo do programa padrão");
            Console.WriteLine("Digite p para escolher a potencia do programa padrão");
            Console.WriteLine("Digite a para aquecer");

            Console.WriteLine("Deseja utilizar o modo rapido aperte R ");
            Console.WriteLine("Digite trocar_produto para trocar qual produto a ser aquecido. ");
        }

        public void mostrarPainelInterativo()
        {



            List<Funcionalidades> produtos = new List<Funcionalidades>();


            try
            {
                produtos.Add(new Funcionalidades(30, 10, "Padrao", "Padrao", "."));
                produtos.Add(new Funcionalidades(2, 2, "Isso e um frango", "Frango", "F"));
                produtos.Add(new Funcionalidades(3, 3, "Isso é uma pipica", "Pipoca", "P"));
                produtos.Add(new Funcionalidades(4, 4, "Isso é um ovo", "Ovo", "O"));
                produtos.Add(new Funcionalidades(5, 5, "Isso é marmelada", "marmelada", "M"));

            }
            catch (MicrondasException e)
            {
                Console.WriteLine(e.Message);

            }



            Console.WriteLine("Informe o nome do produto ou o caminho do arquivo");
            Produto = Console.ReadLine();


            arquivoObj = new Arquivo();
            Earquivo = arquivoObj.ArquivoExiste(Produto);

            if (Earquivo)
            {
                string[] linhas = arquivoObj.LerArquivo(Produto);
                if (linhas.Length > 0)
                {
                    nomeArquivo = Produto;
                    Produto = linhas[0];

                }
                else
                {
                    nomeArquivo = "";
                    Produto = "";
                }

            }

            if (Produto != "")
            {

                DisplayCabecalho();

                do
                {
                    Opcao = Console.ReadLine();
                    switch (Opcao.ToLower())
                    {
                        case "trocar_produto":
                            Console.WriteLine("Digite o nome do novo produto");
                            Produto = Console.ReadLine();
                            BotaoTrocar = new BotaoTrocarProduto(Produto, arquivoObj, "Item Trocado");
                            BotaoTrocar.MostrarLabel();

                            var tupla =  BotaoTrocar.TrocarProduto();

                            nomeArquivo = tupla.Item1;
                            Produto = tupla.Item2;

                            break;
                        case "mostrar_todos":
                            BotaoMostrarTodos = new BotaoMostrarTodos(produtos, "Listagem de todos os itens");
                            BotaoMostrarTodos.MostrarLabel();
                            BotaoMostrarTodos.MostrarTodos();
                            break;

                        case "escolher_um":
                            BotaoEscolherUm = new BotaoEscolherUm(produtos, Produto, nomeArquivo, "Escolha um produto");
                            BotaoEscolherUm.MostrarLabel();
                            BotaoEscolherUm.Opcoes();

                            string Line = Console.ReadLine().ToLower();
                            BotaoEscolherUm.EscolherUm(Line);

                            Console.WriteLine("Deseja usar este? S ou N");
                            string Disparar = Console.ReadLine().ToLower();
                            BotaoEscolherUm.DispararEvento(Disparar);
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

                            BotaoCriarNovo = new BotaoCriarNovo(nome, tempo, potencia, instrucao, arquecimento, produtos, "Novo Produto");
                            BotaoCriarNovo.MostrarLabel();
                            BotaoCriarNovo.CriarNovo();


                            break;
                        case "t":
                            Console.WriteLine("Escolha o valor do novo Tempo");
                            Tempo = int.Parse(Console.ReadLine());
                            BotaoAdicionarTempo = new BotaoAdicionarTempo(produtos[0], Tempo, "Troca de tempo");
                            BotaoAdicionarTempo.MostrarLabel();
                            BotaoAdicionarTempo.AlterarTempo();
                            break;

                        case "p":
                            Console.WriteLine("Escolha o valor  da nova potencia");

                            Potencia = int.Parse(Console.ReadLine());
                            BotaoAdicionarPotencia = new BotaoAdicionarPotencia(produtos[0], Potencia, "Troca de potencia");
                            BotaoAdicionarPotencia.MostrarLabel();
                            BotaoAdicionarPotencia.AlterarPotencia();
                            break;
                        case "r":
                            BotaoInicioRapido = new BotaoInicioRapido(produtos[0], 3, 30, Produto, nomeArquivo, "O inicio Rapido foi ativo");
                            BotaoInicioRapido.MostrarLabel();
                            BotaoInicioRapido.IniciarRapido();
                            break;
                        case "a":
                            BotaoAquecer = new BotaoAquecer(nomeArquivo, Produto, produtos[0], "Aquecimento iniciado");
                            BotaoAquecer.MostrarLabel();
                            produtos[0].Aquecer(Produto, nomeArquivo);
                            break;


                        default:
                            Console.WriteLine("Opção invalida. Escolha T(tempo), P(potencia) ou R(inializcao rapida) Ou se deseja sair Sim(Sair)");
                            break;
                    }
                } while (Opcao.ToLower() != "sim");

            }
            else
            {
                Console.WriteLine("Informe o nome do produto");
                Produto = Console.ReadLine();
            }
        }



    }
}
