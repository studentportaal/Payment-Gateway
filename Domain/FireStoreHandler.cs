using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Google.Cloud.PubSub.V1;
using Newtonsoft.Json;

namespace PaymentGateway.Domain
{
    public class FireStoreHandler
    {
        FirestoreDb db;
        public FireStoreHandler()
        {
            db = FirestoreDb.Create("pts6-bijbaan");
        }

        public async Task PersistAsync(string messageId, string message)
        {
            DocumentReference docRef = db.Collection("payments").Document(messageId);
            var payment = JsonConvert.DeserializeObject<Dictionary<String, dynamic>>(message);
            await docRef.SetAsync(payment);
        }
    }
}
