namespace OnlineShop.App.Exceptions
{
    public class ApplicationException : Exception
    {
        public string Message { get; set; }
        public ApplicationException(string message) : base($"app error:\n{message}")
        {
            Message = message;
        }
    }
}
