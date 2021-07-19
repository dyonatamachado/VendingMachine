namespace VendingMachine
{
    public class Chocolate : Produto
    {
        public Chocolate(int codigo, double preco, string descricao, int quantidade, int peso) : base(codigo, preco, descricao, quantidade)
        {
            Peso = peso;
        }

        public int Peso { get; private set; }
    }
}