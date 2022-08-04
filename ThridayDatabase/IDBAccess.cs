using System.Collections.Generic;

namespace ThridayDatabase
{
    public interface IDBAccess
    {
        List<object> GetTransactions();
        void InsertTransaction(object[] Transaction);
        void UpdateTransaction(int Id);
    }
}