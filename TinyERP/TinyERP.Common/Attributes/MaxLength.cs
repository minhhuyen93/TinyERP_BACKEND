namespace TinyERP.Common.Attributes
{
    public class MaxLength : BaseAttribute
    {
        public MaxLength(string errorKey, int maxLenght):base(errorKey)
        {
            this.MaxLengthValue = maxLenght;
        }
        public int MaxLengthValue { get; private set; }
        public override bool IsValid(object request)
        {
            if (request == null) { return false; }
            return this.MaxLengthValue >= request.ToString().Length;
        }
    }
}
