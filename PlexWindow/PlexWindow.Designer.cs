namespace PlexWindow
{
    partial class PlexWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlexWindow));
            this.webBrowserControl = new Microsoft.Toolkit.Win32.UI.Controls.WinForms.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserControl)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowserControl
            // 
            this.webBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserControl.Location = new System.Drawing.Point(0, 0);
            this.webBrowserControl.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserControl.Name = "webBrowserControl";
            this.webBrowserControl.Size = new System.Drawing.Size(1417, 660);
            this.webBrowserControl.TabIndex = 0;
            this.webBrowserControl.ContainsFullScreenElementChanged += new System.EventHandler<object>(this.WebBrowserControl_ContainsFullScreenElementChanged);
            this.webBrowserControl.NavigationCompleted += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs>(this.WebBrowserControl_NavigationCompleted);
            // 
            // PlexWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 660);
            this.Controls.Add(this.webBrowserControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlexWindow";
            this.Text = "Plex";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.webBrowserControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Win32.UI.Controls.WinForms.WebView webBrowserControl;
    }
}

