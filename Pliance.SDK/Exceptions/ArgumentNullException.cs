using System;
using System.Runtime.Serialization;

namespace Pliance.SDK.Exceptions
{
    public class ArgumentNullException : ApiException
    {
        public ArgumentNullException()
        {
        }

        protected ArgumentNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ArgumentNullException(string message)
            : base(message)
        {
        }

        public ArgumentNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}