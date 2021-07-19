namespace VendingMachine
{
    public abstract class Produto
    {
        protected Produto(int codigo, double preco, string descricao, int quantidade)
        {
            Codigo = codigo;
            Preco = preco;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public int Codigo { get; private set; }
        public double Preco { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; set; }

    }
}