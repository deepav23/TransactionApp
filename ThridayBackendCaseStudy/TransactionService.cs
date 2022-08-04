using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThridayDatabase;
using ThridayBackendCaseStudy.DAO;
using System.Collections.Generic;

namespace ThridayBackendCaseStudy;

public class GetTransactions
{
    private readonly IDBAccess _dBAccess;

    public GetTransactions(IDBAccess dBAccess)
    {
        _dBAccess = dBAccess;
    }

    [FunctionName("GetTransactions")]
    public async Task<IActionResult> GetTransactionsAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        /*
         * TODO: Fetch transactions from database
         * Return them in the same format as SampleData/backend-response.json
        */
        try
        {
            var data = _dBAccess.GetTransactions();

            await Task.Delay(0);
            var finalData = new List<TransactionItem>();
            data.ForEach(x =>
            {
                finalData.Add(new TransactionItem
                {
                    Id = Convert.ToInt32((x as object[])[0]),
                    AccountUuid = Guid.Parse((x as object[])[1].ToString()),
                    TransactionType = ParseEnum<TransactionType>((x as object[])[2].ToString()),
                    Date = Convert.ToDateTime((x as object[])[3]),
                    TransactionTitle = ((x as object[])[4]).ToString(),
                    Status = ParseEnum<TransactionStatus>((x as object[])[5].ToString()),
                    Description = ((x as object[])[6]).ToString(),
                    Cashflow = ParseEnum<CashflowDirection>((x as object[])[7].ToString()),
                    Amount = Convert.ToDecimal((x as object[])[8]),
                    PostedDate = Convert.ToDateTime((x as object[])[9]),
                    Gst = Convert.ToDecimal((x as object[])[10]),
                    BusinessUsePercentage = Convert.ToDecimal((x as object[])[11]),
                });

            });
            return new OkObjectResult(finalData);
        }
        catch(Exception ex)
        {
            string error = ex.Message;
            log.LogInformation(error);
            return new BadRequestObjectResult(error);
        }
    }

    public static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
    }
}