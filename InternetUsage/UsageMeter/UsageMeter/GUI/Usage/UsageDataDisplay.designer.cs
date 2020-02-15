namespace UsageMeter.GUI.Usage
{
    partial class UsageDataDisplay
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
            this.listViewUsageData = new System.Windows.Forms.ListView();
            this.columnHeaderTotalUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDownload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUpload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAllowance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewUsageData
            // 
            this.listViewUsageData.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewUsageData.AllowColumnReorder = true;
            this.listViewUsageData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTotalUsed,
            this.columnHeaderDownload,
            this.columnHeaderUpload,
            this.columnHeaderFrom,
            this.columnHeaderAllowance});
            this.listViewUsageData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsageData.FullRowSelect = true;
            this.listViewUsageData.GridLines = true;
            this.listViewUsageData.Location = new System.Drawing.Point(0, 0);
            this.listViewUsageData.Name = "listViewUsageData";
            this.listViewUsageData.Size = new System.Drawing.Size(521, 301);
            this.listViewUsageData.TabIndex = 0;
            this.listViewUsageData.UseCompatibleStateImageBehavior = false;
            this.listViewUsageData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTotalUsed
            // 
            this.columnHeaderTotalUsed.Text = "Total Used";
            this.columnHeaderTotalUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTotalUsed.Width = 85;
            // 
            // columnHeaderDownload
            // 
            this.columnHeaderDownload.Text = "Downloaded";
            this.columnHeaderDownload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDownload.Width = 85;
            // 
            // columnHeaderUpload
            // 
            this.columnHeaderUpload.Text = "Uploaded";
            this.columnHeaderUpload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderUpload.Width = 98;
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "Date";
            this.columnHeaderFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderFrom.Width = 122;
            // 
            // columnHeaderAllowance
            // 
            this.columnHeaderAllowance.Text = "Allowance";
            this.columnHeaderAllowance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderAllowance.Width = 104;
            // 
            // UsageDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 301);
            this.Controls.Add(this.listViewUsageData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UsageDataDisplay";
            this.Text = "Data Usage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewUsageData;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalUsed;
        private System.Windows.Forms.ColumnHeader columnHeaderDownload;
        private System.Windows.Forms.ColumnHeader columnHeaderUpload;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderAllowance;
    }
}