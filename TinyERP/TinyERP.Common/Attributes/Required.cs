namespace TinyERP.Common.Attributes
{
    public class Required : BaseAttribute
    {
        public Required(string errorKey) : base(errorKey) { }
        public override bool IsValid(object request)
        {
            return !string.IsNullOrEmpty(request?.ToString());
        }
    }
}
