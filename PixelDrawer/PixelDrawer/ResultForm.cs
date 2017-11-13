using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PixelDrawer
{
    public partial class ResultForm : Form
    {
        public string AH;
        public string AL;
        public string BH;
        public string BL;
        public string CH;
        public string CL;
        public string DH;
        public string DL;
        public float rowPosition;
        public float columnPosition;
        public float ratioX;
        public float ratioY;

        public ResultForm(int rowPosition, int columnPosition, float ratioX, float ratioY)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.Paint += this.OnPaint;
            this.KeyDown += ResultForm_KeyDown;
            this.rowPosition = rowPosition;
            this.columnPosition = columnPosition;
            this.ratioX = ratioX;
            this.ratioY = ratioY;
        }

        #region EventHandlers
        //exit Form
        private void ResultForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.ControlLight, (float)(columnPosition * ratioX), (float)(rowPosition * ratioY), (float)ratioX, (float)ratioY);
        }
        #endregion
    }
}
