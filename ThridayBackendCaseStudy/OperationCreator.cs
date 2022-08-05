using System;
using System.Linq;
using ThridayBackendCaseStudy.DAO;
using ThridayDatabase;

namespace ThridayBackendCaseStudy
{
    public abstract class OperationCreator
    {
        protected abstract Operation GetOperation(IDBAccess dBAccess);

        public Operation CreateOperation(IDBAccess dBAccess)
        {
            return this.GetOperation(dBAccess);
        }
    }
    public class InsertCreator : OperationCreator
    {
        protected override Operation GetOperation(IDBAccess dBAccess)
        {
            Operation operation = new InsertOperation(dBAccess);
            return operation;
        }
    }
    public class UpdateCreator : OperationCreator
    {
        protected override Operation GetOperation(IDBAccess dBAccess)
        {
            Operation operation = new UpdateOperation(dBAccess);
            return operation;
        }
    }
}