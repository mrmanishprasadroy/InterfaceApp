using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnpremisestoAzureInterfaceApp
{
    /// <summary>
    /// Move on and call me an idiot later.
    /// who cares?
    /// </summary>
    public class DatabaseOperations
    {
        
        public string Sqldb_con_string = "Server=tcp:smsgroup.database.windows.net,1433;Initial Catalog=smsgroupdb;Persist Security Info=False;User ID=saadmin;Password=sms@123456;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string Oracle_con_string = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.182.50.108)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=jspl_smcdb)));User Id=L2SMC;Password=l2smc;";
        bool status;
        /** Logger */
        private LogManager Logger = new LogManager(true);
        
        /// <summary>
        /// Select Data from Azure database or sql database
        /// </summary>
        /// <param name="QueryAzure"></param>
        /// <returns></returns>
        public DataTable DBSelectQueryAzure_Table(string QueryAzure)
        {
            DataTable TempDataTable = new DataTable();
            TempDataTable.Clear();
            try
            {
                SqlConnection DbconAzure = new SqlConnection(Sqldb_con_string);
                SqlDataAdapter TempAdapter = new SqlDataAdapter(QueryAzure, DbconAzure);
                DbconAzure.Open();
                TempAdapter.Fill(TempDataTable);
                DbconAzure.Close();

            }
            catch (Exception ex) // Why I should Catch you ?? /* Please work */
            {
                Logger.Fatal("DBSelectQueryAzure_Table Caught an exception ---> " + ex.Message.ToString());
            }

            return TempDataTable;
        }

        /// <summary>
        /// Select Asynchronous Data from Azure database or sql database
        /// </summary>
        /// <param name="QueryAzure"></param>
        /// <returns></returns>
        public Task<DataTable> DBSelectQueryAzure_TableAsync(string QueryAzure)
        {

            return Task.Run(() =>
            {
                using (var DbconAzure = new SqlConnection(Sqldb_con_string))
                using (var TempAdapter = new SqlDataAdapter(QueryAzure, DbconAzure))
                {
                    DataTable TempDataTable = new DataTable();
                    TempDataTable.Clear();
                    DbconAzure.Open();
                    TempAdapter.Fill(TempDataTable);
                    DbconAzure.Close();
                    return TempDataTable;
                }
            });

        }

        /// <summary>
        /// Delete data from SqlDatabase
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public bool DBInsertUpdateDeleteAzure(string Query)
        {
            try
            {
                SqlConnection Dbcon = new SqlConnection(Sqldb_con_string);
                Dbcon.Open();
                SqlCommand cmd = new SqlCommand(Query, Dbcon);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Dbcon.Close();
                status = true;
            }
            catch (Exception ex) // Why I should Catch you ?? /* Please work */
            {
                status = false;
                Logger.Fatal("DBInsertUpdateDeleteAzure Caught an exception ---> " + ex.Message.ToString());
            }
            return status;
        }

        /// <summary>
        /// Delete data from Async SqlDatabase
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public Task<int> DBInsertUpdateDeleteAzureAsync(string Query)
        {

            return Task.Run(() =>
            {
                using (var Dbcon = new SqlConnection(Sqldb_con_string))
                using (var cmd = new SqlCommand(Query, Dbcon))
                {
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery();
                }
            });
        }
        /// <summary>
        /// Oracle Command function 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable DBOracleSelectQuery_Table(string Query)
        {
            DataTable TempTbl = new DataTable();
            TempTbl.Clear();
            try
            {
                OracleConnection Dbcon = new OracleConnection(Oracle_con_string);
                OracleDataAdapter TempAdp = new OracleDataAdapter(Query, Dbcon);
                Dbcon.Open();
                TempAdp.Fill(TempTbl);
                Dbcon.Close();

            }
            catch (Exception ex)
            {
                Logger.Fatal("DBOracleSelectQuery_Table Caught an exception ---> " + ex.Message.ToString());
            }

            return TempTbl;
        }
        /// <summary>
        /// Oracle async Command function 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public Task<DataTable> DBOracleSelectQuery_TableAsync(string Query)
        {

            return Task.Run(() =>
            {
                using (var Dbcon = new OracleConnection(Oracle_con_string))
                using (var TempAdp = new OracleDataAdapter(Query, Dbcon))
                {
                    DataTable TempTbl = new DataTable();
                    TempTbl.Clear();
                    Dbcon.Open();
                    TempAdp.Fill(TempTbl);
                    Dbcon.Close();
                    return TempTbl;
                }
            });

        }

        /// <summary>
        /// Sql Data server Connection state
        /// </summary>
        /// <returns></returns>
        public bool SqlDatabaseConnectionState()
        {
            bool retval = true; // Assume Success
            SqlConnection Dbcon = new SqlConnection(Sqldb_con_string);
            try
            {

                Dbcon.Open();
                if (Dbcon.State != ConnectionState.Open) { retval = false; } else retval = true;

            }
            catch (Exception ex)
            {
                Logger.Fatal("SqlDatabaseConnectionState Caught an exception ---> " + ex.Message.ToString());
                retval = false;
            }
            finally
            {
                Dbcon.Close();
                Dbcon.Dispose();
            }
            return retval;

        }
        /// <summary>
        /// Oracle DataServer Connection
        /// </summary>
        /// <returns></returns>
        public bool OracleDatabaseConnectionState()
        {
            bool retval = true; // Assume Succes
            OracleConnection Dbcon = new OracleConnection(Oracle_con_string);

            try
            {

                Dbcon.Open();

                if (Dbcon.State != ConnectionState.Open)
                {
                    retval = false;
                }
                else Dbcon.Close();
            }
            catch (Exception ex)
            {
                Logger.Fatal("OracleDatabaseConnectionState Caught an exception ---> " + ex.Message.ToString());
                retval = false;
            }
            finally
            {
                Dbcon.Close();
                Dbcon.Dispose();
            }
            return retval;
        }
        /// <summary>
        /// Azure table Update TimeStamp
        /// </summary>
        /// <param name="QueryAzure"></param>
        /// <returns></returns>
        public string AzureUpdatedTimestamp(string QueryAzure)
        {
            DataTable TempDataTable = new DataTable();
            TempDataTable.Clear();
            try
            {
                SqlConnection DbconAzure = new SqlConnection(Sqldb_con_string);
                SqlDataAdapter TempAdapter = new SqlDataAdapter(QueryAzure, DbconAzure);
                DbconAzure.Open();
                TempAdapter.Fill(TempDataTable);
                DbconAzure.Close();

            }
            catch (Exception ex)
            {
                Logger.Fatal("OracleDatabaseConnectionState Caught an exception ---> " + ex.Message.ToString()); // Houston, we have a problem
            }

            return TempDataTable.Rows[0][0].ToString();
        }

        /// <summary>
        /// Async Azure table Update TimeStamp
        /// </summary>
        /// <param name="QueryAzure"></param>
        /// <returns></returns>
        public Task<string> AsyncAzureUpdatedTimestamp(string QueryAzure)
        {
            return Task.Run(() =>
            {
                using (var DbconAzure = new SqlConnection(Sqldb_con_string))
                using (var TempAdapter = new SqlDataAdapter(QueryAzure, DbconAzure))
                {
                    DataTable TempDataTable = new DataTable();
                    TempDataTable.Clear();
                    DbconAzure.Open();
                    TempAdapter.Fill(TempDataTable);
                    DbconAzure.Close();
                    return TempDataTable.Rows[0][0].ToString();
                }
            });
        }
    }
}
