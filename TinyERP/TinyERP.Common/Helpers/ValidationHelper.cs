using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyERP.Common.Attributes;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Helpers
{
    public class ValidationHelper
    {
        public static IList<Error> Validate(object request)
        {
            IList<Error> errors = new List<Error>();
            IList<PropertyInfo> propertyInfos = request.GetType().GetProperties();
            foreach (PropertyInfo prop in propertyInfos)
            {
                IList<BaseAttribute> attrs = prop.GetCustomAttributes<BaseAttribute>().ToList();
                foreach (BaseAttribute attr in attrs)
                {
                    bool isValid = attr.IsValid(prop.GetValue(request));
                    if (!isValid)
                    {
                        errors.Add(new Error(attr.ErrorKey));
                    }
                }
            }
            return errors;
        }
    }
}
