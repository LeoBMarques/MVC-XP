using MVC_XP.Model.DTO;

namespace MVC_XP.Model.Entidades
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<PedidoItem> Items { get; set; }

        internal void SetItems(IEnumerable<PedidoItemDto> items, IEnumerable<Produto> products)
        {
            var list = new List<PedidoItem>();
            if (items?.Any() ?? false)
            {
                foreach (var item in items)
                {
                    var product = products.FirstOrDefault(x => x.Id == item.ProdutoId);
                    list.Add(new PedidoItem
                    {
                        Pedido = this,
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        Valor = product?.Valor ?? 0
                    });
                }
            }
            Items = list;
            CalculateTotalValue();
        }

        private void CalculateTotalValue()
        {
            ValorTotal = Items.Sum(x => x.Total);
        }
    }
}
