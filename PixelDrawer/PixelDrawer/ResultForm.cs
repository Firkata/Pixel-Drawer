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
        private Dictionary<Point, Color> colorsDictionary;
        private Dictionary<Point, string> colorsHexDictionary;
        private Dictionary<string, string> videoPage1Values;
        private Dictionary<string, string> videoPage2Values;
        private Dictionary<string, string> videoPage3Values;
        private Dictionary<string, string> videoPage4Values;
        private bool isTextMode;
        private int pointsDone;
        private RichTextBox selectedPage;
        #endregion

        #region Constructors
        public ResultForm()
        {
            Points = new List<Point>();
            ColorsDictionary = new Dictionary<Point, Color>();
            videoPage1Values = new Dictionary<string, string>();
            VideoPage2Values = new Dictionary<string, string>();
            VideoPage3Values = new Dictionary<string, string>();
            VideoPage4Values = new Dictionary<string, string>();
            ColorsHexDictionary = new Dictionary<Point, string>();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Maximized;
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
        public Dictionary<Point, Color> ColorsDictionary { get => colorsDictionary; set => colorsDictionary = value; }
        public Dictionary<Point, string> ColorsHexDictionary { get => colorsHexDictionary; set => colorsHexDictionary = value; }
        public bool IsTextMode { get => isTextMode; set => isTextMode = value; }
        public RichTextBox Tb_General { get => tb_General; set => tb_General = value; }
        public RichTextBox Tb_General1 { get => tb_General1; set => tb_General1 = value; }
        public RichTextBox Tb_General2 { get => tb_General2; set => tb_General2 = value; }
        public RichTextBox Tb_General3 { get => tb_General3; set => tb_General3 = value; }
        public Cursor Position
        {
            get
            {
                return tb_General.Cursor;
            }
            set
            {
                tb_General.Cursor = value;
            }
        }
        public bool EscPressed { get; set; }
        public RichTextBox SelectedPage { get => selectedPage; set => selectedPage = value; }
        public Dictionary<string, string> VideoPage1Values { get => videoPage1Values; set => videoPage1Values = value; }
        public Dictionary<string, string> VideoPage2Values { get => videoPage2Values; set => videoPage2Values = value; }
        public Dictionary<string, string> VideoPage3Values { get => videoPage3Values; set => videoPage3Values = value; }
        public Dictionary<string, string> VideoPage4Values { get => videoPage4Values; set => videoPage4Values = value; }
        #endregion

        #region EventHandlers
        //exit Form
        private void ResultForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                EscPressed = true;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            //Brush brush = new SolidBrush(Color);
            // SystemBrushes.ControlLightLight
            Color color = Color.White;
            foreach (Point p in Points)
            {
                ColorsDictionary.TryGetValue(p, out color);
                Brush brush = new SolidBrush(color);
                e.Graphics.FillRectangle(brush,
                (p.X * RatioX),(p.Y * RatioY),
                RatioX,RatioY);
            } 
        }
        #endregion
    }
}
