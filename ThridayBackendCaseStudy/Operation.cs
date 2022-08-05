using System;
using System.Linq;
using ThridayBackendCaseStudy.DAO;
using ThridayDatabase;

namespace ThridayBackendCaseStudy
{
    public abstract class Operation
    {
        internal readonly IDBAccess _dBAccess;
        public Operation(IDBAccess dBAccess)
        {
            _dBAccess = dBAccess;
        }
        public abstract object[] GetObject();

        public abstract void PerformOperation();
    }

    public class InsertOperation : Operation
    {
        public InsertOperation(IDBAccess dBAccess) : base(dBAccess)
        {
        }

        public override object[] GetObject()
        {
            var data = _dBAccess.GetTransactions();
            var id = data.Count + 1;
            if (data.Count == 0)
            {
                return null;
            }
            else
            {
                //copies the first object for sample. Modify the id and status to insert as new row
                object[] objects = (object[])data.First();
                objects[0] = id.ToString();
                objects[5] = TransactionStatus.PENDING.ToString();
                return objects;
            }
        }
        public override void PerformOperation()
        {
            var insertObject = GetObject();
            if (insertObject != null)
            {
                _dBAccess.InsertTransaction(insertObject);
            }
        }
    }

    public class UpdateOperation : Operation
    {
        public UpdateOperation(IDBAccess dBAccess) : base(dBAccess)
        {
        }

        public override object[] GetObject()
        {
            var data = _dBAccess.GetTransactions();
            //finds the first object with Status PENDING to update
            var transactionObj = data.Find(i => ((i as object[])[5]?.ToString() == TransactionStatus.PENDING.ToString()));
            return transactionObj as object[];

        }
        public override void PerformOperation()
        {
            var updateObjectId = GetObject();
            if (updateObjectId != null)
            {
                _dBAccess.UpdateTransaction(Convert.ToInt32(updateObjectId[0]));
            }
        }
    }
}
