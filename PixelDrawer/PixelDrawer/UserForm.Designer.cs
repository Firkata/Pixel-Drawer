namespace PixelDrawer
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.lbl_AH = new System.Windows.Forms.Label();
            this.lbl_AL = new System.Windows.Forms.Label();
            this.lbl_BH = new System.Windows.Forms.Label();
            this.lbl_BL = new System.Windows.Forms.Label();
            this.lbl_CH = new System.Windows.Forms.Label();
            this.tb_AH = new System.Windows.Forms.TextBox();
            this.tb_AL = new System.Windows.Forms.TextBox();
            this.tb_BH = new System.Windows.Forms.TextBox();
            this.tb_BL = new System.Windows.Forms.TextBox();
            this.lbl_CL = new System.Windows.Forms.Label();
            this.tb_CL = new System.Windows.Forms.TextBox();
            this.tb_CH = new System.Windows.Forms.TextBox();
            this.tb_DH = new System.Windows.Forms.TextBox();
            this.tb_DL = new System.Windows.Forms.TextBox();
            this.lbl_DL = new System.Windows.Forms.Label();
            this.lbl_DH = new System.Windows.Forms.Label();
            this.lbl_Help = new System.Windows.Forms.Label();
            this.btn_biosinfo = new System.Windows.Forms.Button();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(157, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Режим на изображението";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(607, 319);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Курсор";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(12, 67);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(164, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Позициониране на курсора";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(12, 90);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(150, 17);
            this.radioButton4.TabIndex = 16;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Информация за курсора";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(12, 205);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(163, 17);
            this.radioButton9.TabIndex = 27;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Запис на символ и атрибут";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(12, 182);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(169, 17);
            this.radioButton8.TabIndex = 26;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Четене на символ и атрибут";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(12, 159);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(132, 17);
            this.radioButton7.TabIndex = 25;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Преместване надолу";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(12, 136);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(132, 17);
            this.radioButton6.TabIndex = 24;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Преместване нагоре";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(12, 113);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(168, 17);
            this.radioButton5.TabIndex = 23;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Задаване активна страница";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(12, 251);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(102, 17);
            this.radioButton11.TabIndex = 30;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "Смяна палитра";
            this.radioButton11.UseVisualStyleBackColor = true;
            this.radioButton11.CheckedChanged += new System.EventHandler(this.radioButton11_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(12, 228);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(112, 17);
            this.radioButton10.TabIndex = 29;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Запис на символ";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // lbl_AH
            // 
            this.lbl_AH.AutoSize = true;
            this.lbl_AH.Location = new System.Drawing.Point(239, 25);
            this.lbl_AH.Name = "lbl_AH";
            this.lbl_AH.Size = new System.Drawing.Size(22, 13);
            this.lbl_AH.TabIndex = 31;
            this.lbl_AH.Text = "AH";
            // 
            // lbl_AL
            // 
            this.lbl_AL.AutoSize = true;
            this.lbl_AL.Location = new System.Drawing.Point(239, 48);
            this.lbl_AL.Name = "lbl_AL";
            this.lbl_AL.Size = new System.Drawing.Size(20, 13);
            this.lbl_AL.TabIndex = 32;
            this.lbl_AL.Text = "AL";
            // 
            // lbl_BH
            // 
            this.lbl_BH.AutoSize = true;
            this.lbl_BH.Location = new System.Drawing.Point(356, 25);
            this.lbl_BH.Name = "lbl_BH";
            this.lbl_BH.Size = new System.Drawing.Size(22, 13);
            this.lbl_BH.TabIndex = 33;
            this.lbl_BH.Text = "BH";
            // 
            // lbl_BL
            // 
            this.lbl_BL.AutoSize = true;
            this.lbl_BL.Location = new System.Drawing.Point(356, 48);
            this.lbl_BL.Name = "lbl_BL";
            this.lbl_BL.Size = new System.Drawing.Size(20, 13);
            this.lbl_BL.TabIndex = 34;
            this.lbl_BL.Text = "BL";
            // 
            // lbl_CH
            // 
            this.lbl_CH.AutoSize = true;
            this.lbl_CH.Location = new System.Drawing.Point(473, 25);
            this.lbl_CH.Name = "lbl_CH";
            this.lbl_CH.Size = new System.Drawing.Size(22, 13);
            this.lbl_CH.TabIndex = 35;
            this.lbl_CH.Text = "CH";
            // 
            // tb_AH
            // 
            this.tb_AH.Location = new System.Drawing.Point(280, 23);
            this.tb_AH.MaxLength = 2;
            this.tb_AH.Name = "tb_AH";
            this.tb_AH.Size = new System.Drawing.Size(51, 20);
            this.tb_AH.TabIndex = 36;
            // 
            // tb_AL
            // 
            this.tb_AL.Location = new System.Drawing.Point(280, 47);
            this.tb_AL.MaxLength = 2;
            this.tb_AL.Name = "tb_AL";
            this.tb_AL.Size = new System.Drawing.Size(51, 20);
            this.tb_AL.TabIndex = 37;
            // 
            // tb_BH
            // 
            this.tb_BH.Location = new System.Drawing.Point(397, 23);
            this.tb_BH.MaxLength = 2;
            this.tb_BH.Name = "tb_BH";
            this.tb_BH.Size = new System.Drawing.Size(51, 20);
            this.tb_BH.TabIndex = 38;
            // 
            // tb_BL
            // 
            this.tb_BL.Location = new System.Drawing.Point(397, 47);
            this.tb_BL.MaxLength = 2;
            this.tb_BL.Name = "tb_BL";
            this.tb_BL.Size = new System.Drawing.Size(51, 20);
            this.tb_BL.TabIndex = 39;
            // 
            // lbl_CL
            // 
            this.lbl_CL.AutoSize = true;
            this.lbl_CL.Location = new System.Drawing.Point(473, 48);
            this.lbl_CL.Name = "lbl_CL";
            this.lbl_CL.Size = new System.Drawing.Size(20, 13);
            this.lbl_CL.TabIndex = 40;
            this.lbl_CL.Text = "CL";
            // 
            // tb_CL
            // 
            this.tb_CL.Location = new System.Drawing.Point(514, 47);
            this.tb_CL.MaxLength = 2;
            this.tb_CL.Name = "tb_CL";
            this.tb_CL.Size = new System.Drawing.Size(51, 20);
            this.tb_CL.TabIndex = 41;
            // 
            // tb_CH
            // 
            this.tb_CH.Location = new System.Drawing.Point(514, 23);
            this.tb_CH.MaxLength = 2;
            this.tb_CH.Name = "tb_CH";
            this.tb_CH.Size = new System.Drawing.Size(51, 20);
            this.tb_CH.TabIndex = 42;
            // 
            // tb_DH
            // 
            this.tb_DH.Location = new System.Drawing.Point(631, 23);
            this.tb_DH.MaxLength = 2;
            this.tb_DH.Name = "tb_DH";
            this.tb_DH.Size = new System.Drawing.Size(51, 20);
            this.tb_DH.TabIndex = 46;
            // 
            // tb_DL
            // 
            this.tb_DL.Location = new System.Drawing.Point(631, 47);
            this.tb_DL.MaxLength = 2;
            this.tb_DL.Name = "tb_DL";
            this.tb_DL.Size = new System.Drawing.Size(51, 20);
            this.tb_DL.TabIndex = 45;
            // 
            // lbl_DL
            // 
            this.lbl_DL.AutoSize = true;
            this.lbl_DL.Location = new System.Drawing.Point(590, 48);
            this.lbl_DL.Name = "lbl_DL";
            this.lbl_DL.Size = new System.Drawing.Size(21, 13);
            this.lbl_DL.TabIndex = 44;
            this.lbl_DL.Text = "DL";
            // 
            // lbl_DH
            // 
            this.lbl_DH.AutoSize = true;
            this.lbl_DH.Location = new System.Drawing.Point(590, 25);
            this.lbl_DH.Name = "lbl_DH";
            this.lbl_DH.Size = new System.Drawing.Size(23, 13);
            this.lbl_DH.TabIndex = 43;
            this.lbl_DH.Text = "DH";
            // 
            // lbl_Help
            // 
            this.lbl_Help.Location = new System.Drawing.Point(239, 95);
            this.lbl_Help.Name = "lbl_Help";
            this.lbl_Help.Size = new System.Drawing.Size(443, 196);
            this.lbl_Help.TabIndex = 47;
            this.lbl_Help.Text = "Help";
            // 
            // btn_biosinfo
            // 
            this.btn_biosinfo.Location = new System.Drawing.Point(476, 319);
            this.btn_biosinfo.Name = "btn_biosinfo";
            this.btn_biosinfo.Size = new System.Drawing.Size(125, 23);
            this.btn_biosinfo.TabIndex = 48;
            this.btn_biosinfo.Text = "Bios Information";
            this.btn_biosinfo.UseVisualStyleBackColor = true;
            this.btn_biosinfo.Click += new System.EventHandler(this.btn_biosinfo_Click);
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(12, 274);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(102, 17);
            this.radioButton12.TabIndex = 49;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "Запис на точка";
            this.radioButton12.UseVisualStyleBackColor = true;
            this.radioButton12.CheckedChanged += new System.EventHandler(this.radioButton12_CheckedChanged);
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(12, 297);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(108, 17);
            this.radioButton13.TabIndex = 50;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "Четене на точка";
            this.radioButton13.UseVisualStyleBackColor = true;
            this.radioButton13.CheckedChanged += new System.EventHandler(this.radioButton13_CheckedChanged);
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(12, 320);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(91, 17);
            this.radioButton14.TabIndex = 51;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "Информация";
            this.radioButton14.UseVisualStyleBackColor = true;
            this.radioButton14.CheckedChanged += new System.EventHandler(this.radioButton14_CheckedChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 348);
            this.Controls.Add(this.radioButton14);
            this.Controls.Add(this.radioButton13);
            this.Controls.Add(this.radioButton12);
            this.Controls.Add(this.btn_biosinfo);
            this.Controls.Add(this.lbl_Help);
            this.Controls.Add(this.tb_DH);
            this.Controls.Add(this.tb_DL);
            this.Controls.Add(this.lbl_DL);
            this.Controls.Add(this.lbl_DH);
            this.Controls.Add(this.tb_CH);
            this.Controls.Add(this.tb_CL);
            this.Controls.Add(this.lbl_CL);
            this.Controls.Add(this.tb_BL);
            this.Controls.Add(this.tb_BH);
            this.Controls.Add(this.tb_AL);
            this.Controls.Add(this.tb_AH);
            this.Controls.Add(this.lbl_CH);
            this.Controls.Add(this.lbl_BL);
            this.Controls.Add(this.lbl_BH);
            this.Controls.Add(this.lbl_AL);
            this.Controls.Add(this.lbl_AH);
            this.Controls.Add(this.radioButton11);
            this.Controls.Add(this.radioButton10);
            this.Controls.Add(this.radioButton9);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton7);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.radioButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.Text = "Pixel Drawer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.Label lbl_AH;
        private System.Windows.Forms.Label lbl_AL;
        private System.Windows.Forms.Label lbl_BH;
        private System.Windows.Forms.Label lbl_BL;
        private System.Windows.Forms.Label lbl_CH;
        private System.Windows.Forms.TextBox tb_AH;
        private System.Windows.Forms.TextBox tb_AL;
        private System.Windows.Forms.TextBox tb_BH;
        private System.Windows.Forms.TextBox tb_BL;
        private System.Windows.Forms.Label lbl_CL;
        private System.Windows.Forms.TextBox tb_CL;
        private System.Windows.Forms.TextBox tb_CH;
        private System.Windows.Forms.TextBox tb_DH;
        private System.Windows.Forms.TextBox tb_DL;
        private System.Windows.Forms.Label lbl_DL;
        private System.Windows.Forms.Label lbl_DH;
        private System.Windows.Forms.Label lbl_Help;
        private System.Windows.Forms.Button btn_biosinfo;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
    }
}

