using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeProgramacao
{
    public partial class Functions
    {
        // Resposta 1.6
        public int CalcularDiferencaData(string dataAnterior, string dataPosterior)
        {            
            int diaAnt = Convert.ToInt32(dataAnterior.Substring(0,2));
            int mesAnt = Convert.ToInt32(dataAnterior.Substring(2,2));
            int anoAnt = Convert.ToInt32(dataAnterior.Substring(4,4));
            
            int diaPost = Convert.ToInt32(dataPosterior.Substring(0,2));
            int mesPost = Convert.ToInt32(dataPosterior.Substring(2,2));
            int anoPost = Convert.ToInt32(dataPosterior.Substring(4,4));

            if((diaAnt > 31 || diaAnt < 1) || (diaPost > 31 || diaPost < 1)) 
                throw new ArgumentException();
            if((mesAnt > 12 || mesAnt < 1) || (mesPost > 12 || mesPost < 1)) 
                throw new ArgumentException();
            if(anoAnt > 9999 || anoPost > 9999)
                throw new ArgumentException();
            
            DateTime firstDate = new DateTime(anoAnt, mesAnt, diaAnt);
            DateTime secondDate = new DateTime(anoPost, mesPost, diaPost);

            return (int) secondDate.Subtract(firstDate).TotalDays;
        }
        // Resposta 1.7
        public int[] ObterElementosPares(int[] vetor)
        {
            var lista = vetor.ToList();
            var listaPares = new List<int>();

            foreach(int numero in lista)
            {
                if(numero % 2 == 0)
                    listaPares.Add(numero);
            }

            var vetorPares = listaPares.ToArray();

            return vetorPares;
        }
        // Resposta 1.8
        public string[] BuscarPessoa(string[] vetor, string pessoa)
        {      
            var listaPessoasEncontradas = vetor.Where(p => p.Contains(pessoa)).ToArray();

            return listaPessoasEncontradas;
        }
        // Resposta 1.9
        public int[][] TransformarEmMatriz(string texto)
        {
            var arrayComTodosElementos = texto.Split(',');
            var listaIntRecebidos = new List<int>();

            foreach(string elemento in arrayComTodosElementos)
            {
                var number = Int32.Parse(elemento);
                listaIntRecebidos.Add(number);
            }

            if(listaIntRecebidos.Count() % 2 == 0)
            {    
                var listaDeArraysInt = new List<int[]>();

                for(int i = 0; i < listaIntRecebidos.Count() - 1; i += 2)
                {
                    var listaIntDoisADois = new List<int>();
                    listaIntDoisADois.Add(listaIntRecebidos[i]);
                    listaIntDoisADois.Add(listaIntRecebidos[i + 1]);

                    var arrayDoisADois = listaIntDoisADois.ToArray();
                    listaDeArraysInt.Add(arrayDoisADois);
                }

                var arrayResultado = listaDeArraysInt.ToArray();
                return arrayResultado;
            }
            else 
            {
                var listaDeArraysInt = new List<int[]>();
                for(int i = 0; i < listaIntRecebidos.Count(); i += 2)
                {
                    if(i == listaIntRecebidos.Count() - 1)
                    {
                        var listaComApenasUltimoElemento = new List<int>();
                        listaComApenasUltimoElemento.Add(listaIntRecebidos[i]);

                        var arrayComUltimoElemento = listaComApenasUltimoElemento.ToArray();
                        listaDeArraysInt.Add(arrayComUltimoElemento);
                    }
                    else
                    {
                        var listaIntDoisADois = new List<int>();
                        listaIntDoisADois.Add(listaIntRecebidos[i]);
                        listaIntDoisADois.Add(listaIntRecebidos[i + 1]);

                        var arrayDoisADois = listaIntDoisADois.ToArray();
                        listaDeArraysInt.Add(arrayDoisADois);
                    }
                }

                var arrayResultado = listaDeArraysInt.ToArray();
                return arrayResultado;
            }
        }
        // Resposta 1.10
        public int[] ObterElementosFaltantes(int[] vetor1, int[] vetor2)
        {
            var listaElementosFaltantes = new List<int>();

            var lista1 = vetor1.ToList();
            var lista2 = vetor2.ToList();

            foreach(var elemento in lista1)
            {
                var existe = lista2.Exists(x => x == elemento);

                if(!existe)
                    listaElementosFaltantes.Add(elemento);
            }

            foreach(var elemento in lista2)
            {
                var existe = lista1.Exists(x => x == elemento);

                if(!existe)
                    listaElementosFaltantes.Add(elemento);
            }

            var resultado = listaElementosFaltantes.ToArray();
            return resultado;
        }
    }
}