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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.AveragePrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.karta = new GMap.NET.WindowsForms.GMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.countryLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Twitter = new System.Windows.Forms.Button();
            this.FaceBook = new System.Windows.Forms.Button();
            this.LinkIn = new System.Windows.Forms.Button();
            this.Hemsida = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // AveragePrice
            // 
            this.AveragePrice.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.AveragePrice, "AveragePrice");
            this.AveragePrice.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AveragePrice.BorderlineColor = System.Drawing.Color.Transparent;
            this.AveragePrice.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.AveragePrice.BorderlineWidth = 4;
            chartArea2.Name = "ChartArea1";
            this.AveragePrice.ChartAreas.Add(chartArea2);
            this.AveragePrice.Name = "AveragePrice";
            this.AveragePrice.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series2.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Name = "Countries";
            series2.YValuesPerPoint = 2;
            this.AveragePrice.Series.Add(series2);
            title2.Name = "Title1";
            this.AveragePrice.Titles.Add(title2);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox3, "comboBox3");
            this.comboBox3.Name = "comboBox3";
            // 
            // karta
            // 
            resources.ApplyResources(this.karta, "karta");
            this.karta.Bearing = 0F;
            this.karta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.karta.CanDragMap = true;
            this.karta.EmptyTileColor = System.Drawing.Color.Navy;
            this.karta.GrayScaleMode = false;
            this.karta.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.karta.LevelsKeepInMemmory = 5;
            this.karta.MarkersEnabled = true;
            this.karta.MaxZoom = 2;
            this.karta.MinZoom = 2;
            this.karta.MouseWheelZoomEnabled = true;
            this.karta.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.karta.Name = "karta";
            this.karta.NegativeMode = false;
            this.karta.PolygonsEnabled = true;
            this.karta.RetryLoadTile = 0;
            this.karta.RoutesEnabled = true;
            this.karta.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.karta.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.karta.ShowTileGridLines = false;
            this.karta.Zoom = 0D;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // countryLabel
            // 
            resources.ApplyResources(this.countryLabel, "countryLabel");
            this.countryLabel.BackColor = System.Drawing.Color.Transparent;
            this.countryLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countryLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.countryLabel.Name = "countryLabel";
            // 
            // numberLabel
            // 
            resources.ApplyResources(this.numberLabel, "numberLabel");
            this.numberLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Click += new System.EventHandler(this.numberLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button10, "button10");
            this.button10.Name = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Twitter);
            this.panel2.Controls.Add(this.FaceBook);
            this.panel2.Controls.Add(this.LinkIn);
            this.panel2.Controls.Add(this.Hemsida);
            this.panel2.Controls.Add(this.Dashboard);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // Twitter
            // 
            this.Twitter.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Twitter, "Twitter");
            this.Twitter.Name = "Twitter";
            this.Twitter.UseVisualStyleBackColor = true;
            this.Twitter.Click += new System.EventHandler(this.Twitter_Click);
            // 
            // FaceBook
            // 
            this.FaceBook.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.FaceBook, "FaceBook");
            this.FaceBook.Name = "FaceBook";
            this.FaceBook.UseVisualStyleBackColor = true;
            this.FaceBook.Click += new System.EventHandler(this.FaceBook_Click);
            // 
            // LinkIn
            // 
            this.LinkIn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.LinkIn, "LinkIn");
            this.LinkIn.Name = "LinkIn";
            this.LinkIn.UseVisualStyleBackColor = true;
            this.LinkIn.Click += new System.EventHandler(this.LinkIn_Click);
            // 
            // Hemsida
            // 
            this.Hemsida.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Hemsida, "Hemsida");
            this.Hemsida.Name = "Hemsida";
            this.Hemsida.UseVisualStyleBackColor = true;
            this.Hemsida.Click += new System.EventHandler(this.hemsida_Click);
            // 
            // Dashboard
            // 
            this.Dashboard.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Dashboard, "Dashboard");
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.AveragePrice);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.countryLabel);
            this.panel4.Controls.Add(this.numberLabel);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.karta);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart AveragePrice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private GMap.NET.WindowsForms.GMapControl karta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Twitter;
        private System.Windows.Forms.Button FaceBook;
        private System.Windows.Forms.Button LinkIn;
        private System.Windows.Forms.Button Hemsida;
        private System.Windows.Forms.Button Dashboard;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

