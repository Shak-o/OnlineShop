namespace OnlineShop.App.Exceptions
{
    public class AppException : Exception
    {
        public string Message { get; set; }
        public AppException(string message) : base($"app error:\n{message}")
        {
            Message = message;
        }
    }
}
