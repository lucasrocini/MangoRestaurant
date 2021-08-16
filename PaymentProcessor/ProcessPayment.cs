using System;

namespace PaymentProcessor
{
    public class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            //custom logic for payment
            return true;
        }
    }
}
