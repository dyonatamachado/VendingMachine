namespace VendingMachine.Servicos
{
    public class Vendas
    {
        public Vendas(double valor)
        {
            VendasConcluidas++;
            ValorTotalDeVendasConcluidas += valor;
        }

        public static int VendasConcluidas { get; set; }
        public static double ValorTotalDeVendasConcluidas { get; set; }
    }
}