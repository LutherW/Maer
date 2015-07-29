using System;

namespace Maer.Infrastructure.Domain
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message)
            : base(message) 
        { }
    }
}
