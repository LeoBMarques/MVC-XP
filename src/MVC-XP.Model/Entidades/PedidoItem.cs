namespace MVC_XP.Model.Entidades
{
    public class PedidoItem
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal Total => Valor * Quantidade;
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
