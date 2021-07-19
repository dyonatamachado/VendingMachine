using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeProgramacao
{
    public partial class Functions
    {

        // Resposta 1.1
        public uint CalcularFatorial(uint numero)
        {
            uint fatorial = 1;

            if(numero == 1 || numero == 0)
                return fatorial;

            for(uint i = numero; i > 1; i--)
            {
                fatorial *= i;
            }

            return fatorial;
        }

        // Resposta 1.2
        public double CalcularPremio(double valorBase, string categoriaPremio)
        {
            var categoria = categoriaPremio.ToLower();

            switch(categoria)
            {
                case "basic":
                    return valorBase;
                case "vip":
                    return valorBase*1.2;
                case "premium":
                    return valorBase*1.5;
                case "deluxe":
                    return valorBase*1.8;
                case "special":
                    return valorBase*2;
                default: 
                    throw new ArgumentException();
            }
        }
        
        public double CalcularPremio(double valorBase, string categoriaPremio, double fatorMultiplicacaoProprio)
        {
            if(fatorMultiplicacaoProprio <= 0)
                CalcularPremio(valorBase,categoriaPremio);
            
            return valorBase*fatorMultiplicacaoProprio;
        }

        // Resposta 1.3
        public int ContarNumerosPrimos(int numero)
        {
            if(numero == 1)
                return 0;
            
            var listaDeNumerosPrimos = new List<int>();

            for(int PossivelPrimo = 2; PossivelPrimo <= numero; PossivelPrimo++)
            {
                var divisores = 0;

                for(int i = 1; i <= PossivelPrimo; i++)
                {
                    if(PossivelPrimo % i == 0)
                        divisores++;
                }

                if(divisores == 2)
                    listaDeNumerosPrimos.Add(PossivelPrimo);
            }

            return listaDeNumerosPrimos.Count;
        }

        // Resposta 1.4
        public int CalcularVogais(string texto)
        {
            char[] arrayDeCaracteres = texto.ToLower().ToCharArray();
            char[] arrayDeVogais = {'a', 'e', 'i','o','u','ã', 'õ', 'á', 'é', 'í', 'ó','ú','à','ê','ô'};
            int quantidadeDeVogais = 0;

            foreach(char caractere in arrayDeCaracteres)
            {
                foreach(char vogal in arrayDeVogais)
                {
                    if(caractere == vogal)
                        quantidadeDeVogais++;
                }
            }

            return quantidadeDeVogais;
        }

    }
}