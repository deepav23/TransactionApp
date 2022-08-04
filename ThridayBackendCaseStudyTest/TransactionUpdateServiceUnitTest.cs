using Microsoft.Extensions.Logging;
using Moq;
using ThridayBackendCaseStudy;
using ThridayDatabase;

namespace ThridayBackendCaseStudyTest
{
    public class UnitTest1
    {
        [Fact]
        public void Function_Performed_Operation()
        {                       
            var logger = Mock.Of<ILogger>();               
            bool operationPerformed = false;
            object[] data = new object[12];
            data[5] = "PENDING";
            List<object> transactions = new List<object>();
            transactions.Add(data);
            var dbAccess = new Mock<IDBAccess>();
            dbAccess.Setup(x => x.GetTransactions())
                .Returns(()=>transactions);
            dbAccess.Setup(x => x.UpdateTransaction(It.IsAny<int>()))
                .Callback(()=> operationPerformed = true);
            dbAccess.Setup(x => x.InsertTransaction(It.IsAny<object[]>())).Callback(() => operationPerformed = true); 
            TransactionUpdateService transactionUpdateService = new TransactionUpdateService(dbAccess.Object);
            transactionUpdateService.Run(null, logger);
            //Assert
            Assert.True(operationPerformed);
        }
    }
}