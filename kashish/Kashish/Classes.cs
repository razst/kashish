using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Kashish
{
    [FirestoreData]
    internal class linkInfo
    {

        [FirestoreDocumentId]
        public string DocID { get; set; }

        [FirestoreProperty]
        public string URL { get; set; }

        [FirestoreProperty]
        public string name { get; set; }

        [FirestoreProperty]
        public DateTime startTime { get; set; }

        [FirestoreProperty]
        public string desk { get; set;  }

    }
}
