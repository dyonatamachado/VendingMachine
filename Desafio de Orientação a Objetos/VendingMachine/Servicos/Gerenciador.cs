using System;
using System.Collections.Generic;

namespace VendingMachine.Servicos
{
    public class Gerenciador : IEstoque, IVenda
    {
        static List<Produto> estoque = new List<Produto>();

        public Gerenciador()
        {
        }
        public static List<Produto> GetEstoque()
        {
            return estoque;
        }
        public double CalcularPrecoTotal(int quantidade, double preco)
        {
            Console.Clear();
            var precoTotal = quantidade*preco;
            return precoTotal;
        }

        public void CalcularDevolucao(double valorInserido)
        {
            Console.Clear();

            if(valorInserido == 0)
            {
                Console.WriteLine("Reiniciando aplicação...");
                Console.WriteLine("Tecle Enter para continuar");
                Console.ReadLine();
                Program.Encerrar();
            }
            else
            {

            var valorDevolverString = valorInserido.ToString("C");

            Console.WriteLine($"Tudo bem. Vi aqui que você inseriu {valorDevolverString}");
            Console.WriteLine("Vou te devolver este valor");
            Console.WriteLine("Tecle Enter para continuar");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Pronto. Valor devolvido com sucesso. Qualquer dúvida entre em contato conosco");
            Console.WriteLine("Tecle Enter para finalizar");
            Console.ReadLine();
            Program.Encerrar();
            }

        }

        public List<Produto> AdicionarProdutosAoEstoque()
        {
            var chocolate = new Chocolate(1, 2.5, "Chocolate ao Leite", 20, 50);
            var refri1 =  new Refrigerante(2, 4, "Refrigerante Sabor Cola", 30, 350);
            var refri2 = new Refrigerante(3, 3.5, "Refrigerante Sabor Guaraná", 15, 350);
            var refri3 = new Refrigerante(4, 3.5, "Refrigerante Sabor Laranja", 15, 350);

            estoque.Add(chocolate);
            estoque.Add(refri1);
            estoque.Add(refri2);
            estoque.Add(refri3);

            return estoque;
        }

        public void IdentificarProdutoDaCompra(string valor)
        {
            Console.Clear();
            int codigo;
            var sucess = Int32.TryParse(valor, out codigo);

            if(!sucess || (codigo < 1 || codigo > 4))
            {
                Console.WriteLine("Venda não concluída pois não existe produto com este código.");
                Console.WriteLine("Consulte o código do produto através da opção 'Para consultar Estoque'");
                Console.WriteLine("Tente novamente mais tarde, tecle enter para reinciar aplicação");
                Console.ReadLine();

                Program.Encerrar();
            }
            else
            {            
                Console.WriteLine("Agora insira a quantidade. Mas preste atenção nas dicas: ");
                Console.WriteLine("* Insira apenas números");
                Console.WriteLine("* Confira a quantidade disponível em nosso estoque");
                Console.WriteLine("\nDigite a quantidade e Tecle Enter para continuar\n");
                var resultado = Console.ReadLine();
                Console.Clear();

                int quantidade;
                var sucessQtd = Int32.TryParse(resultado, out quantidade);

                if(sucessQtd && (quantidade <= estoque[codigo - 1].Quantidade))
                {
                    switch (codigo)
                    {
                        case 1:
                            VenderProduto(codigo, quantidade, 2.5);
                            break;
                        case 2:
                            VenderProduto(codigo, quantidade, 4);
                            break;
                        case 3:
                            VenderProduto(codigo, quantidade, 3.5);
                            break;
                        case 4:
                            VenderProduto(codigo, quantidade, 3.5);
                            break;
                    }
                }
                else
                {   
                    Console.Clear();
                    Console.WriteLine("Quantidade informada está incorreta. Favor conferir nosso estoque");
                    Console.WriteLine("Tente novamente mais tarde. Tecle Enter para reiniciar aplicação");
                    Console.ReadLine();
                            
                    Program.Encerrar();
                }
            }
        }

        public void ObterEstoque(List<Produto> estoque)
        {
            Console.Clear();
            foreach(var produto in estoque)
            {
                var precoString = produto.Preco.ToString("C");
                Console.WriteLine($"Código: {produto.Codigo}, {produto.Descricao}. Qtd. Disponível: {produto.Quantidade}, Preço: {precoString}");
            }

            Console.WriteLine("\nDigite 1 para comprar, ou qualquer outra tecla para encerrar.");
            var resultado = Console.ReadLine();
            Console.Clear();

            if(resultado == "1")
            {
                Console.WriteLine("Informe o código do produto que você quer comprar. Se quiser cancelar basta digitar outro valor.");
                var opcaoUsuario = Console.ReadLine();
                IdentificarProdutoDaCompra(opcaoUsuario);
            }   
            else
                Program.Encerrar();
        }

