using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Events;
using Newtonsoft.Json;
using System.Text;

namespace CustomerService.EventStore
{
    public static class ServiceBusQueueStore
    {
        public static void SendEvents(CustomerCreatedEvents cee)
            {
            TopicClient client = new TopicClient("Endpoint=sb://customerservice01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7cY5coczBuDMX0Rh81kzGEWjMn1E7YT8MAUrMTnSsL0=", "customercreated");
                var jsonstring = JsonConvert.SerializeObject(cee);
            byte[] bytedata = Encoding.ASCII.GetBytes(jsonstring);

            Message msg = new Message();
            msg.Body = bytedata;
            client.SendAsync(msg).GetAwaiter().GetResult();
            }
    }
}
