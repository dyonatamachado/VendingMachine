namespace VendingMachine
{
    public class Refrigerante : Produto
    {
        public Refrigerante(int codigo, double preco, string descricao, int quantidade, int conteudo) : base(codigo, preco, descricao, quantidade)
        {
            Conteudo = conteudo;
        }
        public int Conteudo { get; private set; }
    }
}