namespace VendingMachine.Servicos
{
    public interface IVenda
    {
        void FinalizarVenda(double valorRecebido, double valorCompra, int codigo, int quantidade);
    }
}