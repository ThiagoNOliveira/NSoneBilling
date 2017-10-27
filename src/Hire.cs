using System;

namespace NSoneBilling
{
    public class Hire
    {
        public Hire(Guid merchantKey, string contractMode, string paymentMode, string frequency)
        {
        }

        private Guid MerchantKey { get; set; }
        private string ContractMode { get; set; }
        private string PaymentMode { get; set; }
        private string Frequency { get; set; }
        private DateTime FinishDate { get; set; }

        public Hire SetFinishDate(DateTime finishDate)
        {
            FinishDate = finishDate;
            return this;
        }


        public dynamic Execute()
        {
            return null;
        }
    }
}