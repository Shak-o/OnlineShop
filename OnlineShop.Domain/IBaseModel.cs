namespace OnlineShop.Domain
{
    public interface IBaseModel : IDisposable
    {
        public int Id { get; set; }
    }
}
