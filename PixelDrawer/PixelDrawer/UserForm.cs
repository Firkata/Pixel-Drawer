using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PixelDrawer
{
    public partial class UserForm : Form
    {
        public int buttonCheckedIndex;
        public static Rectangle resolution = Screen.PrimaryScreen.Bounds;
        public int screenHeight = resolution.Height;
        public int screenWidth = resolution.Width;
        public int newScreenHeight = 0;
        public int newScreenWidth = 0;
        public float ratioX;
        public float ratioY;

        public UserForm()
        {
            InitializeComponent();
            this.BackColor = Color.LightSteelBlue;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            SelectedTask(buttonCheckedIndex);
        }
        
        //Показва кой радиобутон е цъкнат
        private void SelectedTask(int buttonCheckIndex)
        {
            switch (buttonCheckIndex)
            {
                case 1:
                    SelectedMode(tb_AL.Text);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    DrawDot();
                    break;
                case 10:
                    break;
                case 11:
                    break;
            }
        }
        
        #region SelectedTasks

        //Режим на изображението
        private void SelectedMode(string AL)
        {
            switch (Convert.ToInt32(AL))
            {
                case 0:
                    RenderFormResolution(45, 25);
                    break;
                case 1:
                    RenderFormResolution(45, 25);
                    break;
                case 2:
                    RenderFormResolution(80, 25);
                    break;
                case 3:
                    RenderFormResolution(80, 25);
                    break;
                case 4:
                    RenderFormResolution(320, 200);
                    break;
                case 5:
                    RenderFormResolution(320, 200);
                    break;
                case 6:
                    RenderFormResolution(640, 200);
                    break;
                case 7:
                    RenderFormResolution(80, 25);
                    break;
                default:
                    break;
            }
        }

        //Запис на точка
        private void DrawDot()
        {
            int columns = HexToDecimal(string.Format(@"{0}{1}", tb_CL.Text, tb_CH.Text));
            int rows = HexToDecimal(tb_DL.Text);
            OpenResultForm(rows, columns, ratioX, ratioY);
        }
        #endregion

        //Изчислява резолюцията на програмата спрямо монитора разделена на зададения режим
        private void RenderFormResolution(int x, int y)
        {
            newScreenWidth = x;
            ratioX = (float)resolution.Width / x;
            newScreenHeight = y;
            ratioY = (float)resolution.Height / y;
            MessageBox.Show(string.Format(@"режимът е настроен на {0}х{1}",x,y));
        }

        //Отваря формата за рисуване
        public void OpenResultForm(int rowPosition, int columnPosition, float ratioX, float ratioY)
        {
            ResultForm resultForm = new ResultForm(rowPosition, columnPosition, ratioX, ratioY);
            resultForm.ShowDialog();
        }

        #region Conversions

        private int HexToDecimal(string hexInput)
        {
            return int.Parse(hexInput, System.Globalization.NumberStyles.HexNumber);
        }
        #endregion

        #region EventHandlers
        //Режим на изображението
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 1;
            tb_AH.Text = "00";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.Text = "00";
            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text =
                string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}",
                "Режимът се задава в AL.",
                Environment.NewLine,
                "режим".PadRight(14) + "тип".PadRight(14) + "цветове".PadRight(14) + "размер",
                Environment.NewLine,
                "".PadRight(4) + "0".PadRight(17) + "т".PadRight(20) + "2".PadRight(15) + "40x25",
                Environment.NewLine,
                "".PadRight(4) + "1".PadRight(17) + "т".PadRight(19) + "16".PadRight(15) + "40x25",
                Environment.NewLine,
                "".PadRight(4) + "2".PadRight(17) + "т".PadRight(20) + "2".PadRight(15) + "80x25",
                Environment.NewLine,
                "".PadRight(4) + "3".PadRight(17) + "т".PadRight(19) + "16".PadRight(15) + "80x25",
                Environment.NewLine,
                "".PadRight(4) + "4".PadRight(16) + "гр".PadRight(20) + "4".PadRight(13) + "320x200",
                Environment.NewLine,
                "".PadRight(4) + "5".PadRight(16) + "гр".PadRight(20) + "4".PadRight(13) + "320x200",
                Environment.NewLine,
                "".PadRight(4) + "6".PadRight(16) + "гр".PadRight(20) + "2".PadRight(13) + "640x200",
                Environment.NewLine,
                "".PadRight(4) + "7".PadRight(17) + "т".PadRight(20) + "2".PadRight(15) + "80x25");
        }

        //Курсор
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 2;
            tb_AH.Text = "01";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.Text = "";
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = "";
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = "";
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("01H." +
                Environment.NewLine +
                "Задава вида на курсора в текстовите режими." +
                Environment.NewLine +
                "Редовете са с номерирани отгоре надолу от 0 до 7 за цветен графичен адаптер и от 0 до 13 за монохроматичен адаптер." +
                Environment.NewLine +
                "Курсора се задава чрез начален (CH) и краен (CL) ред." +
                Environment.NewLine +
                "Ако  бит 5 на CH е 1 се получава невидим курсор.");
        }

        //Позициониране на курсора
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 3;
            tb_AH.Text = "02";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = false;
            tb_DH.BackColor = Color.White;

            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;

            lbl_Help.Text = string.Format("02H." +
                Environment.NewLine +
                "Новата позиция се задава във формат ред (DH) и колона (DL) за видеостраницата (BH).");
        }

        //Информация за курсора
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 4;
            tb_AH.Text = "03";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = false;
            tb_DH.BackColor = Color.White;

            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;

            lbl_Help.Text = string.Format("03H." +
                Environment.NewLine +
                "Новата позиция се задава във формат ред (DH) и колона (DL) за видеостраницата (BH).");
        }

        //Четене на символ и атрибут
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 5;
            tb_AH.Text = "08";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("08H." +
                Environment.NewLine +
                "В текстов режим кода на символа се получава в AL, а байта с атрибути в AH. В BH се задава номера на видеостраницата.");
        }

        //Запис на символ и атрибут
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 6;
            tb_AH.Text = "09";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("09H." +
                Environment.NewLine +
                "Кода на символа се задава в AL. Символа се извежда толкова пъти, колкото е указано в СХ." +
                " В ВН се задава номера на видеостраницата. Атрибутите за цвят се задават в BL.");
        }

        //Запис на символ
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 7;
            tb_AH.Text = "0A";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("0АH." +
                Environment.NewLine +
                "Отличава се от 09Н по това, че записва само кода на символа без да променя атрибутите" +
                "за цвят в съответната позиция.");
        }

        //Смяна палитра
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 8;
            tb_AH.Text = "0B";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("0BH." +
                Environment.NewLine +
                "1. BH=0" +
                Environment.NewLine +
                "В текстов режим BL задава цвета на екрана - от 0 до 15." +
                Environment.NewLine +
                "В графичен режим 320х200 BL задава цвета на фона." +
                Environment.NewLine +
                "В графичен режим 640х200 BL задава цвета на изображението на целия екран - от 0 до 15." +
                Environment.NewLine +
                "2. BH=1" +
                Environment.NewLine +
                "В BL се задава номера ( 0 или 1 ) на палитрата, която ще се използва в графичен режим 320х200.");
        }

        //Запис Точка
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 9;
            tb_AH.Text = "0C";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;

            lbl_Help.Text = string.Format("0CH." +
                Environment.NewLine +
                "Важи само за графичен режим." +
                Environment.NewLine +
                "Координатите на точката се задават във формат ред и колона:" +
                Environment.NewLine +
                "DL - номер на реда" +
                Environment.NewLine +
                "CX - номер на колоната" +
                Environment.NewLine +
                "AL - цвят на точката" +
                Environment.NewLine +
                "Ако бит 7 е 1, с битовете на цвят в AL  и текущите битове в паметта се изпълнява XOR.");
        }

        //Четене точка
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 10;
            tb_AH.Text = "0D";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;

            lbl_Help.Text = string.Format("0DH." +
                Environment.NewLine +
                "Координатите се задават в DL - номер на ред, а в CX - номер на колона." +
                Environment.NewLine +
                "В AL се получава цвета на точката.");
        }

        //Информация
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 11;
            tb_AH.Text = "0F";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("0FH." +
                Environment.NewLine +
                "Връща следната информация:" +
                Environment.NewLine +
                "AL - текущия режим на изображението (от 0 до 7)" +
                Environment.NewLine +
                "AH - широчината на екрана, представена в колони (40 или 80)" +
                Environment.NewLine +
                "BH - активната видеостраница (0 в графичен режим)");
        }
        #endregion
    }
}
