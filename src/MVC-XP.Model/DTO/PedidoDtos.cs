namespace MVC_XP.Model.DTO
{
    public class PedidoDto
    {
        public long ClienteId { get; set; }
        public IEnumerable<PedidoItemDto> Items { get; set; }
    }

    public class PedidoItemDto
    {
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class PedidoItemViewDto
    {
        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }

    public class PedidoViewDto
    {
        public long Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public IEnumerable<PedidoItemViewDto> Items { get; set; }
    }
}
