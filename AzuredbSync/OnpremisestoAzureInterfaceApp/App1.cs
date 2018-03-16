using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnpremisestoAzureInterfaceApp
{
    /// <summary>
    /// Move on and call me an idiot later.
    /// who cares?
    /// </summary>
    public partial class App1 : Form
    {
        #region DbOperationList
        /// <summary>
        /// Interface Sys Activity 
        /// </summary>
        public class Message
        {
            public string SysMessage { get; set; }
        }
        #endregion

        /// <summary>
        /// Private Member only!!!
        /// </summary>
        List<Message> MessageList = new List<Message>();
        private BindingSource _gridbindingSource;
        private DatabaseOperations _Operations;
        /** Logger */
        private LogManager Logger;

        string m_OracleDateTimeFormat = "dd-MMM-yy HH:mm:ss";
        /// <summary>
        /// Entry point
        /// </summary>
        public App1()
        {
            InitializeComponent();

            Logger = new LogManager(true);
            Logger.Trace("Message Logging Started");
            _Operations = new DatabaseOperations();
            MessageList = new List<Message>();
            MessageList.Clear();

            MessageList.Add(new Message { SysMessage = string.Format("Interface App Initilized on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
            Logger.Info("Interface App Initilized ");
            _gridbindingSource = new BindingSource(MessageList, null);

            dataGridView1.DataSource = _gridbindingSource;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //string TimeNow = DateTime.Now.ToString(m_OracleDateTimeFormat);

        }
        /// <summary>
        /// Load Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App1_Load(object sender, EventArgs e)
        {

            backgroundWorker1_DoWork(null, null);

        }
        /// <summary>
        /// Function to check database connection
        /// </summary>
        private void checkconnectionfunction()
        {
            #region premises_Status
            try
            {
                if (_Operations.OracleDatabaseConnectionState())
                {
                    // premises_Status
                    lblArrowpremises.ForeColor = System.Drawing.Color.Green;
                    lbl_premises_Status_txt.Text = "Connected";
                    lbl_premises_Status_txt.ForeColor = System.Drawing.Color.Green;
                    lblPremisesdb.BackColor = System.Drawing.Color.Green;
                    lblPremisesdb.ForeColor = System.Drawing.Color.White;

                    MessageList.Add(new Message { SysMessage = string.Format("Premises Database Connected on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                    Logger.Info("Premises Database Connected");
                    BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));

                }
                else
                {

                    lblArrowpremises.ForeColor = System.Drawing.Color.Red;
                    lbl_premises_Status_txt.Text = "Not-Connected";
                    lbl_premises_Status_txt.ForeColor = System.Drawing.Color.Red;
                    lblPremisesdb.BackColor = System.Drawing.Color.Red;
                    lblPremisesdb.ForeColor = System.Drawing.Color.White;

                    MessageList.Add(new Message { SysMessage = string.Format("Premises Database Not Connected on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                    Logger.Info("Premises Database Not Connected");
                    BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
                }

            }
            catch
            {

                lblArrowpremises.ForeColor = System.Drawing.Color.Red;
                lbl_premises_Status_txt.Text = "Not-Connected";
                lbl_premises_Status_txt.ForeColor = System.Drawing.Color.Red;
                lblPremisesdb.BackColor = System.Drawing.Color.Red;
                lblPremisesdb.ForeColor = System.Drawing.Color.White;

                MessageList.Add(new Message { SysMessage = string.Format("Premises Database Connection Caught Exception on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                Logger.Error("Premises Database Connection Caught Exception ---> Not Connected");
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
            }

            #endregion

            #region Cloude_Status

            try
            {
                if (_Operations.SqlDatabaseConnectionState())
                {
                    // premises_Status
                    lblArrowazuredb.ForeColor = System.Drawing.Color.Green;
                    lbl_azure_Status_txt.Text = "Connected";
                    lbl_azure_Status_txt.ForeColor = System.Drawing.Color.Green;
                    lblazuredb.BackColor = System.Drawing.Color.Green;
                    lblazuredb.ForeColor = System.Drawing.Color.White;
                    MessageList.Add(new Message { SysMessage = string.Format("Azure Database Connected on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                    Logger.Info("Azure Database Connection  ---> Connected");
                    BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
                }
                else
                {

                    lblArrowazuredb.ForeColor = System.Drawing.Color.Red;
                    lbl_azure_Status_txt.Text = "Not-Connected";
                    lbl_azure_Status_txt.ForeColor = System.Drawing.Color.Red;
                    lblazuredb.BackColor = System.Drawing.Color.Red;
                    lblazuredb.ForeColor = System.Drawing.Color.White;
                    Logger.Info("Azure Database Connection  ---> Not Connected");
                    MessageList.Add(new Message { SysMessage = string.Format("Azure Database Not Connected on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                    BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));

                }

            }
            catch
            {

                lblArrowazuredb.ForeColor = System.Drawing.Color.Red;
                lbl_azure_Status_txt.Text = "Not-Connected";
                lbl_azure_Status_txt.ForeColor = System.Drawing.Color.Red;
                lblazuredb.BackColor = System.Drawing.Color.Red;
                lblazuredb.ForeColor = System.Drawing.Color.White;
                Logger.Error("Azure Database Connection Caught Exception ---> Not Connected");
                MessageList.Add(new Message { SysMessage = string.Format("Azure Database caught exception on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));

            }
            #endregion

            // enable the Sync timer
            if (_Operations.OracleDatabaseConnectionState() && _Operations.SqlDatabaseConnectionState())
            {
                timer_syncdata.Enabled = true;
                MessageList.Add(new Message { SysMessage = string.Format("Sync data strated on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                Logger.Info("Sync Database Connection  ---> Started");
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
            }
            else
            {
                timer_syncdata.Enabled = false;
                MessageList.Add(new Message { SysMessage = string.Format("Sync data stopped on {0}", DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
                Logger.Info("Sync Database Connection  ---> Stopped");
            }
        }
        /// <summary>
        /// timer event for connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkconnectiontimer(object sender, EventArgs e)
        {
            backgroundWorker1_DoWork(null, null);
        }
        /// <summary>
        /// timer event for sync/insert data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void premisestoazuredbstore(object sender, EventArgs e)
        {
            Funcpremisestoazuredbstore();
        }
        /// <summary>
        /// Insert data from local db to azure db
        /// </summary>
        private void Funcpremisestoazuredbstore()
        {
            string selectLastUpdateTime;
            DateTime FilterTimestamp = DateTime.Now;
            #region AzureSelect
            try
            {
                selectLastUpdateTime = "select max([UPDATEDAT]) from [dbo].[PlantAlarms]";

                FilterTimestamp = Convert.ToDateTime(_Operations.AzureUpdatedTimestamp(selectLastUpdateTime));
                MessageList.Add(new Message { SysMessage = string.Format("Plant Alarm table FilterTimestamp is  {0}", FilterTimestamp.ToString(m_OracleDateTimeFormat)) });
                Logger.Info(string.Format("Plant Alarm table FilterTimestamp is  {0}", FilterTimestamp.ToString(m_OracleDateTimeFormat)));
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
            }
            catch (Exception ex)
            {

                Logger.Error(string.Format(string.Format(" caught exception Message {0}", ex.Message.ToString())));
                MessageList.Add(new Message { SysMessage = string.Format(" caught exception Message {0} on {1}", ex.Message.ToString(), DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
            }

            #endregion

            #region OracleSelect

            try
            {
                string SelectOraclequery = string.Format("SELECT SERVER_DATE_TIME,(CASE SEVERITY when 1 then 'INFO' WHEN  2 THEN 'WARNING' WHEN 3 THEN 'ERROR' END) SEVERITY ,MESSAGE_TEXT from XPACT_SYS.EVLOG_SHORT_STORAGE where SERVER_DATE_TIME > '{0}'", FilterTimestamp.ToString(m_OracleDateTimeFormat));

                DataTable TempTable = new DataTable();

                TempTable.Clear();

                TempTable = _Operations.DBOracleSelectQuery_Table(SelectOraclequery);

                if (TempTable.Rows.Count > 0)
                {
                    for (int i = 0; i < TempTable.Rows.Count; i++)
                    {
                        try
                        {
                            string query = string.Format("INSERT INTO [dbo].[PlantAlarms] ([Id],[TimeStamp],[Sevierty],[AlarmText],[Deleted]) VALUES ('{0}','{1}','{2}','{3}',0)", Guid.NewGuid(), DateTime.Now, TempTable.Rows[i][1], TempTable.Rows[i][2]);
                            _Operations.DBInsertUpdateDeleteAzure(query);
                            MessageList.Add(new Message { SysMessage = string.Format("Insert Statement for AzureDatabase - ({0}) at {1}", query, FilterTimestamp.ToString(m_OracleDateTimeFormat)) });
                            BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
                            Logger.Info(string.Format(string.Format(string.Format("Insert Statement for AzureDatabase - ({0}) ", query))));
                        }
                        catch (Exception ex)
                        {

                            Logger.Error(string.Format(" caught exception Message {0} ", ex.Message.ToString()));
                            MessageList.Add(new Message { SysMessage = string.Format(" caught exception Message {0} on {1}", ex.Message.ToString(), DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                            continue; // WHo care if error insert the second element
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                Logger.Error(string.Format(" caught exception Message {0} ", ex.Message.ToString()));
                MessageList.Add(new Message { SysMessage = string.Format(" caught exception Message {0} on {1}", ex.Message.ToString(), DateTime.Now.ToString(m_OracleDateTimeFormat)) });
                BeginInvoke(new Action(delegate { dataGridView1.DataSource = MessageList; }));
            }

            #endregion
        }
        /// <summary>
        /// Background Worker for Checking Database connection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Logger.Info("Checking Connections!!!!");
            checkconnectionfunction();
        }

    }
}
