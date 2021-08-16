using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.PaymentAPI.Extension
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
    }
}
