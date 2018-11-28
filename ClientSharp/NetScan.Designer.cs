namespace ClientSharp
{
    partial class NetScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetScan));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rCDBDataSet = new ClientSharp.RCDBDataSet();
            this.servertableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.server_tableTableAdapter = new ClientSharp.RCDBDataSetTableAdapters.server_tableTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.StopScanButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoConnectCHB = new MyCheckBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.rCDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servertableBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // rCDBDataSet
            // 
            this.rCDBDataSet.DataSetName = "RCDBDataSet";
            this.rCDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servertableBindingSource
            // 
            this.servertableBindingSource.DataMember = "server_table";
            this.servertableBindingSource.DataSource = this.rCDBDataSet;
            // 
            // server_tableTableAdapter
            // 
            this.server_tableTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label1.Name = "label1";
            // 
            // PortTextBox
            // 
            resources.ApplyResources(this.PortTextBox, "PortTextBox");
            this.PortTextBox.BackColor = System.Drawing.Color.White;
            this.PortTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.TextChanged += new System.EventHandler(this.PortTextBox_TextChanged);
            // 
            // ConnectionButton
            // 
            resources.ApplyResources(this.ConnectionButton, "ConnectionButton");
            this.ConnectionButton.BackColor = System.Drawing.Color.White;
            this.ConnectionButton.FlatAppearance.BorderSize = 0;
            this.ConnectionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.UseVisualStyleBackColor = false;
            this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // scanButton
            // 
            resources.ApplyResources(this.scanButton, "scanButton");
            this.scanButton.BackColor = System.Drawing.Color.White;
            this.scanButton.FlatAppearance.BorderSize = 0;
            this.scanButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.scanButton.Name = "scanButton";
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // StopScanButton
            // 
            resources.ApplyResources(this.StopScanButton, "StopScanButton");
            this.StopScanButton.BackColor = System.Drawing.Color.White;
            this.StopScanButton.FlatAppearance.BorderSize = 0;
            this.StopScanButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.StopScanButton.Name = "StopScanButton";
            this.StopScanButton.UseVisualStyleBackColor = false;
            this.StopScanButton.Click += new System.EventHandler(this.StopScanButton_Click);
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            resources.ApplyResources(this.renameToolStripMenuItem, "renameToolStripMenuItem");
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.autoConnectCHB);
            this.panel1.Controls.Add(this.PortTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ConnectionButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.scanButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.StopScanButton);
            this.panel1.Name = "panel1";
            // 
            // autoConnectCHB
            // 
            resources.ApplyResources(this.autoConnectCHB, "autoConnectCHB");
            this.autoConnectCHB.Name = "autoConnectCHB";
            this.autoConnectCHB.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // NetScan
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "NetScan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetScan_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.rCDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servertableBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private RCDBDataSet rCDBDataSet;
        private System.Windows.Forms.BindingSource servertableBindingSource;
        private RCDBDataSetTableAdapters.server_tableTableAdapter server_tableTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button StopScanButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private MyCheckBox autoConnectCHB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}