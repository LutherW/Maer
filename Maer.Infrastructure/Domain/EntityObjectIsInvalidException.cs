using System;

namespace Maer.Infrastructure.Domain
{
    public class EntityObjectIsInvalidException : Exception
    {
        public EntityObjectIsInvalidException(string message)
            : base(message) 
        { }
    }
}
