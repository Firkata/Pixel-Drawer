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
        #region Fields
        public int buttonCheckedIndex;
        public static Rectangle resolution = Screen.PrimaryScreen.Bounds;
        public int screenHeight = resolution.Height;
        public int screenWidth = resolution.Width;
        public int newScreenHeight = 0;
        public int newScreenWidth = 0;
        public float ratioX;
        public float ratioY;
        public int cursorRow;
        public int cursorCol;
        public bool isModeSet = false;
        public bool isTextMode = true;
        public ResultForm resultForm;
        #endregion

        public UserForm()
        {
            InitializeComponent();
            resultForm = new ResultForm();
            this.KeyPreview = true;
            this.BackColor = Color.LightSteelBlue;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += UserForm_KeyDown;
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
                    PositionCursor();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    InsertStyledText();
                    break;
                case 7:
                    break;
                case 8:
                    ChangeScreenColor(tb_BL.Text);
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

        public void ToggleTextButtons(bool isActive)
        {
            radioButton2.Enabled = isActive;
            radioButton3.Enabled = isActive;
            radioButton4.Enabled = isActive;
            radioButton5.Enabled = isActive;
            radioButton6.Enabled = isActive;
            radioButton7.Enabled = isActive;
        }
        
        #region Tasks

        //Режим на изображението
        private void SelectedMode(string AL)
        {
            try
            {
                switch (Convert.ToInt32(AL))
                {
                    case 0:
                        RenderFormResolution(45, 25);
                        ToggleTextButtons(true);
                        isTextMode = true;
                        break;
                    case 1:
                        RenderFormResolution(45, 25);
                        ToggleTextButtons(true);
                        isTextMode = true;
                        break;
                    case 2:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isTextMode = true;
                        break;
                    case 3:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isTextMode = true;
                        break;
                    case 4:
                        RenderFormResolution(320, 200);
                        ToggleTextButtons(false);
                        isTextMode = false;
                        break;
                    case 5:
                        RenderFormResolution(320, 200);
                        ToggleTextButtons(false);
                        isTextMode = false;
                        break;
                    case 6:
                        RenderFormResolution(640, 200);
                        ToggleTextButtons(false);
                        isTextMode = false;
                        break;
                    case 7:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isTextMode = true;
                        break;
                    default:
                        break;
                }
                resultForm.IsTextMode = isTextMode;
                if (resultForm.Tb_General != null)
                {
                    resultForm.Controls.Remove(resultForm.Tb_General);
                    resultForm.Tb_General = null;
                }
                if (isTextMode)
                {
                    if  (resultForm.Tb_General == null)
                    {
                        resultForm.Tb_General = new RichTextBox();
                        resultForm.Tb_General.Font = new Font(resultForm.Tb_General.Font.FontFamily, (float)(ratioX * 1.0546875));
                        resultForm.Tb_General.ReadOnly = true;
                        resultForm.Tb_General.Dock = DockStyle.Fill;
                        resultForm.Controls.Add(resultForm.Tb_General);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невалидни данни");
            }
        }

        //Позициониране на курсора
        private void PositionCursor()
        {
            cursorRow = !string.IsNullOrEmpty(tb_DH.Text) ? int.Parse(tb_DH.Text) : 0;
            cursorCol = !string.IsNullOrEmpty(tb_DL.Text) ? int.Parse(tb_DL.Text) : 0;
            MessageBox.Show(string.Format(@"Курсора е на ред: {0} колона: {1}",cursorRow,cursorCol));
        }

        //Запис на символ и атрибут
        private void InsertStyledText()
        {
            if (!isTextMode)
            {
                MessageBox.Show("Смени на текстов режим");
                return;
            }

            char displayCharacter = (char)HexToDecimal(tb_AL.Text);
            int characterCount = HexToDecimal(string.Format(@"{0}{1}", tb_CH.Text, tb_CL.Text));
            int displayPage = HexToDecimal(tb_BH.Text);
            string generatedText = "";
            for (int i = 0; i < characterCount; i++)
            {
                generatedText += displayCharacter;
            }

            // TODO: Implement calculation of cursor position
            //cursorRow -= 1;
            var text = new StringBuilder();
            for (int i = 0; i < cursorRow; i++)
            {
                text.AppendLine();
            }

            string space = new string(' ', cursorCol);

            text.Append(space);
            text.Append(generatedText);

            resultForm.Tb_General.Text = "";
            resultForm.Tb_General.Text = resultForm.Text.Insert(0, text.ToString());
            resultForm.Tb_General.SelectionStart = cursorRow + cursorCol;
            resultForm.Tb_General.SelectionLength = 0;

            // TODO: Implement text stylization
            int styleInDecimal = HexToDecimal(tb_BL.Text);
            StringBuilder bytes = new StringBuilder();
            while (styleInDecimal/2>1)
            {
                if(styleInDecimal%2 == 0)
                {
                    bytes.Append("0");
                }
                else
                {
                    bytes.Append("1");
                }
            }

            // TODO: Implement display pages; Check if display page is valid
            resultForm.Show();
        }

        //Смяна на палитрата
        private void ChangeScreenColor(string colorHex)
        {
            try
            {
                Color color = new Color();
                int colorNumber = HexToDecimal(colorHex);
                switch (colorNumber)
                {
                    case 0:
                        color = Color.Black;
                        break;
                    case 1:
                        color = Color.Red;
                        break;
                    case 2:
                        color = Color.Blue;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Yellow;
                        break;
                    case 5:
                        color = Color.Orange;
                        break;
                    case 6:
                        color = Color.Pink;
                        break;
                    case 7:
                        color = Color.Purple;
                        break;
                    case 8:
                        color = Color.Brown;
                        break;
                    case 9:
                        color = Color.White;
                        break;
                    case 10:
                        color = Color.MistyRose;
                        break;
                    case 11:
                        color = Color.Gray;
                        break;
                    case 12:
                        color = Color.Magenta;
                        break;
                    case 13:
                        color = Color.Tomato;
                        break;
                    case 14:
                        color = Color.Thistle;
                        break;
                    case 15:
                        color = Color.Turquoise;
                        break;
                    default:
                        MessageBox.Show("Невалидни данни");
                        return;
                }
                resultForm.BackColor = color;
                
                if (isTextMode)
                {
                    string input = "";
                    for(int i=0; i < 80; i++)
                    {
                        input += "A";
                    }
                    resultForm.Tb_General.Text = input;
                    resultForm.Tb_General.BackColor = color;
                    resultForm.Tb_General.BorderStyle = BorderStyle.None;   
                }
                resultForm.ShowDialog();
            }
            catch(Exception ex)
            {
                ex.ToString();
                MessageBox.Show("Невалидни данни");
                return;
            }
        }

        //Запис на точка
        private void DrawDot()
        {
            if (isTextMode)
            {
                MessageBox.Show("Смени на графичен режим");
                return;
            }
            int columns = HexToDecimal(string.Format(@"{0}{1}", tb_CH.Text, tb_CL.Text));
            int rows = HexToDecimal(tb_DL.Text);

            //points.Add(new Point(rows, columns));
            ////ResultForm resultForm = new ResultForm(rows, columns, ratioX, ratioY);
            //ResultForm resultForm = new ResultForm(points, ratioX, ratioY);
            //ResultForm.points;
            resultForm.Points.Add(new Point(columns, rows));
            resultForm.ShowDialog();
        }

        #endregion

        //Изчислява резолюцията на програмата спрямо монитора разделена на зададения режим
        private void RenderFormResolution(int x, int y)
        {
            newScreenWidth = x;
            ratioX = (float)resolution.Width / x;
            newScreenHeight = y;
            ratioY = (float)resolution.Height / y;
            resultForm.RatioX = ratioX;
            resultForm.RatioY = ratioY;
            MessageBox.Show(string.Format(@"режимът е настроен на {0}х{1}",x,y));
        }

        #region Conversions

        private int HexToDecimal(string hexInput)
        {
            try
            {
                int result = int.Parse(hexInput, System.Globalization.NumberStyles.HexNumber);
                return result;
            }
            catch
            {
                MessageBox.Show("Невалидни данни");
            }

            return 0;
            
        }
        #endregion

        #region EventHandlers

        //При натискане на Submit бутона
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (buttonCheckedIndex == 1)
                isModeSet = true;

            if (!isModeSet)
            {
                MessageBox.Show("Не е зададен режим на работа");
                return;
            }
            SelectedTask(buttonCheckedIndex);
        }

        //При натискане на клавиш от клавиатурата
        private void UserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(sender, e);
            }
        }

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

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = "00";
            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.Text = "00";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = "00";
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = cursorRow.ToString();
            tb_DH.ReadOnly = false;
            tb_DH.BackColor = Color.White;

            tb_DL.Text = cursorCol.ToString();
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = "00";
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("03H." +
                Environment.NewLine +
                "В BH се задава номера на видеостраницата." +
                "В DH и DL се получава реда и колоната на курсора за указаната страница." +
                "В CH и CL се получава информация за вида на курсора.");
        }

        //Четене на символ и атрибут
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 5;
            tb_AH.Text = "08";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = "00";
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = "45";
            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.Text = "00";
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = "00";
            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.Text = "00";
            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.Text = "09";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = "00";
            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = "00";
            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.Text = "00";
            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.Text = "00";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = "00";
            tb_BH.ReadOnly = false;
            tb_BH.BackColor = Color.White;

            tb_BL.Text = "00";
            tb_BL.ReadOnly = false;
            tb_BL.BackColor = Color.White;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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

            tb_AL.Text = "00";
            tb_AL.ReadOnly = false;
            tb_AL.BackColor = Color.White;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = "00";
            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.Text = "00";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = "00";
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = "00";
            tb_CH.ReadOnly = false;
            tb_CH.BackColor = Color.White;

            tb_CL.Text = "00";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = "00";
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

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

            tb_BL.Text = string.Empty;
            tb_BL.ReadOnly = true;
            tb_BL.BackColor = Color.LightSlateGray;

            tb_CH.Text = string.Empty;
            tb_CH.ReadOnly = true;
            tb_CH.BackColor = Color.LightSlateGray;

            tb_CL.Text = string.Empty;
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
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
