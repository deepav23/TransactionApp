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
                IOperation operation = OperationFactory.GetOperationInstance(_dBAccess);               
                operation.PerformOperation();
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Error executing the PerformOperation for Insert or Update");
            }
        }     
    }
}
