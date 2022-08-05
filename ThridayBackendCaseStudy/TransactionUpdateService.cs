using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ThridayBackendCaseStudy.DAO;
using ThridayDatabase;

namespace ThridayBackendCaseStudy
{
    public class TransactionUpdateService
    {
        private readonly IDBAccess _dBAccess;

        public TransactionUpdateService(IDBAccess dBAccess)
        {
            _dBAccess = dBAccess;
        }

        [FunctionName("TransactionUpdateService")]
        public void PerformOperation([TimerTrigger("%TimerInterval%"
            #if DEBUG
            ,RunOnStartup=true
            #endif
            )]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                Operation operation;
                Random random = new Random();
                //randomly generates number to decide for operation.
                int operationType = random.Next(1, 3);
                switch (operationType)
                {
                    case 1:
                        operation = new InsertCreator().CreateOperation(_dBAccess);
                        log.LogInformation($"C# Timer trigger function insert selected");
                        break;
                    case 2:
                        operation = new UpdateCreator().CreateOperation(_dBAccess);
                        log.LogInformation($"C# Timer trigger function update selected");
                        break;
                    default: operation = null;
                        break;
                }
                operation.PerformOperation();
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Error executing the PerformOperation for Insert or Update");
            }
        }     
    }
}
