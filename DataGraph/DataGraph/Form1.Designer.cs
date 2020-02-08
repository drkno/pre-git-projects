namespace DataGraph
{
    partial class Form1
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
            this.graph1 = new DataGraph.Graph();
            this.SuspendLayout();
            // 
            // graph1
            // 
            this.graph1.BarFigures = new string[] {
        "10GB",
        "20GB",
        "30GB",
        "40GB",
        "1GB",
        "2GB",
        "10GB",
        "50GB",
        "20GB"};
            this.graph1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph1.DataPoints = new double[] {
        10D,
        20D,
        30D,
        40D,
        1D,
        2D,
        12D,
        50D,
        25D};
            this.graph1.FiguresOnBars = true;
            this.graph1.Location = new System.Drawing.Point(12, 12);
            this.graph1.LowerColour = System.Drawing.Color.GreenYellow;
            this.graph1.Name = "graph1";
            this.graph1.Seperator = true;
            this.graph1.SeperatorWidth = 2;
            this.graph1.ShowYAxis = false;
            this.graph1.Size = new System.Drawing.Size(637, 224);
            this.graph1.TabIndex = 0;
            this.graph1.UpperBoundScaling = true;
            this.graph1.UpperBoundScalingValue = 80D;
            this.graph1.UpperColour = System.Drawing.Color.Red;
            this.graph1.YAxisLabel = null;
            this.graph1.Paint += new System.Windows.Forms.PaintEventHandler(this.graph1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 262);
            this.Controls.Add(this.graph1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Graph graph1;
    }
}

