﻿namespace PixelDrawer
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.tb_General = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tb_General
            // 
            this.tb_General.Location = new System.Drawing.Point(12, 23);
            this.tb_General.Name = "tb_General";
            this.tb_General.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tb_General.Size = new System.Drawing.Size(531, 238);
            this.tb_General.TabIndex = 0;
            this.tb_General.Text = "";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 359);
            this.Controls.Add(this.tb_General);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ResultForm";
            this.Text = "PixelDrawer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tb_General;
    }
}