
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.MessageBus
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        //can be improved
        private string connectionString = "Endpoint=sb://mangorestaurantlar.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=stW2XNw1fdBzfuldnziIkkdQlhD++Ggyb2Ut+av3988=";
        public async Task PublishMessage(BaseMessage message, string topicName)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);
            //OLD VERSION - Microsoft.Azure.ServiceBus
            //ISenderClient senderClient = new TopicClient(connectionString, topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);

            //OLD VERSION - Microsoft.Azure.ServiceBus
            //var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            //OLD VERSION - Microsoft.Azure.ServiceBus
            //await senderClient.SendAsync(finalMessage);
            //await senderClient.CloseAsync();

            await sender.SendMessageAsync(finalMessage);
            await client.DisposeAsync();
        }
    }
}
