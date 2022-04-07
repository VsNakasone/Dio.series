using System;
using Dio.series.Classes;
using Dio.series.Enumerator;


namespace Dio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1. Listar séries");
            Console.WriteLine("2. Inserir nova série");
            Console.WriteLine("3. Atualizar série");
            Console.WriteLine("4. Excluir série");
            Console.WriteLine("5. Visualizar série");
            Console.WriteLine("C. Limpar Tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID: {0} - Título: {1} - status excluído: {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o índice do gênero entre as opções acima: ");

            int entradaGenero;

            do
            {
                entradaGenero = int.Parse(Console.ReadLine());
                if (entradaGenero < 1 || entradaGenero > 13)
                {
                    Console.Write("Opção Inválida. favor digitar um número entre 1 e 13: ");
                }
            } while (entradaGenero < 1 || entradaGenero > 13);

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                         genero: (Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         ano: entradaAno,
                                         descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }
        private static void AtualizarSerie()
        {
            int indiceSerie;

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada, não é possível atualizar.");
                return;
            }
            else
            {
                do
                {
                    Console.WriteLine("Digite o ID da série: ");
                    indiceSerie = int.Parse(Console.ReadLine());
                    if (indiceSerie < 0 || indiceSerie > lista.Count - 1)
                    {
                        Console.WriteLine("Não existe série cadastrada com esse ID, tente outro.");
                    }
                } while (indiceSerie < 0 || indiceSerie > lista.Count - 1);
            }

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de ínicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            int indiceSerie;

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada, não é possível excluir.");
                return;
            }
            else
            {
                do
                {
                    Console.WriteLine("Digite o ID da série: ");
                    indiceSerie = int.Parse(Console.ReadLine());
                    
                    if (indiceSerie < 0 || indiceSerie > lista.Count - 1)
                    {
                        Console.WriteLine("Não existe série cadastrada com esse ID, tente outro.");
                    }
                } while (indiceSerie < 0 || indiceSerie > lista.Count - 1);
            }
            

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não é possível visualizar série ,nenhuma série cadastrada. ");
                return;
            }
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }


    }
}

