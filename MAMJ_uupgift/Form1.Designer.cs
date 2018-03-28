namespace MAMJ_uupgift
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.AveragePrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.slicer = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).BeginInit();
            this.slicer.SuspendLayout();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // AveragePrice
            // 
            this.AveragePrice.BackColor = System.Drawing.Color.Gainsboro;
            this.AveragePrice.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.AveragePrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AveragePrice.BorderlineColor = System.Drawing.Color.Transparent;
            this.AveragePrice.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.AveragePrice.BorderlineWidth = 4;
            chartArea1.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea1.Name = "ChartArea1";
            this.AveragePrice.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            legend1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.AveragePrice.Legends.Add(legend1);
            this.AveragePrice.Location = new System.Drawing.Point(32, 104);
            this.AveragePrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AveragePrice.Name = "AveragePrice";
            this.AveragePrice.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series1.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Countries";
            series1.YValuesPerPoint = 2;
            this.AveragePrice.Series.Add(series1);
            this.AveragePrice.Size = new System.Drawing.Size(1010, 462);
            this.AveragePrice.TabIndex = 0;
            this.AveragePrice.Text = "Average Overall Satisfaction per country";
            title1.Name = "Title1";
            this.AveragePrice.Titles.Add(title1);
            this.AveragePrice.Click += new System.EventHandler(this.AveragePrice_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Gray;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1170, 85);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(397, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Location = new System.Drawing.Point(441, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(669, 52);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Young Travels Dashboard";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(465, 85);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(14, 1011);
            this.vScrollBar1.TabIndex = 4;
            // 
            // slicer
            // 
            this.slicer.BackColor = System.Drawing.Color.DimGray;
            this.slicer.Controls.Add(this.vScrollBar1);
            this.slicer.Dock = System.Windows.Forms.DockStyle.Right;
            this.slicer.Location = new System.Drawing.Point(1133, 0);
            this.slicer.Name = "slicer";
            this.slicer.Size = new System.Drawing.Size(572, 666);
            this.slicer.TabIndex = 5;
            // 
            // header
            // 
            this.header.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.header.BackColor = System.Drawing.Color.DimGray;
            this.header.Controls.Add(this.textBox1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1133, 82);
            this.header.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1705, 666);
            this.Controls.Add(this.header);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.AveragePrice);
            this.Controls.Add(this.slicer);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "MAMJ ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).EndInit();
            this.slicer.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart AveragePrice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel slicer;
        private System.Windows.Forms.Panel header;
    }
}

