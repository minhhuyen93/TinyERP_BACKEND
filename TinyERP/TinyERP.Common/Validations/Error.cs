namespace TinyERP.Common.Validations
{
    public class Error
    {
        public Error(string errorKey)
        {
            this.Message = errorKey;
        }
        public string Message { get; private set; }
    }
}
