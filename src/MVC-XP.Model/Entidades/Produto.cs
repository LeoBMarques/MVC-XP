namespace MVC_XP.Model.Entidades
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<PedidoItem> Items { get; set; }
    }
}
