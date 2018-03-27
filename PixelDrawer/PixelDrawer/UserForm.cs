using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
        public int cursorRow1;
        public int cursorCol1;
        public int cursorRow2;
        public int cursorCol2;
        public int cursorRow3;
        public int cursorCol3;
        public int videoPageNum = 0;
        public int selectedPageNum = 0;
        public bool isModeSet = false;
        public bool isTextMode = true;
        public bool isBlackWhite = true;
        public ResultForm resultForm;
        public bool isShowCursorCall = false;
        public List<Dictionary<string, dynamic>> selections;
        public List<Dictionary<string, dynamic>> selections1;
        public List<Dictionary<string, dynamic>> selections2;
        public List<Dictionary<string, dynamic>> selections3;
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
                    //Курсор
                    break;
                case 3:
                    PositionCursor();
                    break;
                case 4:
                    GetCaretPosition();
                    break;
                case 5:
                    SelectedPage();
                    break;
                case 6:
                    MoveUp();
                    break;
                case 7:
                    break;
                case 8:
                    ReadStyledText();
                    break;
                case 9:
                    InsertStyledText();
                    break;
                case 10:
                    //Запис на символ
                    break;
                case 11:
                    ChangeScreenColor(tb_BL.Text);
                    break;
                case 12:
                    DrawDot();
                    break;
                case 13:
                    ReadDot();
                    break;
                case 14:
                    break;
            }
        }

        public void ToggleTextButtons(bool isActive)
        {
            radioButton3.Enabled = isActive;
            radioButton4.Enabled = isActive;
            radioButton5.Enabled = isActive;
            radioButton8.Enabled = isActive;
            radioButton9.Enabled = isActive;
            radioButton12.Enabled = !isActive;
            radioButton13.Enabled = !isActive;
        }

        #region Tasks

        //Режим на изображението
        private void SelectedMode(string AL)
        {
            resultForm.BackColor = Color.Black;
            resultForm.isModeReset = true;
            cursorCol = 0;
            cursorRow = 0;
            cursorCol1 = 0;
            cursorRow1 = 0;
            cursorCol2 = 0;
            cursorRow2 = 0;
            cursorCol3 = 0;
            cursorRow3 = 0;
            
            try
            {
                switch (Convert.ToInt32(AL))
                {
                    case 0:
                        RenderFormResolution(45, 25);
                        ToggleTextButtons(true);
                        isBlackWhite = true;
                        isTextMode = true;
                        resultForm.MaxRowLenght = 45;
                        resultForm.MaxRows = 25;
                        selections = new List<Dictionary<string, dynamic>>();
                        selections1 = new List<Dictionary<string, dynamic>>();
                        selections2 = new List<Dictionary<string, dynamic>>();
                        selections3 = new List<Dictionary<string, dynamic>>();
                        break;
                    case 1:
                        RenderFormResolution(45, 25);
                        ToggleTextButtons(true);
                        isBlackWhite = false;
                        isTextMode = true;
                        resultForm.MaxRowLenght = 45;
                        resultForm.MaxRows = 25;
                        selections = new List<Dictionary<string, dynamic>>();
                        selections1 = new List<Dictionary<string, dynamic>>();
                        selections2 = new List<Dictionary<string, dynamic>>();
                        selections3 = new List<Dictionary<string, dynamic>>();
                        break;
                    case 2:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isBlackWhite = true;
                        isTextMode = true;
                        resultForm.MaxRowLenght = 80;
                        resultForm.MaxRows = 25;
                        selections = new List<Dictionary<string, dynamic>>();
                        selections1 = new List<Dictionary<string, dynamic>>();
                        selections2 = new List<Dictionary<string, dynamic>>();
                        selections3 = new List<Dictionary<string, dynamic>>();
                        break;
                    case 3:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isBlackWhite = false;
                        isTextMode = true;
                        resultForm.MaxRowLenght = 80;
                        resultForm.MaxRows = 25;
                        selections = new List<Dictionary<string, dynamic>>();
                        selections1 = new List<Dictionary<string, dynamic>>();
                        selections2 = new List<Dictionary<string, dynamic>>();
                        selections3 = new List<Dictionary<string, dynamic>>();
                        break;
                    case 4:
                        RenderFormResolution(320, 200);
                        ToggleTextButtons(false);
                        isBlackWhite = false;
                        isTextMode = false;
                        break;
                    case 5:
                        RenderFormResolution(320, 200);
                        ToggleTextButtons(false);
                        isBlackWhite = false;
                        isTextMode = false;
                        break;
                    case 6:
                        RenderFormResolution(640, 200);
                        ToggleTextButtons(false);
                        isBlackWhite = false;
                        isTextMode = false;
                        break;
                    case 7:
                        RenderFormResolution(80, 25);
                        ToggleTextButtons(true);
                        isBlackWhite = false;
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
                    resultForm.Controls.Remove(resultForm.Tb_General1);
                    resultForm.Tb_General1 = null;
                    resultForm.Controls.Remove(resultForm.Tb_General2);
                    resultForm.Tb_General2 = null;
                    resultForm.Controls.Remove(resultForm.Tb_General3);
                    resultForm.Tb_General3 = null;
                }
                if (isTextMode)
                {
                    if (resultForm.Tb_General == null)
                    {
                        int height = resolution.Height - 15;
                        int width = resolution.Width - 15;

                        resultForm.Tb_General = new RichTextBox();
                        resultForm.Tb_General.Font = new Font(resultForm.Tb_General.Font.FontFamily, (float)(ratioX * 0.64444));
                        resultForm.Tb_General.ReadOnly = true;
                        resultForm.Tb_General.MaximumSize = new System.Drawing.Size(width, height);
                        resultForm.Tb_General.Size = new System.Drawing.Size(width, height);
                        resultForm.Tb_General.Dock = DockStyle.Bottom;
                        resultForm.Controls.Add(resultForm.Tb_General);
                        resultForm.Tb_General.ForeColor = Color.White;
                        resultForm.Tb_General.BackColor = Color.Black;

                        resultForm.Tb_General1 = new RichTextBox();
                        resultForm.Tb_General1.Font = new Font(resultForm.Tb_General1.Font.FontFamily, (float)(ratioX * 1.0546875));
                        resultForm.Tb_General1.ReadOnly = true;
                        resultForm.Tb_General1.MaximumSize = new System.Drawing.Size(width, height);
                        resultForm.Tb_General1.Size = new System.Drawing.Size(width, height);
                        resultForm.Tb_General1.Dock = DockStyle.Bottom;
                        resultForm.Controls.Add(resultForm.Tb_General1);
                        resultForm.Tb_General1.ForeColor = Color.White;
                        resultForm.Tb_General1.BackColor = Color.Black;

                        resultForm.Tb_General2 = new RichTextBox();
                        resultForm.Tb_General2.Font = new Font(resultForm.Tb_General2.Font.FontFamily, (float)(ratioX * 1.0546875));
                        resultForm.Tb_General2.ReadOnly = true;
                        resultForm.Tb_General2.MaximumSize = new System.Drawing.Size(width, height);
                        resultForm.Tb_General2.Size = new System.Drawing.Size(width, height);
                        resultForm.Tb_General2.Dock = DockStyle.Bottom;
                        resultForm.Controls.Add(resultForm.Tb_General2);
                        resultForm.Tb_General2.ForeColor = Color.White;
                        resultForm.Tb_General2.BackColor = Color.Black;

                        resultForm.Tb_General3 = new RichTextBox();
                        resultForm.Tb_General3.Font = new Font(resultForm.Tb_General3.Font.FontFamily, (float)(ratioX * 1.0546875));
                        resultForm.Tb_General3.ReadOnly = true;
                        resultForm.Tb_General3.MaximumSize = new System.Drawing.Size(width, height);
                        resultForm.Tb_General3.Size = new System.Drawing.Size(width, height);
                        resultForm.Tb_General3.Dock = DockStyle.Bottom;
                        resultForm.Controls.Add(resultForm.Tb_General3);
                        resultForm.Tb_General3.ForeColor = Color.White;
                        resultForm.Tb_General3.BackColor = Color.Black;
                    }
                }
                else
                {
                    resultForm.BackColor = Color.Black;
                }
            }
            catch
            {
                MessageBox.Show("Невалидна режим! Изберете от опциите в описанието.");
                tb_AL.Text = "00";
            }

            isShowCursorCall = true;
            InsertStyledText();
            isShowCursorCall = false;
        }

        //Позициониране на курсора
        private void PositionCursor()
        {
            videoPageNum = 0;
            if(!string.IsNullOrEmpty(tb_BH.Text))
            {
                if (!int.TryParse(tb_BH.Text, out videoPageNum))
                {
                    MessageBox.Show("Изберете валидна видеостраница от 0 до 3");
                    tb_BH.Text = "00";
                    return;
                }
            }

            switch (videoPageNum)
            {
                case 0:
                    cursorRow = HexToDecimal(tb_DH.Text);
                    cursorCol = HexToDecimal(tb_DL.Text);
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", videoPageNum, Environment.NewLine, cursorRow, cursorCol));
                    break;
                case 1:
                    cursorRow1 = HexToDecimal(tb_DH.Text);
                    cursorCol1 = HexToDecimal(tb_DL.Text);
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", videoPageNum, Environment.NewLine, cursorRow1, cursorCol1));
                    break;
                case 2:
                    cursorRow2 = HexToDecimal(tb_DH.Text);
                    cursorCol2 = HexToDecimal(tb_DL.Text);
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", videoPageNum, Environment.NewLine, cursorRow2, cursorCol2));
                    break;
                case 3:
                    cursorRow3 = HexToDecimal(tb_DH.Text);
                    cursorCol3 = HexToDecimal(tb_DL.Text);
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", videoPageNum, Environment.NewLine, cursorRow3, cursorCol3));
                    break;
                default:
                    break;
            }
            isShowCursorCall = true;
            InsertStyledText();
            isShowCursorCall = false;
        }

        //Информация за курсора
        private void GetCaretPosition()
        {
            int desiredVideoPage = 0;
            if(!int.TryParse(tb_BH.Text, out desiredVideoPage))
            {
                MessageBox.Show("Изберете валидна видеостраница от 0 до 3");
                return;
            }

            switch (desiredVideoPage)
            {
                case 0:
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", desiredVideoPage, Environment.NewLine, cursorRow, cursorCol));
                    break;
                case 1:
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", desiredVideoPage, Environment.NewLine, cursorRow1, cursorCol1));
                    break;
                case 2:
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", desiredVideoPage, Environment.NewLine, cursorRow2, cursorCol2));
                    break;
                case 3:
                    MessageBox.Show(string.Format(@"Видеостраница: {0}{1}Курсора е на ред: {2} колона: {3}", desiredVideoPage, Environment.NewLine, cursorRow3, cursorCol3));
                    break;
                default:
                    MessageBox.Show("Изберете валидна видеостраница от 0 до 3");
                    break;
            }
        }

        //Задаване активна страница
        private void SelectedPage()
        {
            int.TryParse(tb_AL.Text, out videoPageNum);
            switch (videoPageNum)
            {
                case 0:
                    resultForm.SelectedPage = resultForm.Tb_General;
                    selectedPageNum = 0;
                    MessageBox.Show(string.Format(@"Избрана е страница {0}", videoPageNum));
                    break;
                case 1:
                    resultForm.SelectedPage = resultForm.Tb_General1;
                    selectedPageNum = 1;
                    MessageBox.Show(string.Format(@"Избрана е страница {0}", videoPageNum));
                    break;
                case 2:
                    resultForm.SelectedPage = resultForm.Tb_General2;
                    selectedPageNum = 2;
                    MessageBox.Show(string.Format(@"Избрана е страница {0}", videoPageNum));
                    break;
                case 3:
                    resultForm.SelectedPage = resultForm.Tb_General3;
                    selectedPageNum = 3;
                    MessageBox.Show(string.Format(@"Избрана е страница {0}", videoPageNum));
                    break;
                default:
                    MessageBox.Show("Избери страница от 0 до 3");
                    break;
            }
        }

        //Преместване нагоре
        private void MoveUp()
        {
            int moveUpnum = HexToDecimal(tb_AL.Text);
            RichTextBox[] boxes = new RichTextBox[] { resultForm.Tb_General, resultForm.Tb_General1, resultForm.Tb_General2, resultForm.Tb_General3 };

            for (int i = 0; i < boxes[videoPageNum].Lines.Length; i++)
            {
                boxes[videoPageNum].SelectionStart = 3;
                boxes[videoPageNum].SelectionLength = 3;
            }

            resultForm.Show();
        }

        //Запис на символ и атрибут
        private void InsertStyledText()
        {
            if (!isTextMode)
            {
                MessageBox.Show("Смени на текстов режим");
                return;
            }

            if (resultForm.BlinkThread != null)
            {
                resultForm.BlinkThread.Abort();
                resultForm.BlinkThread = null;
            }
            RichTextBox[] boxes = new RichTextBox[] { resultForm.Tb_General, resultForm.Tb_General1, resultForm.Tb_General2, resultForm.Tb_General3 };
            resultForm.Tb_General.Hide();
            resultForm.Tb_General1.Hide();
            resultForm.Tb_General2.Hide();
            resultForm.Tb_General3.Hide();
            char displayCharacter = (char)HexToDecimal(tb_AL.Text);
            int characterCount = HexToDecimal(string.Format(@"{0}{1}", tb_CH.Text, tb_CL.Text));
            int displayPage = HexToDecimal(tb_BH.Text);
            if (displayPage < 0 || displayPage > 3)
            {
                MessageBox.Show("Изберете страница от 0 до 3");
                return;
            }
            string currentText = boxes[displayPage].Text;
            string generatedText = "";
            for (int i = 0; i < characterCount; i++)
            {
                generatedText += displayCharacter;
            }

            //cursorRow -= 1;
            string space = string.Empty;
            int selectionStart = 0;
            string dictValue = string.Empty;
            int currentPageCursorRow = 0;
            int currentPageCursorCol = 0;
            List<List<Dictionary<string, dynamic>>> allSelectionLists = new List<List<Dictionary<string, dynamic>>> {
                selections, selections1, selections2, selections3
            };

            if (tb_AL.Text.Length < 2)
            {
                tb_AL.Text = "0" + tb_AL.Text;
            }

            if (tb_BL.Text.Length < 2)
            {
                tb_BL.Text = "0" + tb_BL.Text;
            }

            if (tb_CH.Text.Length < 2)
            {
                tb_CH.Text = "0" + tb_CH.Text;
            }

            if (tb_CL.Text.Length < 2)
            {
                tb_CL.Text = "0" + tb_CL.Text;
            }

            switch (displayPage)
            {
                case 0:
                    selectionStart = cursorRow + cursorCol;
                    currentPageCursorCol = cursorCol;
                    currentPageCursorRow = cursorRow;

                    break;
                case 1:
                    selectionStart = cursorRow1 + cursorCol1;
                    currentPageCursorCol = cursorCol1;
                    currentPageCursorRow = cursorRow1;
                    
                    break;
                case 2:
                    selectionStart = cursorRow2 + cursorCol2;
                    currentPageCursorCol = cursorCol2;
                    currentPageCursorRow = cursorRow2;
                    
                    break;
                case 3:
                    selectionStart = cursorRow3 + cursorCol3;
                    currentPageCursorCol = cursorCol3;
                    currentPageCursorRow = cursorRow3;
                    
                    break;
                default:
                    break;
            }


            int position = currentPageCursorRow * resultForm.MaxRowLenght + currentPageCursorCol;

            var newText = new StringBuilder(Regex.Replace(currentText, @"\n|\r", String.Empty));
            if (position > newText.Length)
            {
                newText.Append(new String(' ', position - newText.Length));
            }

            try
            {
                newText.Remove(position, generatedText.Length);
            }
            catch (ArgumentOutOfRangeException)
            {
                newText.Remove(position, newText.Length - position);
            }

            newText.Insert(position, generatedText);

            var resultText = new StringBuilder();
            for (int i = 0; i <= newText.Length / resultForm.MaxRowLenght; i++)
            {
                try
                {
                    resultText.Append(newText.ToString().Substring(i * resultForm.MaxRowLenght, resultForm.MaxRowLenght) + Environment.NewLine);
                }
                catch (ArgumentOutOfRangeException)
                {
                    resultText.Append(newText.ToString().Substring(i * resultForm.MaxRowLenght, newText.Length % resultForm.MaxRowLenght));
                }
            }



            boxes[displayPage].Text = "";
            boxes[displayPage].Text = resultForm.Text.Insert(0, resultText.ToString());
            boxes[displayPage].SelectionStart = selectionStart;
            boxes[displayPage].SelectionLength = 0;

            int styleInDecimal = HexToDecimal(tb_BL.Text);
            string byteRepr = "";
            int remainder;


            while (styleInDecimal > 0)
            {
                remainder = styleInDecimal % 2;
                styleInDecimal /= 2;
                byteRepr = string.Format(@"{0}{1}", remainder, byteRepr);
            }
            int remainingBits = 8 - byteRepr.Length;
            byteRepr = new string('0', remainingBits) + byteRepr;

            Color textBackColor = Color.Black;
            Color textColor = Color.White;

            int backColorRed = 0;
            int backColorGreen = 0;
            int backColorBlue = 0;
            int fontColorRed = 255;
            int fontColorGreen = 255;
            int fontColorBlue = 255;

            if (!isBlackWhite)
            {
                backColorRed = byteRepr[1] == '1' ? 255 : 0;
                backColorGreen = byteRepr[2] == '1' ? 255 : 0;
                backColorBlue = byteRepr[3] == '1' ? 255 : 0;

                fontColorRed = byteRepr[5] == '1' ? 255 : 0;
                fontColorGreen = byteRepr[6] == '1' ? 255 : 0;
                fontColorBlue = byteRepr[7] == '1' ? 255 : 0;
            }

            resultForm.SelectedPage = boxes[selectedPageNum];//страница за гледанe  

            CheckForIllegalCrossThreadCalls = false;
            //TODO: Implement logic for changing selection data in selection lists dynamically if text is overwritten
            
            int currentStart = position;
            int currentEnd = position + generatedText.Length;

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, allSelectionLists[displayPage]);
            stream.Position = 0;
            List<Dictionary<string, dynamic>> selectionsCopy = (List<Dictionary<string, dynamic>>)formatter.Deserialize(stream);

            List<Dictionary<string, dynamic>> toAdd = new List<Dictionary<string, dynamic>>();
            List<int> toRemove = new List<int>();
            if (!isShowCursorCall)
            {
                for (int i = 0; i < selectionsCopy.Count; i++)
                {
                    Dictionary<string, dynamic> selectionData = selectionsCopy[i];
                    selectionData.TryGetValue("selectionStart", out dynamic start);
                    selectionData.TryGetValue("selectionEnd", out dynamic end);

                    if(currentStart == start && currentEnd == end)
                    {
                        if (!toRemove.Contains(i))
                        {
                            toRemove.Add(i);
                        }
                    }else if (currentStart >= start && currentEnd <= end)
                    {
                        if (!toRemove.Contains(i))
                        {
                            toRemove.Add(i);
                        }

                        selectionData.TryGetValue("blinking", out dynamic blinking);
                        if (blinking == 1)
                        {
                            selectionData.TryGetValue("backgroundRed", out dynamic backRed);
                            selectionData.TryGetValue("backgroundGreen", out dynamic backGreen);
                            selectionData.TryGetValue("backgroundBlue", out dynamic backBlue);
                            selectionData.TryGetValue("fontColorRed", out dynamic fontRed);
                            selectionData.TryGetValue("fontColorGreen", out dynamic fontGreen);
                            selectionData.TryGetValue("fontColorBlue", out dynamic fontBlue);
                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", start },
                                { "selectionEnd", currentStart },
                                { "blinking", blinking },
                                { "backgroundRed", backRed },
                                { "backgroundGreen", backGreen },
                                { "backgroundBlue", backBlue },
                                { "fontColorRed", fontRed },
                                { "fontColorGreen", fontGreen },
                                { "fontColorBlue", fontBlue },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });

                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", currentEnd },
                                { "selectionEnd", end },
                                { "blinking", blinking },
                                { "backgroundRed", backRed },
                                { "backgroundGreen", backGreen },
                                { "backgroundBlue", backBlue },
                                { "fontColorRed", fontRed },
                                { "fontColorGreen", fontGreen },
                                { "fontColorBlue", fontBlue },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                        else
                        {
                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", start },
                                { "selectionEnd", currentStart },
                                { "blinking", blinking },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });

                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", currentEnd },
                                { "selectionEnd", end },
                                { "blinking", blinking },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                    }else if(currentStart >= start && currentStart <= end)
                    {
                        if (!toRemove.Contains(i))
                        {
                            toRemove.Add(i);
                        }
                        selectionData.TryGetValue("blinking", out dynamic blinking);

                        if (blinking == 1)
                        {
                            selectionData.TryGetValue("backgroundRed", out dynamic backRed);
                            selectionData.TryGetValue("backgroundGreen", out dynamic backGreen);
                            selectionData.TryGetValue("backgroundBlue", out dynamic backBlue);
                            selectionData.TryGetValue("fontColorRed", out dynamic fontRed);
                            selectionData.TryGetValue("fontColorGreen", out dynamic fontGreen);
                            selectionData.TryGetValue("fontColorBlue", out dynamic fontBlue);

                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", start },
                                { "selectionEnd", currentStart },
                                { "blinking", blinking },
                                { "backgroundRed", backRed },
                                { "backgroundGreen", backGreen },
                                { "backgroundBlue", backBlue },
                                { "fontColorRed", fontRed },
                                { "fontColorGreen", fontGreen },
                                { "fontColorBlue", fontBlue },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                        else
                        {
                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", start },
                                { "selectionEnd", currentStart },
                                { "blinking", blinking },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                    }else if(currentEnd <= end && currentEnd >= start)
                    {
                        if (!toRemove.Contains(i))
                        {
                            toRemove.Add(i);
                        }
                        selectionData.TryGetValue("blinking", out dynamic blinking);

                        if (blinking == 1)
                        {
                            selectionData.TryGetValue("backgroundRed", out dynamic backRed);
                            selectionData.TryGetValue("backgroundGreen", out dynamic backGreen);
                            selectionData.TryGetValue("backgroundBlue", out dynamic backBlue);
                            selectionData.TryGetValue("fontColorRed", out dynamic fontRed);
                            selectionData.TryGetValue("fontColorGreen", out dynamic fontGreen);
                            selectionData.TryGetValue("fontColorBlue", out dynamic fontBlue);

                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", currentEnd },
                                { "selectionEnd", end },
                                { "blinking", blinking },
                                { "backgroundRed", backRed },
                                { "backgroundGreen", backGreen },
                                { "backgroundBlue", backBlue },
                                { "fontColorRed", fontRed },
                                { "fontColorGreen", fontGreen },
                                { "fontColorBlue", fontBlue },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                        else
                        {
                            toAdd.Add(new Dictionary<string, dynamic>
                            {
                                { "selectionStart", currentEnd },
                                { "selectionEnd", end },
                                { "blinking", blinking },
                                { "attrAL", tb_AL.Text },
                                { "attrBL", tb_BL.Text },
                                { "attrCH", tb_CH.Text },
                                { "attrCL", tb_CL.Text }
                            });
                        }
                    }
                }
            }

            foreach(int indexToRemove in toRemove)
            {
                try
                {
                    allSelectionLists[displayPage].RemoveAt(indexToRemove);
                }
                catch (ArgumentOutOfRangeException)
                {
                    allSelectionLists[displayPage].RemoveAt(indexToRemove-1);
                }
                
            }

            foreach(Dictionary<string, dynamic> item in toAdd){
                allSelectionLists[displayPage].Add(item);
            }
            
            if (byteRepr[0] == '1')
            {
                allSelectionLists[displayPage].Add(new Dictionary<string, dynamic>{
                    {"selectionStart", position },
                    {"selectionEnd", position + generatedText.Length },
                    { "blinking", 1 },
                    { "backgroundRed", backColorRed },
                    { "backgroundGreen", backColorGreen },
                    { "backgroundBlue", backColorRed },
                    { "fontColorRed", fontColorRed },
                    { "fontColorGreen", fontColorGreen },
                    { "fontColorBlue", fontColorBlue },
                    { "attrAL", tb_AL.Text },
                    { "attrBL", tb_BL.Text },
                    { "attrCH", tb_CH.Text },
                    { "attrCL", tb_CL.Text }
                });
            }
            else if (!isShowCursorCall)
            {
                allSelectionLists[displayPage].Add(new Dictionary<string, dynamic>{
                    {"selectionStart", position },
                    {"selectionEnd", position + generatedText.Length },
                    { "blinking", 0 },
                    { "backgroundRed", backColorRed },
                    { "backgroundGreen", backColorGreen },
                    { "backgroundBlue", backColorRed },
                    { "fontColorRed", fontColorRed },
                    { "fontColorGreen", fontColorGreen },
                    { "fontColorBlue", fontColorBlue },
                    { "attrAL", tb_AL.Text },
                    { "attrBL", tb_BL.Text },
                    { "attrCH", tb_CH.Text },
                    { "attrCL", tb_CL.Text }
                });
            }

            foreach (Dictionary<string, dynamic> selectionData in allSelectionLists[displayPage])
            {
                selectionData.TryGetValue("selectionStart", out dynamic start);
                selectionData.TryGetValue("selectionEnd", out dynamic end);
                selectionData.TryGetValue("backgroundRed", out dynamic red);
                selectionData.TryGetValue("backgroundGreen", out dynamic green);
                selectionData.TryGetValue("backgroundBlue", out dynamic blue);

                boxes[displayPage].SelectionStart = start + start / resultForm.MaxRowLenght;
                boxes[displayPage].SelectionLength = end - start;
                boxes[displayPage].SelectionBackColor = Color.FromArgb(red, green, blue);
                boxes[displayPage].SelectionStart = start;
                boxes[displayPage].SelectionLength = 0;
            }

            bool blinkingSelectionExists = allSelectionLists[displayPage].Any(x => {
                dynamic blinking;
                x.TryGetValue("blinking", out blinking);
                return blinking == 1;
            });

            int actualPosition = position + new Regex(Regex.Escape(Environment.NewLine)).Matches(resultText.ToString()).Count;
            if (blinkingSelectionExists && resultForm.BlinkThread == null)
            {
                resultForm.BlinkThread = new Thread(() => Blink(resultForm, allSelectionLists[selectedPageNum], actualPosition, isShowCursorCall, boxes[displayPage]));
                resultForm.BlinkThread.Start();
            }

            if (isShowCursorCall)
            {
                boxes[displayPage].SelectionStart = actualPosition;
                resultForm.SelectedPage = boxes[displayPage];   
            }
            resultForm.SelectedPage.Select();
            resultForm.SelectedPage.Show();
            resultForm.Show();
        }
         
        public void Blink(ResultForm resultForm, List<Dictionary<string, dynamic>> selections, int position, bool showCursorCall, RichTextBox manipulationPage)
        {
            while (true)
            {
                foreach (Dictionary<string, dynamic> selectionData in selections)
                {
                    dynamic blinking = 0;
                    selectionData.TryGetValue("blinking", out blinking);

                    if (blinking == 1)
                    {
                        dynamic start = 0;
                        dynamic end = 0;

                        selectionData.TryGetValue("selectionStart", out start);
                        selectionData.TryGetValue("selectionEnd", out end);

                        selectionData.TryGetValue("fontColorRed", out dynamic red);
                        selectionData.TryGetValue("fontColorGreen", out dynamic green);
                        selectionData.TryGetValue("fontColorBlue", out dynamic blue);

                        Color fontColor = Color.FromArgb(red, green, blue);

                        resultForm.SelectedPage.SelectionStart = start + start / resultForm.MaxRowLenght;
                        resultForm.SelectedPage.SelectionLength = end - start;
                        bool colorsEqual = (resultForm.SelectedPage.SelectionColor.R == red
                           && resultForm.SelectedPage.SelectionColor.G == green
                           && resultForm.SelectedPage.SelectionColor.B == blue)
                           || resultForm.SelectedPage.SelectionColor == fontColor;

                        resultForm.SelectedPage.SelectionColor = colorsEqual ? resultForm.SelectedPage.BackColor : fontColor;
                        if (colorsEqual)
                        {
                            resultForm.SelectedPage.SelectionColor = resultForm.SelectedPage.BackColor;
                        }
                        else
                        {
                            resultForm.SelectedPage.SelectionColor = fontColor;
                        }
                    }
                    Dictionary<string, dynamic> latestSelection = selections.Last();
                    latestSelection.TryGetValue("selectionStart", out dynamic lastSelectionStart);
                    resultForm.SelectedPage.SelectionStart = showCursorCall ? position : lastSelectionStart;
                    resultForm.SelectedPage.SelectionLength = 0;
                }
                
                Thread.Sleep(500);
            } 
        }

        private void ReadStyledText()
        {
            int displayPage = HexToDecimal(tb_BH.Text);
            int requestedRow = HexToDecimal(tb_DH.Text);
            int requestedCol = HexToDecimal(tb_DL.Text);
            List<Dictionary<string, dynamic>> pageSelections;

            switch (displayPage)
            {
                case 0:
                    pageSelections = selections;
                    break;
                case 1:
                    pageSelections = selections1;
                    break;
                case 2:
                    pageSelections = selections2;
                    break;
                case 3:
                    pageSelections = selections3;
                    break;
                default:
                    pageSelections = new List<Dictionary<string, dynamic>>();
                    break;
            }

            int absolutePosition = requestedRow * resultForm.MaxRowLenght + requestedCol;
            foreach(Dictionary<string, dynamic> selectionData in pageSelections)
            {
                selectionData.TryGetValue("selectionStart", out dynamic start);
                selectionData.TryGetValue("selectionEnd", out dynamic end);

                if (absolutePosition >= start && absolutePosition <= end)
                {
                    selectionData.TryGetValue("attrAL", out dynamic ALText);
                    selectionData.TryGetValue("attrBL", out dynamic BLText);
                    selectionData.TryGetValue("attrCL", out dynamic CLText);
                    selectionData.TryGetValue("attrCH", out dynamic CHText);

                    tb_AL.Text = ALText;
                    tb_BL.Text = BLText;
                    tb_CL.Text = CLText;
                    tb_CH.Text = CHText;

                    break;
                }
            }
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

                RichTextBox[] boxes = new RichTextBox[] { resultForm.Tb_General, resultForm.Tb_General1, resultForm.Tb_General2, resultForm.Tb_General3 };

                if (resultForm.Tb_General != null)
                {
                    resultForm.Tb_General.Hide();

                }
                if (resultForm.Tb_General1 != null)
                {
                    resultForm.Tb_General1.Hide();

                }
                if (resultForm.Tb_General2 != null)
                {
                    resultForm.Tb_General2.Hide();

                }
                if (resultForm.Tb_General3 != null)
                {
                    resultForm.Tb_General3.Hide();

                }

                int displayPageNum = 0;
                int.TryParse(tb_BH.Text, out displayPageNum);

                resultForm.BackColor = color;
                if (resultForm.SelectedPage == null)
                {
                    resultForm.SelectedPage = resultForm.Tb_General;
                }

                

                if (isTextMode)
                {
                    resultForm.SelectedPage.Show();//текстбокс - винаги е черен
                    
                }

                resultForm.Show();
                
            }
            catch (Exception ex)
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

            int styleInDecimal = HexToDecimal(tb_AL.Text);
            string byteRepr = "";
            int remainder;

            while (styleInDecimal > 0)
            {
                remainder = styleInDecimal % 2;
                styleInDecimal /= 2;
                byteRepr = string.Format(@"{0}{1}", remainder, byteRepr);
            }
            int remainingBits = 8 - byteRepr.Length;
            byteRepr = new string('0', remainingBits) + byteRepr;

            int red = byteRepr[5] == '1' ? 255 : 0;
            int green = byteRepr[6] == '1' ? 255 : 0;
            int blue = byteRepr[7] == '1' ? 255 : 0;
            Color pixelColor = Color.FromArgb(red, green, blue);

            //resultForm.Color = pixelColor;
            Point point = new Point(columns, rows);
            if (!resultForm.Points.Contains(point))
            {
                resultForm.Points.Add(new Point(columns, rows));
                resultForm.ColorsDictionary.Add(new Point(columns, rows), pixelColor);
                resultForm.ColorsHexDictionary.Add(new Point(columns, rows), tb_AL.Text);
            }
            else
            {
                MessageBox.Show("Има пиксел на тази позиция");
            }
            resultForm.Show();
        }

        //Четене на точка
        private void ReadDot()
        {
            if (isTextMode)
            {
                MessageBox.Show("Смени на графичен режим");
                return;
            }

            int columns = HexToDecimal(string.Format(@"{0}{1}", tb_CH.Text, tb_CL.Text));
            int rows = HexToDecimal(tb_DL.Text);
            Point point = new Point(columns, rows);
            Color color = new Color();
            string colorInHex = string.Empty;

            if (resultForm.Points.Contains(point))
            {
                //resultForm.ColorsDictionary.TryGetValue(point, out color);
                resultForm.ColorsHexDictionary.TryGetValue(point, out colorInHex);
                tb_AL.Text = colorInHex;
                //MessageBox.Show(string.Format(@"Пиксел на позиция X:{0} Y:{1} е с цвят: [{2},{3},{4}]", point.X.ToString(), point.Y.ToString(), color.R, color.G, color.B));
            }
            else
            {
                MessageBox.Show("Няма начертан такъв пиксел");
            }
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
            MessageBox.Show(string.Format(@"режимът е настроен на {0}х{1}", x, y));
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
                if(!isShowCursorCall)
                MessageBox.Show("Стойността не е валидно HEX число.");
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
        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    buttonCheckedIndex = 2;
        //    tb_AH.Text = "01";
        //    tb_AH.ReadOnly = true;
        //    tb_AH.BackColor = Color.LightGray;

        //    tb_AL.Text = string.Empty;
        //    tb_AL.ReadOnly = true;
        //    tb_AL.BackColor = Color.LightSlateGray;

        //    tb_BH.Text = string.Empty;
        //    tb_BH.ReadOnly = true;
        //    tb_BH.BackColor = Color.LightSlateGray;

        //    tb_BL.Text = string.Empty;
        //    tb_BL.ReadOnly = true;
        //    tb_BL.BackColor = Color.LightSlateGray;

        //    tb_CH.Text = "00";
        //    tb_CH.ReadOnly = false;
        //    tb_CH.BackColor = Color.White;

        //    tb_CL.Text = "00";
        //    tb_CL.ReadOnly = false;
        //    tb_CL.BackColor = Color.White;

        //    tb_DH.Text = string.Empty;
        //    tb_DH.ReadOnly = true;
        //    tb_DH.BackColor = Color.LightSlateGray;

        //    tb_DL.Text = string.Empty;
        //    tb_DL.ReadOnly = true;
        //    tb_DL.BackColor = Color.LightSlateGray;

        //    lbl_Help.Text = string.Format("01H." +
        //        Environment.NewLine +
        //        "Задава вида на курсора в текстовите режими." +
        //        Environment.NewLine +
        //        "Редовете са с номерирани отгоре надолу от 0 до 7 за цветен графичен адаптер и от 0 до 13 за монохроматичен адаптер." +
        //        Environment.NewLine +
        //        "Курсора се задава чрез начален (CH) и краен (CL) ред." +
        //        Environment.NewLine +
        //        "Ако  бит 5 на CH е 1 се получава невидим курсор.");
        //}

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

            tb_DH.Text = "00";
            tb_DH.ReadOnly = false;
            tb_DH.BackColor = Color.White;

            tb_DL.Text = "00";
            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;

            lbl_Help.Text = string.Format("Новата позиция се задава във формат ред (DH) и колона (DL) за видеостраницата (BH).");
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

            lbl_Help.Text = string.Format(
                "В BH се задава номера на видеостраницата." +
                "В DH и DL се получава реда и колоната на курсора за указаната страница." +
                "В CH и CL се получава информация за вида на курсора.");
        }

        //Задаване активна страница
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 5;
            tb_AH.Text = "04";
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
            tb_CL.ReadOnly = true;
            tb_CL.BackColor = Color.LightSlateGray;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format("Има смисъл само за текстов режим.Номера на видеостраницата се задава в AL. В 40-колонните режими се задава стойност от 0 до 7, а в 80-колонните от 0 до 3");
        }

        //Преместване нагоре
        //private void radioButton6_CheckedChanged(object sender, EventArgs e)
        //{
        //    buttonCheckedIndex = 6;
        //    tb_AH.Text = "06";
        //    tb_AH.ReadOnly = true;
        //    tb_AH.BackColor = Color.LightGray;

        //    tb_AL.Text = "00";
        //    tb_AL.ReadOnly = false;
        //    tb_AL.BackColor = Color.White;

        //    tb_BH.Text = "00";
        //    tb_BH.ReadOnly = false;
        //    tb_BH.BackColor = Color.White;

        //    tb_BL.Text = string.Empty;
        //    tb_BL.ReadOnly = true;
        //    tb_BL.BackColor = Color.LightSlateGray;

        //    tb_CH.Text = "00";
        //    tb_CH.ReadOnly = false;
        //    tb_CH.BackColor = Color.White;

        //    tb_CL.Text = "00";
        //    tb_CL.ReadOnly = false;
        //    tb_CL.BackColor = Color.White;

        //    tb_DH.Text = "00";
        //    tb_DH.ReadOnly = false;
        //    tb_DH.BackColor = Color.White;

        //    tb_DL.Text = "00";
        //    tb_DL.ReadOnly = false;
        //    tb_DL.BackColor = Color.White;

        //    lbl_Help.Text = string.Format("06H." +
        //        Environment.NewLine +
        //        "Чрез функцията се определя правоъгърнлата област от активната видеостраница и нейното съдържание се превърта нагоре указан брой редове." +
        //        Environment.NewLine +
        //        "AL - брой редове за превъртане" +
        //        Environment.NewLine +
        //        "BH - начин за запълване (атрибути и цвят)" +
        //        Environment.NewLine +
        //        "CH, CL - ред и колона на горния ляв ъгъл" +
        //        Environment.NewLine +
        //        "DH, DL - ред и колона на долния ляв ъгъл"
        //        );
        //}

        //Преместване надолу
        //private void radioButton7_CheckedChanged(object sender, EventArgs e)
        //{
        //    buttonCheckedIndex = 7;
        //    tb_AH.Text = "07";
        //    tb_AH.ReadOnly = true;
        //    tb_AH.BackColor = Color.LightGray;

        //    tb_AL.Text = "00";
        //    tb_AL.ReadOnly = false;
        //    tb_AL.BackColor = Color.White;

        //    tb_BH.Text = "00";
        //    tb_BH.ReadOnly = false;
        //    tb_BH.BackColor = Color.White;

        //    tb_BL.Text = string.Empty;
        //    tb_BL.ReadOnly = true;
        //    tb_BL.BackColor = Color.LightSlateGray;

        //    tb_CH.Text = "00";
        //    tb_CH.ReadOnly = false;
        //    tb_CH.BackColor = Color.White;

        //    tb_CL.Text = "00";
        //    tb_CL.ReadOnly = false;
        //    tb_CL.BackColor = Color.White;

        //    tb_DH.Text = "00";
        //    tb_DH.ReadOnly = false;
        //    tb_DH.BackColor = Color.White;

        //    tb_DL.Text = "00";
        //    tb_DL.ReadOnly = false;
        //    tb_DL.BackColor = Color.White;

        //    lbl_Help.Text = string.Format("06H." +
        //        Environment.NewLine +
        //        "Чрез функцията се определя правоъгърнлата област от активната видеостраница и нейното съдържание се превърта надолу указан брой редове." +
        //        Environment.NewLine +
        //        "AL - брой редове за превъртане" +
        //        Environment.NewLine +
        //        "BH - начин за запълване (атрибути и цвят)" +
        //        Environment.NewLine +
        //        "CH, CL - ред и колона на горния ляв ъгъл" +
        //        Environment.NewLine +
        //        "DH, DL - ред и колона на долния ляв ъгъл"
        //        );
        //}

        //Четене на символ и атрибут

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 8;
            tb_AH.Text = "05";
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

            tb_DH.Text = "00";
            tb_DH.ReadOnly = false;
            tb_DH.BackColor = Color.White;

            tb_DL.Text = "00";
            tb_DL.ReadOnly = false;
            tb_DL.BackColor = Color.White;
            
            lbl_Help.Text = string.Format("В текстов режим кода на символа се получава в AL, а байта с атрибути в CX. В BH се задава номера на видеостраницата.");
        }

        //Запис на символ и атрибут
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 9;
            tb_AH.Text = "06";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.Text = "00";
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

            tb_CL.Text = "00";
            tb_CL.ReadOnly = false;
            tb_CL.BackColor = Color.White;

            tb_DH.Text = string.Empty;
            tb_DH.ReadOnly = true;
            tb_DH.BackColor = Color.LightSlateGray;

            tb_DL.Text = string.Empty;
            tb_DL.ReadOnly = true;
            tb_DL.BackColor = Color.LightSlateGray;

            lbl_Help.Text = string.Format(
                "Кода на символа се задава в AL. Символа се извежда толкова пъти, колкото е указано в СХ." +
                " В ВН се задава номера на видеостраницата. Атрибутите за цвят се задават в BL.");
        }

        //Запис на символ
        //private void radioButton10_CheckedChanged(object sender, EventArgs e)
        //{
        //    buttonCheckedIndex = 10;
        //    tb_AH.Text = "0A";
        //    tb_AH.ReadOnly = true;
        //    tb_AH.BackColor = Color.LightGray;

        //    tb_AL.Text = "00";
        //    tb_AL.ReadOnly = false;
        //    tb_AL.BackColor = Color.White;

        //    tb_BH.Text = "00";
        //    tb_BH.ReadOnly = false;
        //    tb_BH.BackColor = Color.White;

        //    tb_BL.Text = "00";
        //    tb_BL.ReadOnly = false;
        //    tb_BL.BackColor = Color.White;

        //    tb_CH.Text = "00";
        //    tb_CH.ReadOnly = false;
        //    tb_CH.BackColor = Color.White;

        //    tb_CL.Text = "00";
        //    tb_CL.ReadOnly = false;
        //    tb_CL.BackColor = Color.White;

        //    tb_DH.Text = string.Empty;
        //    tb_DH.ReadOnly = true;
        //    tb_DH.BackColor = Color.LightSlateGray;

        //    tb_DL.Text = string.Empty;
        //    tb_DL.ReadOnly = true;
        //    tb_DL.BackColor = Color.LightSlateGray;

        //    lbl_Help.Text = string.Format("0АH." +
        //        Environment.NewLine +
        //        "Отличава се от 09Н по това, че записва само кода на символа без да променя атрибутите" +
        //        "за цвят в съответната позиция.");
        //}

        //Смяна палитра

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 11;
            tb_AH.Text = "07";
            tb_AH.ReadOnly = true;
            tb_AH.BackColor = Color.LightGray;

            tb_AL.Text = string.Empty;
            tb_AL.ReadOnly = true;
            tb_AL.BackColor = Color.LightSlateGray;

            tb_BH.Text = string.Empty;
            tb_BH.ReadOnly = true;
            tb_BH.BackColor = Color.LightSlateGray;

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

            lbl_Help.Text = string.Format(
                "В текстов режим BL задава цвета на екрана - от 0 до 15." +
                Environment.NewLine +
                "В графичен режим 320х200 BL задава цвета на фона." +
                Environment.NewLine +
                "В графичен режим 640х200 BL задава цвета на изображението на целия екран - от 0 до 15.");
        }

        //Запис Точка
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 12;
            tb_AH.Text = "08";
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

            lbl_Help.Text = string.Format(
                "Важи само за графичен режим." +
                Environment.NewLine +
                "Координатите на точката се задават във формат ред и колона:" +
                Environment.NewLine +
                "DL - номер на реда" +
                Environment.NewLine +
                "CX - номер на колоната" +
                Environment.NewLine +
                "AL - цвят на точката") +
                Environment.NewLine +
                "От стойността в AL се формира 8-битово двоично число, чиито 3 най-младши бита определят RGB стойностите на цвета на точката.";
        }

        //Четене точка
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 13;
            tb_AH.Text = "09";
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

            lbl_Help.Text = string.Format(
                "Координатите се задават в DL - номер на ред, а в CX - номер на колона." +
                Environment.NewLine +
                "В AL се получава цвета на точката.");
        }

        //Информация
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            buttonCheckedIndex = 14;
            tb_AH.Text = "0А";
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

            lbl_Help.Text = string.Format(
                "Връща следната информация:" +
                Environment.NewLine +
                "AL - текущия режим на изображението (от 0 до 7)" +
                Environment.NewLine +
                "AH - широчината на екрана, представена в колони (40 или 80)" +
                Environment.NewLine +
                "BH - активната видеостраница (0 в графичен режим)");
        }
        #endregion

        private void btn_biosinfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Наименованието BIOS е съкращение от Basic Input/Output System -" +
                " базова система за вход/изход. По същество, това е компютърна програма," +
                " работеща на най-ниско ниво (позната и под наименованието фърмуер), " +
                "която се стартира първа при включване на компютъра. Тя е необходима, " +
                "за да може да се одухотвори желязото, тъй като хардуер без софтуер е именно" +
                " купчина безполезно желязо.Основната функция на тази програма е да инициализира стандартния" +
                " хардуер ( клавиатура, мишка, графичен адаптер, памет и т.н) и да зареди необходимите драйвери" +
                " за управлението му. При пускането на компютъра първоначално се стартира програмата на BIOS за" +
                " инициализация и проверка на работоспособността на инсталираните компоненти, позната като POST" +
                " - Power On Self Test. Като следваща стъпка се прави проверка за състоянието на откритите компоненти," +
                " след което се инициализират и зареждат драйверите им за управление. След успешното завършване на тази" +
                " програма BIOS предава управлението на операционната система.");
        }
    }
}