using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ThridayBackendCaseStudy.DAO;
using ThridayDatabase;

namespace ThridayBackendCaseStudy
{
    public class TransactionUpdateService
    {
        private DBAccess dBAccess;
        [FunctionName("TransactionUpdateService")]
        public void Run([TimerTrigger("%TimerInterval%"
            #if DEBUG
            ,RunOnStartup=true
            #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            dBAccess = new DBAccess();

            Random random = new Random();

            int operation = random.Next(1, 3);

            if(operation == 1)//operation 1 is insert
            {
                var insertObject = GetInsertObject();
                dBAccess.InsertTransaction(insertObject);
                log.LogInformation($"C# Timer trigger function inserted at: {DateTime.Now}");
            }
            else // operation 2 is update
            {
                var updateObjectId = GetUpdateObject();
                if (updateObjectId != null)
                {
                    dBAccess.UpdateTransaction(updateObjectId.Value);
                    log.LogInformation($"C# Timer trigger function updated at: {DateTime.Now}");
                }
            }
        }

        public int? GetUpdateObject()
        {
            var data = dBAccess.GetTransactions();
            var transactionObj = data.Find(i => ((i as object[])[5].ToString() == "PENDING"));
            return transactionObj != null ? Convert.ToInt32((transactionObj as object[])[0]) : null;

        }

        public object[] GetInsertObject() {
            var data = dBAccess.GetTransactions();
            var id = data.Count +1 ;
            object[] objects = (object[])data.First();
            objects[0] = id.ToString();
            objects[5] = "PENDING";
            return objects;
        }

    }
}
