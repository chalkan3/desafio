using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMicrondas
{
    class BotaoEscolherUm : Botao
    {
        private List<Funcionalidades> FuncionalidadesList { get; set; }
        private Funcionalidades Funcionalidades { get; set; }
        private string Produto { get; set; }
        private string NomeArquivo { get; set; }

        public BotaoEscolherUm(List<Funcionalidades> FuncionalidadesList,string Produto, string NomeArquivo, string Label) : base(Label)
        {
            this.FuncionalidadesList = FuncionalidadesList;
            this.Produto = Produto;
            this.NomeArquivo = NomeArquivo;

        }


        public void Opcoes()
        {
            Console.WriteLine("Escolha um produto de nossa memoria para poder aquecer: =>");
            foreach (Funcionalidades item in FuncionalidadesList)
            {
                Console.WriteLine(item.Nome);
            }
        }

        public void EscolherUm(string Line)
        {
            Funcionalidades = FuncionalidadesList.Find(p => p.Nome.ToLower() == Line.ToLower());

            Console.WriteLine("O Produto escolhido tem essas especificações");
            Console.WriteLine(Funcionalidades);
        }

        public void DispararEvento(string Disparar)
        {
            Console.WriteLine("O Produto escolhido tem essas especificações");
            Console.WriteLine(Funcionalidades);
            Console.WriteLine("Deseja usar este? S ou N");

            if (Disparar == "s")
            {
                Funcionalidades.Aquecer(Produto, NomeArquivo);
            }
            else
            {
                Console.WriteLine("Opção Invalida.");
            }
        }





    }
}
