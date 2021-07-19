using System.Collections.Generic;

namespace VendingMachine.Servicos
{
    public interface IEstoque
    {
        List<Produto> AdicionarProdutosAoEstoque();
        void ObterEstoque(List<Produto> estoque);
        
    }
}