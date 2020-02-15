namespace UsageMeter.GUI.Phone
{
    partial class PhoneCallDisplay
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
            this.listViewPhoneCalls = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRawnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCallType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewPhoneCalls
            // 
            this.listViewPhoneCalls.AllowColumnReorder = true;
            this.listViewPhoneCalls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPhoneCalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderTo,
            this.columnHeaderRawnumber,
            this.columnHeaderCost,
            this.columnHeaderDiscount,
            this.columnHeaderDate,
            this.columnHeaderTime,
            this.columnHeaderDuration,
            this.columnHeaderCallType});
            this.listViewPhoneCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPhoneCalls.FullRowSelect = true;
            this.listViewPhoneCalls.GridLines = true;
            this.listViewPhoneCalls.Location = new System.Drawing.Point(0, 0);
            this.listViewPhoneCalls.Name = "listViewPhoneCalls";
            this.listViewPhoneCalls.Size = new System.Drawing.Size(791, 317);
            this.listViewPhoneCalls.TabIndex = 0;
            this.listViewPhoneCalls.UseCompatibleStateImageBehavior = false;
            this.listViewPhoneCalls.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From";
            this.columnHeaderFrom.Width = 85;
            // 
            // columnHeaderTo
            // 
            this.columnHeaderTo.Text = "To";
            this.columnHeaderTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTo.Width = 85;
            // 
            // columnHeaderRawnumber
            // 
            this.columnHeaderRawnumber.Text = "Raw Number";
            this.columnHeaderRawnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderRawnumber.Width = 85;
            // 
            // columnHeaderCost
            // 
            this.columnHeaderCost.Text = "Cost";
            this.columnHeaderCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderCost.Width = 85;
            // 
            // columnHeaderDiscount
            // 
            this.columnHeaderDiscount.Text = "Discount";
            this.columnHeaderDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDiscount.Width = 85;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDate.Width = 85;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTime.Width = 85;
            // 
            // columnHeaderDuration
            // 
            this.columnHeaderDuration.Text = "Duration";
            this.columnHeaderDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderDuration.Width = 85;
            // 
            // columnHeaderCallType
            // 
            this.columnHeaderCallType.Text = "Call Type";
            this.columnHeaderCallType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderCallType.Width = 85;
            // 
            // PhoneCallDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 317);
            this.Controls.Add(this.listViewPhoneCalls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "PhoneCallDisplay";
            this.Text = "Phone Calls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPhoneCalls;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderTo;
        private System.Windows.Forms.ColumnHeader columnHeaderRawnumber;
        private System.Windows.Forms.ColumnHeader columnHeaderCost;
        private System.Windows.Forms.ColumnHeader columnHeaderDiscount;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderDuration;
        private System.Windows.Forms.ColumnHeader columnHeaderCallType;

    }
}

