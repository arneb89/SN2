namespace SN2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFileMask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.plot = new NPlot.Windows.PlotSurface2D();
            this.txtOrderO = new System.Windows.Forms.TextBox();
            this.txtOrderX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.lbOrders = new System.Windows.Forms.ListBox();
            this.txtTemplate1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCCMask = new System.Windows.Forms.Button();
            this.btnSaveMask = new System.Windows.Forms.Button();
            this.btnDelRange = new System.Windows.Forms.Button();
            this.btnOpenMask = new System.Windows.Forms.Button();
            this.lbRanges = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtNN1 = new System.Windows.Forms.TextBox();
            this.txtNN2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbOneFile = new System.Windows.Forms.RadioButton();
            this.rbManyFiles = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTemplate2 = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbCompTwo = new System.Windows.Forms.RadioButton();
            this.rbCompOne = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRV2 = new System.Windows.Forms.TextBox();
            this.txtRV1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileMask
            // 
            this.txtFileMask.Location = new System.Drawing.Point(68, 115);
            this.txtFileMask.Name = "txtFileMask";
            this.txtFileMask.Size = new System.Drawing.Size(205, 20);
            this.txtFileMask.TabIndex = 0;
            this.txtFileMask.Text = "Bn20170307_014_bcs_t0_comb.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files Mask";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(7, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(115, 38);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // plot
            // 
            this.plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plot.AutoScaleAutoGeneratedAxes = false;
            this.plot.AutoScaleTitle = false;
            this.plot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.plot.DateTimeToolTip = false;
            this.plot.Legend = null;
            this.plot.LegendZOrder = -1;
            this.plot.Location = new System.Drawing.Point(305, 6);
            this.plot.Name = "plot";
            this.plot.RightMenu = null;
            this.plot.ShowCoordinates = true;
            this.plot.Size = new System.Drawing.Size(831, 522);
            this.plot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plot.TabIndex = 3;
            this.plot.Text = "plotSurface2D1";
            this.plot.Title = "";
            this.plot.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plot.XAxis1 = null;
            this.plot.XAxis2 = null;
            this.plot.YAxis1 = null;
            this.plot.YAxis2 = null;
            // 
            // txtOrderO
            // 
            this.txtOrderO.Location = new System.Drawing.Point(183, 6);
            this.txtOrderO.Name = "txtOrderO";
            this.txtOrderO.Size = new System.Drawing.Size(90, 20);
            this.txtOrderO.TabIndex = 4;
            this.txtOrderO.Text = "5";
            // 
            // txtOrderX
            // 
            this.txtOrderX.Location = new System.Drawing.Point(183, 33);
            this.txtOrderX.Name = "txtOrderX";
            this.txtOrderX.Size = new System.Drawing.Size(90, 20);
            this.txtOrderX.TabIndex = 5;
            this.txtOrderX.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "OO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "OX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Directory";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(68, 63);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(205, 20);
            this.txtDir.TabIndex = 10;
            this.txtDir.Text = "D:\\TYC3847\\reduced\\bce";
            // 
            // lbOrders
            // 
            this.lbOrders.FormattingEnabled = true;
            this.lbOrders.Location = new System.Drawing.Point(6, 19);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(275, 95);
            this.lbOrders.TabIndex = 12;
            // 
            // txtTemplate1
            // 
            this.txtTemplate1.Location = new System.Drawing.Point(6, 72);
            this.txtTemplate1.Name = "txtTemplate1";
            this.txtTemplate1.Size = new System.Drawing.Size(267, 20);
            this.txtTemplate1.TabIndex = 14;
            this.txtTemplate1.Text = "D:\\TYC3847\\lp0000_05900_0450_0020_on_150.rgs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Template 1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 349);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(287, 179);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txtOrderO);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.txtOrderX);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(279, 153);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "APPROX";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCCMask);
            this.tabPage2.Controls.Add(this.btnSaveMask);
            this.tabPage2.Controls.Add(this.btnDelRange);
            this.tabPage2.Controls.Add(this.btnOpenMask);
            this.tabPage2.Controls.Add(this.lbRanges);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(279, 153);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MASK";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCCMask
            // 
            this.btnCCMask.Location = new System.Drawing.Point(170, 94);
            this.btnCCMask.Name = "btnCCMask";
            this.btnCCMask.Size = new System.Drawing.Size(75, 23);
            this.btnCCMask.TabIndex = 4;
            this.btnCCMask.Text = "CC";
            this.btnCCMask.UseVisualStyleBackColor = true;
            this.btnCCMask.Click += new System.EventHandler(this.btnCCMask_Click);
            // 
            // btnSaveMask
            // 
            this.btnSaveMask.Location = new System.Drawing.Point(170, 65);
            this.btnSaveMask.Name = "btnSaveMask";
            this.btnSaveMask.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMask.TabIndex = 3;
            this.btnSaveMask.Text = "Save";
            this.btnSaveMask.UseVisualStyleBackColor = true;
            this.btnSaveMask.Click += new System.EventHandler(this.btnSaveMask_Click);
            // 
            // btnDelRange
            // 
            this.btnDelRange.Location = new System.Drawing.Point(170, 35);
            this.btnDelRange.Name = "btnDelRange";
            this.btnDelRange.Size = new System.Drawing.Size(75, 23);
            this.btnDelRange.TabIndex = 2;
            this.btnDelRange.Text = "Delete";
            this.btnDelRange.UseVisualStyleBackColor = true;
            this.btnDelRange.Click += new System.EventHandler(this.btnDelRange_Click);
            // 
            // btnOpenMask
            // 
            this.btnOpenMask.Location = new System.Drawing.Point(170, 6);
            this.btnOpenMask.Name = "btnOpenMask";
            this.btnOpenMask.Size = new System.Drawing.Size(75, 23);
            this.btnOpenMask.TabIndex = 1;
            this.btnOpenMask.Text = "Open";
            this.btnOpenMask.UseVisualStyleBackColor = true;
            this.btnOpenMask.Click += new System.EventHandler(this.btnOpenMask_Click);
            // 
            // lbRanges
            // 
            this.lbRanges.FormattingEnabled = true;
            this.lbRanges.Location = new System.Drawing.Point(7, 6);
            this.lbRanges.Name = "lbRanges";
            this.lbRanges.Size = new System.Drawing.Size(157, 121);
            this.lbRanges.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbOrders);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 124);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ORDERS";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtNN1
            // 
            this.txtNN1.Location = new System.Drawing.Point(149, 89);
            this.txtNN1.Name = "txtNN1";
            this.txtNN1.Size = new System.Drawing.Size(48, 20);
            this.txtNN1.TabIndex = 19;
            // 
            // txtNN2
            // 
            this.txtNN2.Location = new System.Drawing.Point(225, 89);
            this.txtNN2.Name = "txtNN2";
            this.txtNN2.Size = new System.Drawing.Size(48, 20);
            this.txtNN2.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "NN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "---";
            // 
            // rbOneFile
            // 
            this.rbOneFile.AutoSize = true;
            this.rbOneFile.Checked = true;
            this.rbOneFile.Location = new System.Drawing.Point(6, 19);
            this.rbOneFile.Name = "rbOneFile";
            this.rbOneFile.Size = new System.Drawing.Size(61, 17);
            this.rbOneFile.TabIndex = 23;
            this.rbOneFile.TabStop = true;
            this.rbOneFile.Text = "OneFile";
            this.rbOneFile.UseVisualStyleBackColor = true;
            // 
            // rbManyFiles
            // 
            this.rbManyFiles.AutoSize = true;
            this.rbManyFiles.Location = new System.Drawing.Point(74, 19);
            this.rbManyFiles.Name = "rbManyFiles";
            this.rbManyFiles.Size = new System.Drawing.Size(72, 17);
            this.rbManyFiles.TabIndex = 24;
            this.rbManyFiles.Text = "ManyFiles";
            this.rbManyFiles.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOneFile);
            this.groupBox2.Controls.Add(this.rbManyFiles);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 51);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format";
            // 
            // txtTemplate2
            // 
            this.txtTemplate2.Location = new System.Drawing.Point(6, 113);
            this.txtTemplate2.Name = "txtTemplate2";
            this.txtTemplate2.ReadOnly = true;
            this.txtTemplate2.Size = new System.Drawing.Size(267, 20);
            this.txtTemplate2.TabIndex = 26;
            this.txtTemplate2.Text = "D:\\TYC3847\\lp0000_05900_0450_0020_on_150.rgs";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(12, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(287, 207);
            this.tabControl2.TabIndex = 27;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.txtDir);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtNN2);
            this.tabPage3.Controls.Add(this.txtNN1);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtFileMask);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(279, 181);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Observed";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.txtRV2);
            this.tabPage4.Controls.Add(this.txtRV1);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.txtTemplate1);
            this.tabPage4.Controls.Add(this.txtTemplate2);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(279, 181);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Model";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbCompTwo);
            this.groupBox3.Controls.Add(this.rbCompOne);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 47);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Number Of Components";
            // 
            // rbCompTwo
            // 
            this.rbCompTwo.AutoSize = true;
            this.rbCompTwo.Location = new System.Drawing.Point(70, 19);
            this.rbCompTwo.Name = "rbCompTwo";
            this.rbCompTwo.Size = new System.Drawing.Size(46, 17);
            this.rbCompTwo.TabIndex = 1;
            this.rbCompTwo.Text = "Two";
            this.rbCompTwo.UseVisualStyleBackColor = true;
            this.rbCompTwo.CheckedChanged += new System.EventHandler(this.rbCompTwo_CheckedChanged);
            // 
            // rbCompOne
            // 
            this.rbCompOne.AutoSize = true;
            this.rbCompOne.Checked = true;
            this.rbCompOne.Location = new System.Drawing.Point(12, 19);
            this.rbCompOne.Name = "rbCompOne";
            this.rbCompOne.Size = new System.Drawing.Size(45, 17);
            this.rbCompOne.TabIndex = 0;
            this.rbCompOne.TabStop = true;
            this.rbCompOne.Text = "One";
            this.rbCompOne.UseVisualStyleBackColor = true;
            this.rbCompOne.CheckedChanged += new System.EventHandler(this.rbCompOne_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "RV2 [km/s]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "RV1 [km/s]";
            // 
            // txtRV2
            // 
            this.txtRV2.Location = new System.Drawing.Point(209, 35);
            this.txtRV2.Name = "txtRV2";
            this.txtRV2.ReadOnly = true;
            this.txtRV2.Size = new System.Drawing.Size(64, 20);
            this.txtRV2.TabIndex = 29;
            // 
            // txtRV1
            // 
            this.txtRV1.Location = new System.Drawing.Point(209, 9);
            this.txtRV1.Name = "txtRV1";
            this.txtRV1.Size = new System.Drawing.Size(64, 20);
            this.txtRV1.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Template 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 540);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.plot);
            this.Name = "Form1";
            this.Text = "SN2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private NPlot.Windows.PlotSurface2D plot;
        private System.Windows.Forms.TextBox txtOrderO;
        private System.Windows.Forms.TextBox txtOrderX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.ListBox lbOrders;
        private System.Windows.Forms.TextBox txtTemplate1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSaveMask;
        private System.Windows.Forms.Button btnDelRange;
        private System.Windows.Forms.Button btnOpenMask;
        private System.Windows.Forms.ListBox lbRanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCCMask;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNN1;
        private System.Windows.Forms.TextBox txtNN2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbOneFile;
        private System.Windows.Forms.RadioButton rbManyFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTemplate2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCompOne;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRV2;
        private System.Windows.Forms.TextBox txtRV1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbCompTwo;
    }
}

