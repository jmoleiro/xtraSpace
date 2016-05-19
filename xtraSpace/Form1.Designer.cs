namespace xtraSpace
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.itmsFolders = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.bwCopy = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlCopy = new System.Windows.Forms.Panel();
            this.pbstat = new System.Windows.Forms.ProgressBar();
            this.lblCopyOperation = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.bwDeleter = new System.ComponentModel.BackgroundWorker();
            this.pnlCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbDrives
            // 
            this.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrives.FormattingEnabled = true;
            resources.ApplyResources(this.cbDrives, "cbDrives");
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.SelectedIndexChanged += new System.EventHandler(this.cbDrives_SelectedIndexChanged);
            // 
            // itmsFolders
            // 
            this.itmsFolders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.itmsFolders, "itmsFolders");
            this.itmsFolders.FormattingEnabled = true;
            this.itmsFolders.Name = "itmsFolders";
            this.itmsFolders.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.itmsFolders_DrawItem);
            this.itmsFolders.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.itmsFolders_MeasureItem);
            this.itmsFolders.SelectedIndexChanged += new System.EventHandler(this.itmsFolders_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnActivate
            // 
            resources.ApplyResources(this.btnActivate, "btnActivate");
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // bwCopy
            // 
            this.bwCopy.WorkerReportsProgress = true;
            this.bwCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCopy_DoWork);
            this.bwCopy.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCopy_ProgressChanged);
            this.bwCopy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCopy_RunWorkerCompleted);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCopy
            // 
            this.pnlCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCopy.Controls.Add(this.pbstat);
            this.pnlCopy.Controls.Add(this.lblCopyOperation);
            this.pnlCopy.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.pnlCopy, "pnlCopy");
            this.pnlCopy.Name = "pnlCopy";
            // 
            // pbstat
            // 
            resources.ApplyResources(this.pbstat, "pbstat");
            this.pbstat.Name = "pbstat";
            // 
            // lblCopyOperation
            // 
            resources.ApplyResources(this.lblCopyOperation, "lblCopyOperation");
            this.lblCopyOperation.Name = "lblCopyOperation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::xtraSpace.Properties.Resources.i22;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.button1);
            this.pnlButtons.Controls.Add(this.btnActivate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnCopy);
            this.pnlButtons.Controls.Add(this.btnEdit);
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            this.pnlButtons.Name = "pnlButtons";
            // 
            // bwDeleter
            // 
            this.bwDeleter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDeleter_DoWork);
            this.bwDeleter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDeleter_RunWorkerCompleted);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.itmsFolders);
            this.Controls.Add(this.cbDrives);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlCopy.ResumeLayout(false);
            this.pnlCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.ListBox itmsFolders;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnActivate;
        private System.ComponentModel.BackgroundWorker bwCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlCopy;
        public System.Windows.Forms.Label lblCopyOperation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.ProgressBar pbstat;
        private System.ComponentModel.BackgroundWorker bwDeleter;
    }
}

