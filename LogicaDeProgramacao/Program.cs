using System;

namespace LogicaDeProgramacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var functions = new Functions();

            // Teste 1.1

            Console.WriteLine("Teste 1.1 - Função Calcular Fatorial");
            Console.WriteLine(functions.CalcularFatorial(5));

            // Teste 1.2
            
            Console.WriteLine("Teste 1.2 - Função Calcular Prêmio");
            try
            {
                Console.WriteLine("Sem fator de multiplicação próprio");
                Console.WriteLine(functions.CalcularPremio(100, "vip"));
                Console.WriteLine("Com fator de multiplicação próprio");
                Console.WriteLine(functions.CalcularPremio(100, "basic", 3));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Categoria de premiação inválida");
            }

            // Teste 1.3
            Console.WriteLine("Teste 1.3 - Função Contar Números Primos");
            Console.WriteLine(functions.ContarNumerosPrimos(10));

            // Teste 1.4
            Console.WriteLine("Teste 1.4 - Função Calcular Vogais");
            Console.WriteLine(functions.CalcularVogais("Luby Software"));

            // Teste 1.5
            Console.WriteLine("Teste 1.5 - Função Calcular Valor Com Desconto Formatado");
            try
            {
                Console.WriteLine(functions.CalcularValorComDescontoFormatado("R$ 6.800,00", "30%"));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException)
            {
                Console.WriteLine("Valores de entrada não foram inseridos corretamente. " +
                "Favor informar valor no formato R$ XXX.XXX,XX e porcentagem no formato XX,X%");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // Teste 1.6
            Console.WriteLine("Teste 1.6 - Função Calcular Diferença de Datas");
            try
            {
                Console.WriteLine(functions.CalcularDiferencaData("10122020", "25122020"));
            }
            catch (Exception)
            {
                Console.WriteLine("Favor informar a data usando apenas números no formato DDMMAAAA");
            }
            
            // Teste 1.7
            Console.WriteLine("Teste 1.7 - Função Obter Elementos Pares");
            int[] vetor = new int[] { 1,2,3,4,5 };

            Console.WriteLine(functions.ObterElementosPares(vetor));

            foreach(int elemento in functions.ObterElementosPares(vetor))
            {
                Console.WriteLine(elemento);
            }
            
            // Teste 1.8
            Console.WriteLine("Teste 1.8 - Função Buscar Pessoa");
            string[] vetorPessoas = new string[] {
                "John Doe",
                "Jane Doe",
                "Alice Jones",
                "Bobby Louis",
                "Lisa Romero"
            };

            var buscarDoe = functions.BuscarPessoa(vetorPessoas, "Doe");
            Console.WriteLine(buscarDoe);
            foreach (string pessoa in buscarDoe)
            {
                Console.WriteLine(pessoa);
            }

            var buscarAlice = functions.BuscarPessoa(vetorPessoas, "Alice");
            Console.WriteLine(buscarAlice);
            foreach (string pessoa in buscarAlice)
            {
                Console.WriteLine(pessoa);
            }

            var buscarJames = functions.BuscarPessoa(vetorPessoas, "James");
            Console.WriteLine(buscarJames);
            foreach (string pessoa in buscarJames)
            {
                Console.WriteLine(pessoa);
            }
             
            // Teste 1.9
            Console.WriteLine("Teste 1.9 - Função Transformar em Matriz");
            try
            {
                var arrayDeArrays = functions.TransformarEmMatriz("1,2,3,4,5,6");

                Console.WriteLine("Testando função que retorna Array de Arrays com elementos dados pela string.\n");
                Console.WriteLine($"Total de Arrays formados: {arrayDeArrays.Length}\n");

                for(int indArray = 0; indArray < arrayDeArrays.Length; indArray++)
                {
                    Console.WriteLine($"{indArray + 1}° ARRAY");
                    var array = arrayDeArrays[indArray];

                    for(int i = 0; i < array.Length; i++)
                    {
                        Console.WriteLine($"Valor no índice {i}: {array[i]}");
                    }
                }

                Console.WriteLine("\nFim");
            }
            catch (Exception)
            {
                Console.WriteLine("Por favor insira um texto com apenas números e vírgulas conforme o modelo: 1,2,3");
            }

            // Teste 1.10
            Console.WriteLine("Teste 1.10 - Função Obter Elementos Faltantes");

            int[] vetor1 = new int[] { 1,2,3,4,5 };
            int[] vetor2 = new int[] { 1,2,5 };

            int[] vetor3 = new int[] { 1,4,5 };
            int[] vetor4 = new int[] { 1,2,3,4,5 };

            int[] vetor5 = new int[] { 1,2,3,4 };
            int[] vetor6 = new int[] { 2,3,4,5 };

            int[] vetor7 = new int[] { 1,3,4,5 };
            int[] vetor8 = new int[] { 1,3,4,5 };


            Console.WriteLine("\nTestando função Obter Elementos Faltantes\n\nTeste 1\n\n");
            var teste1 = functions.ObterElementosFaltantes(vetor1, vetor2);
            for(int i = 0; i < teste1.Length; i++)
            {
                Console.WriteLine($"Valor no indíce{i}: {teste1[i]}");
            }

            Console.WriteLine("\nTestando função Obter Elementos Faltantes\n\nTeste 2\n\n");
            var teste2 = functions.ObterElementosFaltantes(vetor3, vetor4);
            for(int i = 0; i < teste2.Length; i++)
            {
                Console.WriteLine($"Valor no indíce{i}: {teste2[i]}");
            }

            Console.WriteLine("\nTestando função Obter Elementos Faltantes\n\nTeste 3\n\n");
            var teste3 = functions.ObterElementosFaltantes(vetor5, vetor6);
            for(int i = 0; i < teste3.Length; i++)
            {
                Console.WriteLine($"Valor no indíce{i}: {teste3[i]}");
            }

            Console.WriteLine("\nTestando função Obter Elementos Faltantes\n\nTeste 4\n\n");
            var teste4 = functions.ObterElementosFaltantes(vetor7, vetor8);

            Console.WriteLine($"Tamanho Vetor Teste 4: {teste4.Length}");
            for(int i = 0; i < teste4.Length; i++)
            {
                Console.WriteLine($"Valor no indíce{i}: {teste4[i]}");
            }
            
        }
    }
}