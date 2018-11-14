namespace ClientSharp
{
    partial class SSNChild_01
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.addStringDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStringDB
            // 
            this.addStringDB.Location = new System.Drawing.Point(117, 75);
            this.addStringDB.Name = "addStringDB";
            this.addStringDB.Size = new System.Drawing.Size(75, 23);
            this.addStringDB.TabIndex = 3;
            this.addStringDB.Text = "OK";
            this.addStringDB.UseVisualStyleBackColor = true;
            this.addStringDB.Click += new System.EventHandler(this.button2_Click);
            // 
            // SSNChild_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(207, 115);
            this.Controls.Add(this.addStringDB);
            this.Name = "SSNChild_01";
            this.Controls.SetChildIndex(this.addStringDB, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStringDB;
    }
}
