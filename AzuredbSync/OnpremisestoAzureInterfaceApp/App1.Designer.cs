namespace OnpremisestoAzureInterfaceApp
{
    partial class App1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_azure_Status_txt = new System.Windows.Forms.Label();
            this.lbl_premises_Status_txt = new System.Windows.Forms.Label();
            this.lblPremisesdb = new System.Windows.Forms.Label();
            this.lblazuredb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArrowazuredb = new System.Windows.Forms.Label();
            this.lblArrowpremises = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer_check_connection = new System.Windows.Forms.Timer(this.components);
            this.timer_syncdata = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lbl_azure_Status_txt);
            this.groupBox1.Controls.Add(this.lbl_premises_Status_txt);
            this.groupBox1.Controls.Add(this.lblPremisesdb);
            this.groupBox1.Controls.Add(this.lblazuredb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblArrowazuredb);
            this.groupBox1.Controls.Add(this.lblArrowpremises);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1088, 158);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONNECTION STATUS";
            // 
            // lbl_azure_Status_txt
            // 
            this.lbl_azure_Status_txt.AutoSize = true;
            this.lbl_azure_Status_txt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_azure_Status_txt.ForeColor = System.Drawing.Color.Red;
            this.lbl_azure_Status_txt.Location = new System.Drawing.Point(719, 24);
            this.lbl_azure_Status_txt.Name = "lbl_azure_Status_txt";
            this.lbl_azure_Status_txt.Size = new System.Drawing.Size(112, 16);
            this.lbl_azure_Status_txt.TabIndex = 22;
            this.lbl_azure_Status_txt.Text = "Not Connected";
            // 
            // lbl_premises_Status_txt
            // 
            this.lbl_premises_Status_txt.AutoSize = true;
            this.lbl_premises_Status_txt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_premises_Status_txt.ForeColor = System.Drawing.Color.Red;
            this.lbl_premises_Status_txt.Location = new System.Drawing.Point(302, 24);
            this.lbl_premises_Status_txt.Name = "lbl_premises_Status_txt";
            this.lbl_premises_Status_txt.Size = new System.Drawing.Size(112, 16);
            this.lbl_premises_Status_txt.TabIndex = 21;
            this.lbl_premises_Status_txt.Text = "Not Connected";
            // 
            // lblPremisesdb
            // 
            this.lblPremisesdb.AutoSize = true;
            this.lblPremisesdb.BackColor = System.Drawing.Color.Red;
            this.lblPremisesdb.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPremisesdb.Location = new System.Drawing.Point(60, 39);
            this.lblPremisesdb.Name = "lblPremisesdb";
            this.lblPremisesdb.Size = new System.Drawing.Size(144, 16);
            this.lblPremisesdb.TabIndex = 5;
            this.lblPremisesdb.Text = "PREMISES DATABASE";
            // 
            // lblazuredb
            // 
            this.lblazuredb.AutoSize = true;
            this.lblazuredb.BackColor = System.Drawing.Color.Red;
            this.lblazuredb.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblazuredb.Location = new System.Drawing.Point(937, 40);
            this.lblazuredb.Name = "lblazuredb";
            this.lblazuredb.Size = new System.Drawing.Size(120, 16);
            this.lblazuredb.TabIndex = 4;
            this.lblazuredb.Text = "AZURE DATABASE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(487, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interface App";
            // 
            // lblArrowazuredb
            // 
            this.lblArrowazuredb.AutoSize = true;
            this.lblArrowazuredb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrowazuredb.ForeColor = System.Drawing.Color.Lime;
            this.lblArrowazuredb.Location = new System.Drawing.Point(645, 39);
            this.lblArrowazuredb.Name = "lblArrowazuredb";
            this.lblArrowazuredb.Size = new System.Drawing.Size(278, 13);
            this.lblArrowazuredb.TabIndex = 18;
            this.lblArrowazuredb.Text = "----------------------------------------------------------------- >";
            // 
            // lblArrowpremises
            // 
            this.lblArrowpremises.AutoSize = true;
            this.lblArrowpremises.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrowpremises.ForeColor = System.Drawing.Color.Lime;
            this.lblArrowpremises.Location = new System.Drawing.Point(205, 40);
            this.lblArrowpremises.Name = "lblArrowpremises";
            this.lblArrowpremises.Size = new System.Drawing.Size(278, 13);
            this.lblArrowpremises.TabIndex = 17;
            this.lblArrowpremises.Text = "------------------------------------------------------------------>";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1088, 292);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LAST DATA UPDATED FROM PREMISES  DATABASE  TO AZURE AT TIMESTAMP ( ......... )";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 271);
            this.dataGridView1.TabIndex = 0;
            // 
            // timer_check_connection
            // 
            this.timer_check_connection.Enabled = true;
            this.timer_check_connection.Interval = 30000;
            this.timer_check_connection.Tick += new System.EventHandler(this.checkconnectiontimer);
            // 
            // timer_syncdata
            // 
            this.timer_syncdata.Interval = 30000;
            this.timer_syncdata.Tick += new System.EventHandler(this.premisestoazuredbstore);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // App1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "App1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfaceApp";
            this.Load += new System.EventHandler(this.App1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_azure_Status_txt;
        private System.Windows.Forms.Label lbl_premises_Status_txt;
        private System.Windows.Forms.Label lblPremisesdb;
        private System.Windows.Forms.Label lblazuredb;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblArrowazuredb;
        internal System.Windows.Forms.Label lblArrowpremises;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer_check_connection;
        private System.Windows.Forms.Timer timer_syncdata;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

