using System.Collections.Generic;

namespace TinyERP.Common.Validations
{
    public class ValidationException : System.Exception
    {
        public IList<Error> Errors { get; set; }
        public ValidationException(IList<Error> errors)
        {
            this.Errors = errors;
        }
        public ValidationException(string errorKey):this(new List<Error>() { new Error(errorKey) }){}
    }
}
