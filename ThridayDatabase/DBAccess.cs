using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ThridayDatabase
{
    public class DBAccess : IDBAccess
    {
        private string _dbUri;

        public DBAccess()
        {
            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            string path = fileInfo.Directory.Parent.FullName;
            var indexbin = path.IndexOf("bin");
            _dbUri = path.Substring(0, indexbin) + "thriday.sqlite";

            SQLitePCL.Batteries.Init();
        }
        public List<object> GetTransactions()
        {

            var sql = "select * from banktransactions";
            List<object> obs = new List<object>();

            using (var con = new SqliteConnection($"Data Source={_dbUri};Mode=ReadOnly"))
            {
                con.Open();
                using (var cmd = new SqliteCommand(sql, con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Object[] values = new Object[rdr.FieldCount];
                            rdr.GetValues(values);
                            obs.Add(values); ;
                        }
                    }
                }
                con.Close();
            }


            return obs;
        }

        public void InsertTransaction(object[] Transaction)
        {
            var insertSql = "insert into banktransactions (id, accountUuid, transactionType, date, transactionTitle, status, description, cashflow, amount, postedDate, gst,businessUsePercentage )" +
                             " VALUES (@id, @accountUuid, @transactionType, @date, @transactionTitle, @status, @description, @cashflow, @amount, @postedDate, @gst,@businessUsePercentage)";

            using (var con = new SqliteConnection($"Data Source={_dbUri}"))
            {
                con.Open();
                using (var cmd = new SqliteCommand(insertSql, con))
                {
                    cmd.Parameters.Add(new SqliteParameter("@id", Transaction[0]));
                    cmd.Parameters.Add(new SqliteParameter("@accountUuid", Transaction[1]));
                    cmd.Parameters.Add(new SqliteParameter("@transactionType", Transaction[2]));
                    cmd.Parameters.Add(new SqliteParameter("@date", Transaction[3]));
                    cmd.Parameters.Add(new SqliteParameter("@transactionTitle", Transaction[4]));
                    cmd.Parameters.Add(new SqliteParameter("@status", Transaction[5]));
                    cmd.Parameters.Add(new SqliteParameter("@description", Transaction[6]));
                    cmd.Parameters.Add(new SqliteParameter("@cashflow", Transaction[7]));
                    cmd.Parameters.Add(new SqliteParameter("@amount", Transaction[8]));
                    cmd.Parameters.Add(new SqliteParameter("@postedDate", Transaction[9]));
                    cmd.Parameters.Add(new SqliteParameter("@gst", Transaction[10]));
                    cmd.Parameters.Add(new SqliteParameter("@businessUsePercentage", Transaction[11]));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void UpdateTransaction(int Id)
        {
            var sql = "update banktransactions set status= 'POSTED' where id = @id";

            using (var con = new SqliteConnection($"Data Source={_dbUri}"))
            {
                con.Open();
                using (var cmd = new SqliteCommand(sql, con))
                {
                    cmd.Parameters.Add(new SqliteParameter("@id", Id));
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
