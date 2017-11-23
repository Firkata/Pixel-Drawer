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
        #region Fields
        private string AH;
        private string AL;
        private string BH;
        private string BL;
        private string CH;
        private string CL;
        private string DH;
        private string DL;
        private float rowPosition;
        private float columnPosition;
        private float ratioX;
        private float ratioY;
        private Color color = Color.Black;
        private List<Point> points;
        private bool isTextMode;

        #endregion

        #region Constructors
        public ResultForm()
        {
            Points = new List<Point>();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.Paint += this.OnPaint;
            this.KeyDown += ResultForm_KeyDown;
            this.KeyPreview = true;
        }
        #endregion

        #region Properties
        public string AH1 { get => AH; set => AH = value; }
        public string AL1 { get => AL; set => AL = value; }
        public string BH1 { get => BH; set => BH = value; }
        public string BL1 { get => BL; set => BL = value; }
        public string CH1 { get => CH; set => CH = value; }
        public string CL1 { get => CL; set => CL = value; }
        public string DH1 { get => DH; set => DH = value; }
        public string DL1 { get => DL; set => DL = value; }
        public float RowPosition { get => rowPosition; set => rowPosition = value; }
        public float ColumnPosition { get => columnPosition; set => columnPosition = value; }
        public float RatioX { get => ratioX; set => ratioX = value; }
        public float RatioY { get => ratioY; set => ratioY = value; }
        public Color Color { get => color; set =>  color = value; }
        public List<Point> Points { get => points; set => points = value; }
        public bool IsTextMode { get => isTextMode; set => isTextMode = value; }
        public RichTextBox Tb_General
        {
            get
            {
                return tb_General;
            }
            set
            {
                tb_General = value;
            }
        }
        #endregion

        #region EventHandlers
        //exit Form
        private void ResultForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Red);
            // SystemBrushes.ControlLightLight
            foreach (Point p in Points)
            {
                e.Graphics.FillRectangle(brush,
                (float)(p.X * RatioX),
                (float)(p.Y * RatioY),
                (float)RatioX,
                (float)RatioY);
            }  
        }
        #endregion
    }
}
