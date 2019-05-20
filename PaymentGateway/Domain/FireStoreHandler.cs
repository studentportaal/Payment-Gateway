using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Google.Cloud.PubSub.V1;

namespace PaymentGateway.Domain
{
    public class FireStoreHandler
    {
        FirestoreDb db;
        public FireStoreHandler()
        {
            db = FirestoreDb.Create("pts6-bijbaan");
        }

        public async Task PersistAsync(PubsubMessage message)
        {
            DocumentReference docRef = db.Collection("payments").Document(message.MessageId);
            Dictionary<string, object> payment = new Dictionary<string, object>();
            payment.Add("message", Encoding.UTF8.GetString(message.Data.ToArray()));
            await docRef.SetAsync(payment);
        }
    }
}
