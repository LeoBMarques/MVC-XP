namespace MVC_XP.Model.Entidades
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