        public void ReceberCedulas(double valorCompra, int codigo, int quantidade)
        {
            Console.Clear();
            var precoString = valorCompra.ToString("C");
            double valorInserido = 0;
          
            while(valorInserido < valorCompra)
            {
                
                string valorInseridoString = valorInserido.ToString("C");

                Console.Clear();
                Console.WriteLine($"Valor total da compra: {precoString}");
                Console.WriteLine($"Você inseriu até o momento: {valorInseridoString}");

                Console.WriteLine("\nDigite valor que você deseja inserir conforme a tabela\n");

                Console.WriteLine("1 - Para inserir uma moeda de R$ 1,00");
                Console.WriteLine("2 - Para inserir uma nota de R$ 2,00");
                Console.WriteLine("3 - Para inserir uma nota de R$ 5,00");
                Console.WriteLine("4 - Para inserir uma nota de R$ 10,00");
                Console.WriteLine("5 - Para inserir uma nota de R$ 20,00");
                Console.WriteLine("6 - Para inserir uma moeda de 25 centavos");
                Console.WriteLine("7 - Para inserir uma moeda de 50 centavos\n");

                Console.WriteLine("Ou qualquer outra tecla para cancelar."
                     + " Se você já tiver inserido alguma cédula ou moeda mas " 
                     + "quiser cancelar, não se preocupe iremos fazer a devolução.");
                
                var resultado = Console.ReadLine();

                switch(resultado)
                {
                    case "1":
                        valorInserido++;
                        break;
                    case "2":
                        valorInserido += 2;
                        break;
                    case "3":
                        valorInserido += 5;
                        break;
                    case "4":
                        valorInserido += 10;
                        break;
                    case "5":
                        valorInserido += 20;
                        break;
                    case "6":
                        valorInserido += 0.25;
                        break;
                    case "7":
                        valorInserido += 0.5;
                        break;
                    default:
                        CalcularDevolucao(valorInserido);
                        break;
                }
            }

            FinalizarVenda(valorInserido, valorCompra, codigo, quantidade);
        }

        public void VenderProduto(int codigo, int quantidade, double preco)
        {
            Console.Clear();
            var precoTotal = CalcularPrecoTotal(quantidade, preco);
            var precoString = precoTotal.ToString("C");

            Console.WriteLine($"O preço total da sua compra é: {precoString}");
            Console.WriteLine("Você deseja continuar. Tecle S para Sim ou qualquer outra tecla para encerrar");
            var resultado = Console.ReadLine().ToUpper();

            if(resultado == "S")
                ReceberCedulas(precoTotal, codigo, quantidade);
            else
                Program.Encerrar();
        }

        public void FinalizarVenda(double valorRecebido, double valorCompra, int codigo, int quantidade)
        {
            Console.Clear();
            var indiceNoEstoqueDoProdutoComprado = estoque.FindIndex(p => p.Codigo == codigo);
            estoque[indiceNoEstoqueDoProdutoComprado].Quantidade -= quantidade;

            var venda = new Vendas(valorCompra);

            if(valorCompra < valorRecebido)
            {
                var troco = CalcularTroco(valorRecebido, valorCompra);
                var trocoString = troco.ToString("C");

                Console.WriteLine("Compra efetuada com sucesso. Primeiro vou devolver o seu troco.");
                Console.WriteLine("Tecle Enter para continuar");
                Console.ReadLine();

                Console.WriteLine($"Seu troco no valor de {trocoString}, foi devolvido com sucesso");
                Console.WriteLine("Qualquer dúvida entre em contato conosco. Tecle Enter para continuar");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Agora vou entregar o seu produto. Tecle Enter para continuar");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Produto entregue com sucesso. Tecle Enter para finalizar");
                Console.ReadLine();
                Console.Clear();

                Program.Encerrar();
            }
            else
            {
                Console.WriteLine("Compra efetuada com sucesso. Vou entregar o seu produto!");
                Console.WriteLine("Tecle Enter para continuar");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Produto entregue com sucesso. Tecle Enter para finalizar");
                Console.ReadLine();
                Console.Clear();
                
                Program.Encerrar();
            }
        }

        public double CalcularTroco(double valorRecebido, double valorCompra)
        {
            return valorRecebido - valorCompra;
        }
    }
}
