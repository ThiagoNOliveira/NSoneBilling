using System;

namespace NSoneBilling
{
    public static class ConnectionExtensions
    {
        public static Hire Hire(this Connection builder, Guid merchantKey, string contractMode,
            string paymentMode, string frequency)
        {
            return new Hire(merchantKey,contractMode,paymentMode, frequency);
        }
    }
}