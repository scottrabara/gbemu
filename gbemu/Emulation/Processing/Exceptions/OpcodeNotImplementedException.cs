using System;
using System.Runtime.Serialization;

namespace GBEmu.Emulation.Processing.Exceptions
{
    [Serializable]
    internal class OpcodeNotImplementedException : Exception
    {
        public OpcodeNotImplementedException()
        {
        }

        public OpcodeNotImplementedException(string message) : base(message)
        {
        }

        public OpcodeNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OpcodeNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}