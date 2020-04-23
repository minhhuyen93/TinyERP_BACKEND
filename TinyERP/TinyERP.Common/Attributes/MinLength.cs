namespace TinyERP.Common.Attributes
{
    public class MinLength : BaseAttribute
    {
        public MinLength(string errorKey, int minLength) : base(errorKey)
        {
            this.MinLengthValue = minLength;
        }
        public int MinLengthValue { get; private set; }
        public override bool IsValid(object request)
        {
            if (request == null) { return false; }
            return this.MinLengthValue < request.ToString().Length;
        }
    }
}
