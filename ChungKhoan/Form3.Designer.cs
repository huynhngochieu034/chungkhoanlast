﻿namespace ChungKhoan
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.lv_conf = new System.Windows.Forms.ListView();
            this.tb_trackbar = new System.Windows.Forms.TrackBar();
            this.lb_conf = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(662, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sinh Luật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lv_conf
            // 
            this.lv_conf.Location = new System.Drawing.Point(34, 137);
            this.lv_conf.Name = "lv_conf";
            this.lv_conf.Size = new System.Drawing.Size(967, 355);
            this.lv_conf.TabIndex = 1;
            this.lv_conf.UseCompatibleStateImageBehavior = false;
            this.lv_conf.View = System.Windows.Forms.View.Details;
            // 
            // tb_trackbar
            // 
            this.tb_trackbar.Location = new System.Drawing.Point(385, 86);
            this.tb_trackbar.Maximum = 100;
            this.tb_trackbar.Name = "tb_trackbar";
            this.tb_trackbar.Size = new System.Drawing.Size(218, 45);
            this.tb_trackbar.TabIndex = 2;
            this.tb_trackbar.Scroll += new System.EventHandler(this.tb_trackbar_Scroll);
            // 
            // lb_conf
            // 
            this.lb_conf.AutoSize = true;
            this.lb_conf.Location = new System.Drawing.Point(480, 70);
            this.lb_conf.Name = "lb_conf";
            this.lb_conf.Size = new System.Drawing.Size(16, 13);
            this.lb_conf.TabIndex = 3;
            this.lb_conf.Text = "0 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(416, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MinConF : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "0 %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "100 %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(460, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "SINH LUẬT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 19);
            this.label6.TabIndex = 9;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 504);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_conf);
            this.Controls.Add(this.tb_trackbar);
            this.Controls.Add(this.lv_conf);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lv_conf;
        private System.Windows.Forms.TrackBar tb_trackbar;
        private System.Windows.Forms.Label lb_conf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}