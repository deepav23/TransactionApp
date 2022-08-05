using System;
using ThridayDatabase;

namespace ThridayBackendCaseStudy
{
    static class OperationFactory
    {
        public static IOperation GetOperationInstance(IDBAccess _dBAccess)
        {
            Random random = new Random();
            //randomly generates number to decide for operation.
            int operationType = random.Next(1, 3);
            switch (operationType)
            {
                case 1:
                    return new InsertOperation(_dBAccess);

                case 2:
                    return new UpdateOperation(_dBAccess);

                default:
                    return null;
            }
        }
    }
}