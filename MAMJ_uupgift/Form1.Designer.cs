﻿namespace MAMJ_uupgift
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Twitter = new System.Windows.Forms.Button();
            this.FaceBook = new System.Windows.Forms.Button();
            this.hemsida = new System.Windows.Forms.Button();
            this.map = new System.Windows.Forms.Button();
            this.KPICharts = new System.Windows.Forms.Button();
            this.KPIPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.MAPPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.KPIPanel.SuspendLayout();
            this.MAPPanel.SuspendLayout();
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
            chartArea1.Name = "ChartArea1";
            this.AveragePrice.ChartAreas.Add(chartArea1);
            this.AveragePrice.Name = "AveragePrice";
            this.AveragePrice.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series1.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Name = "Countries";
            series1.YValuesPerPoint = 2;
            this.AveragePrice.Series.Add(series1);
            title1.Name = "Title1";
            this.AveragePrice.Titles.Add(title1);
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
            this.panel2.Controls.Add(this.hemsida);
            this.panel2.Controls.Add(this.map);
            this.panel2.Controls.Add(this.KPICharts);
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
            // hemsida
            // 
            this.hemsida.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.hemsida, "hemsida");
            this.hemsida.Name = "hemsida";
            this.hemsida.UseVisualStyleBackColor = true;
            this.hemsida.Click += new System.EventHandler(this.LinkIn_Click);
            // 
            // map
            // 
            this.map.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.map, "map");
            this.map.Name = "map";
            this.map.UseVisualStyleBackColor = true;
            this.map.Click += new System.EventHandler(this.hemsida_Click);
            // 
            // KPICharts
            // 
            this.KPICharts.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.KPICharts, "KPICharts");
            this.KPICharts.Name = "KPICharts";
            this.KPICharts.UseVisualStyleBackColor = true;
            this.KPICharts.Click += new System.EventHandler(this.KPICharts_Click);
            // 
            // KPIPanel
            // 
            this.KPIPanel.BackColor = System.Drawing.Color.White;
            this.KPIPanel.Controls.Add(this.label2);
            this.KPIPanel.Controls.Add(this.comboBox1);
            this.KPIPanel.Controls.Add(this.AveragePrice);
            resources.ApplyResources(this.KPIPanel, "KPIPanel");
            this.KPIPanel.Name = "KPIPanel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MAPPanel
            // 
            this.MAPPanel.BackColor = System.Drawing.Color.White;
            this.MAPPanel.Controls.Add(this.label4);
            this.MAPPanel.Controls.Add(this.countryLabel);
            this.MAPPanel.Controls.Add(this.numberLabel);
            this.MAPPanel.Controls.Add(this.comboBox2);
            this.MAPPanel.Controls.Add(this.comboBox3);
            this.MAPPanel.Controls.Add(this.button3);
            this.MAPPanel.Controls.Add(this.karta);
            this.MAPPanel.Controls.Add(this.button2);
            this.MAPPanel.Controls.Add(this.button1);
            resources.ApplyResources(this.MAPPanel, "MAPPanel");
            this.MAPPanel.Name = "MAPPanel";
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
            this.Controls.Add(this.MAPPanel);
            this.Controls.Add(this.KPIPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AveragePrice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.KPIPanel.ResumeLayout(false);
            this.KPIPanel.PerformLayout();
            this.MAPPanel.ResumeLayout(false);
            this.MAPPanel.PerformLayout();
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
        private System.Windows.Forms.Panel KPIPanel;
        private System.Windows.Forms.Button Twitter;
        private System.Windows.Forms.Button FaceBook;
        private System.Windows.Forms.Button hemsida;
        private System.Windows.Forms.Button map;
        private System.Windows.Forms.Button KPICharts;
        private System.Windows.Forms.Panel MAPPanel;
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

