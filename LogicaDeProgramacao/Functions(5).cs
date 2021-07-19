using System;
using System.Globalization;
using System.Linq;

namespace LogicaDeProgramacao
{
    public partial class Functions
    {
        
        // Resposta 1.5
        public string CalcularValorComDescontoFormatado(string valor, string porcentagemDoDesconto)
        {   
            // Formata Valor e Porcentagem em Double

            var valorFormatado = FormatarValor(valor);
            var porcentagemFormatada = FormatarPorcentagem(porcentagemDoDesconto);

            // Lança Exceptions em caso de erro do usuário ao informar valor

            var auxiliarParaVerificarValorMoeda = valorFormatado.ToString("C");

            if(auxiliarParaVerificarValorMoeda != valor)
                throw new Exception("Favor informar valor no formato R$ XXX.XXX,XX");

            if(valorFormatado >= 1000000)
                throw new ArgumentOutOfRangeException("Favor informar valor de no máximo R$ 999.999,99");

            
            // Calcula Desconto e Retorna em Formato Moeda
            
            double resultadoDesconto = valorFormatado * (1 - porcentagemFormatada);

            return resultadoDesconto.ToString("C");
        }

        private double FormatarPorcentagem(string porcentagemDoDesconto)
        {
            if(porcentagemDoDesconto.IndexOf('%') == -1)
                throw new ArgumentException("Favor informar porcentagem com o padrão XX,X%");
            
            if(porcentagemDoDesconto.IndexOf('.') >= 0)
                throw new ArgumentException("Favor informar porcentagem com o padrão XX,X%");
                
            var indSinalPorcentagem = porcentagemDoDesconto.IndexOf('%');
            var percentDouble = Convert.ToDouble(porcentagemDoDesconto.Remove(indSinalPorcentagem)) / 100;

            return percentDouble;
        }

        private double FormatarValor(string valor)
        {
            // Transforma String em List<char>

            string valorEmMaiusculas = valor.ToUpper();
            var listaDeCaracteresDaStringValor = valorEmMaiusculas.ToList();

            // Remove Pontuações da List

            listaDeCaracteresDaStringValor.Remove('R');
            listaDeCaracteresDaStringValor.Remove('$');
            listaDeCaracteresDaStringValor.Remove(' ');
            listaDeCaracteresDaStringValor.RemoveAll(c => c == '.');
            listaDeCaracteresDaStringValor.Remove(',');

            // Cria String Sem Pontuações

            string valorSemPontuacao = listaDeCaracteresDaStringValor[0].ToString();

            for(int i = 1; i < listaDeCaracteresDaStringValor.Count; i++)
            {
                valorSemPontuacao += listaDeCaracteresDaStringValor[i].ToString();
            }

            // Converte String para Double e retorna

            var valorDoubleSemCentavos = Convert.ToDouble(valorSemPontuacao);
            var valorDouble = valorDoubleSemCentavos / 100;

            return valorDouble;            
            
        }
    }
}