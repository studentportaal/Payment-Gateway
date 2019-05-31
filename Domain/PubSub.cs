using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Iam.V1;
using Google.Cloud.PubSub.V1;
using Grpc.Core;

namespace PaymentGateway.Domain
{
    public class PubSub
    {
        public static object CreateTopic(string projectId, string topicId)
        {
            PublisherServiceApiClient publisher = PublisherServiceApiClient.Create();
            TopicName topic = new TopicName(projectId, topicId);
            try
            {
                publisher.CreateTopic(topic);
            }
            catch (RpcException e)
            when (e.StatusCode == StatusCode.AlreadyExists)
            {
            
            }
            return 0;
        }

        public static async Task<object> PublishMessagesAsync (PublisherClient publisher, IEnumerable<string> messageTexts)
        {
            var publishTasks = messageTexts.Select(text => publisher.PublishAsync(text));
            foreach (Task<string> task in publishTasks)
            {
                string message = await task;
                await Console.Out.WriteLineAsync($"Published message {message}");
            }
            return 0;
        }
    }
}
