using System;
using System.Collections.Generic;
using VendingMachine.Servicos;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var gerenciador = new Gerenciador();
            var estoque = gerenciador.AdicionarProdutosAoEstoque();
            MenuInicial(estoque, gerenciador);
        }
        static void MenuInicial(List<Produto> estoque, Gerenciador gerenciador)
        {
            Console.WriteLine("Bem-vindo ao SnackFast\n");
            Console.WriteLine("Tecle enter para continuar");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite a opção desejada conforme abaixo\n");

            Console.WriteLine("1 - Para consultar Estoque");
            Console.WriteLine("2 - Para comprar");
            Console.WriteLine();

            Console.WriteLine("V - Para verificar total de vendas(somente se você for administrador)");
            Console.WriteLine("X - Para Fechar a aplicação(somente se você for administrador)");
            Console.WriteLine();

            Console.WriteLine("Qualquer outra tecla para reiniciar");

            var respostaUsuario = Console.ReadLine().ToUpper();
            Console.Clear();

            if(respostaUsuario == "1")
                gerenciador.ObterEstoque(estoque);
            else if(respostaUsuario == "2")
            {
                Console.WriteLine("Agora informe o código do produto que você quer comprar");
                gerenciador.IdentificarProdutoDaCompra(Console.ReadLine());
            }
            else if(respostaUsuario == "X")
            {
                Console.WriteLine("Digite a senha de Administrador");
                var senhaDigitada = Console.ReadLine();

                if(senhaDigitada == Administrador.Senha)
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Senha incorreta. Tecle Enter para reiniciar aplicação.");
                    Console.ReadLine();
                    Encerrar();
                }
            }
            else if(respostaUsuario == "V")
            {
                Console.WriteLine("Digite a senha de Administrador");
                var senhaDigitada = Console.ReadLine();

                if(senhaDigitada == Administrador.Senha)
                {
                    Console.Clear();
                    Console.WriteLine($"Total de vendas realizadas: {Vendas.VendasConcluidas}");
                    Console.WriteLine($"Total faturado com vendas: {Vendas.ValorTotalDeVendasConcluidas.ToString("C")}\n\n");
                    Console.WriteLine("Tecle Enter para reiniciar aplicação");
                    Console.ReadLine();
                    Encerrar();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Senha incorreta. Tecle Enter para reiniciar aplicação.");
                    Console.ReadLine();
                    Encerrar();
                }
            }
            else
                Encerrar();
        }
        public static void Encerrar()
        {
            Console.WriteLine("Agradecemos pela preferência.");
            Console.Clear();
            MenuInicial(Gerenciador.GetEstoque(), new Gerenciador());
        }
    }
}
