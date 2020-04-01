using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ParkingChargeCalculator.Exceptions
{
    [Serializable]
    public class ParkingTypeNotSupportedException : Exception
    {
        public ParkingTypeNotSupportedException(string message) : base(message)
        {
        }

        [ExcludeFromCodeCoverage]
        protected ParkingTypeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
