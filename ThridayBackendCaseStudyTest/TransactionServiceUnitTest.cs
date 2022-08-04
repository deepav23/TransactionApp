using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ThridayBackendCaseStudy;
using ThridayDatabase;

namespace ThridayBackendCaseStudyTest
{
    public class TransactionServiceUnitTest
    {
        [Theory]
        [InlineData(false, typeof(OkObjectResult))]
        [InlineData(true, typeof(BadRequestObjectResult))]
        public async Task Function_Returns_Correct_StatusCode(bool isNullData, Type expectedResult)
        {
            //Arrange
            var request = new Mock<HttpRequest>();
            request.Setup(x => x.Query);
            //determines the data returned based on the parameter passed
            var data = isNullData ? null : new List<object>();
            var logger = Mock.Of<ILogger>();

            var dbAccess = new Mock<IDBAccess>();            
            dbAccess.Setup(x => x.GetTransactions())
                .Returns(() => data);
            GetTransactions getTransactions = new GetTransactions(dbAccess.Object);
            //Act
            var response = await getTransactions.GetTransactionsAsync(request.Object, logger);
            //Assert
            Assert.True(response.GetType() == expectedResult);
        }
    }
}