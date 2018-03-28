using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_HW4_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Calculator calculator = new Calculator();
        
        decimal RunningTotal = 0.0m; ///USED FOR UPDATED LIST TOTAL to


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            InputTextBox.Focus();

            OneButton.Click += new EventHandler(Button_Click);
            TwoButton.Click += new EventHandler(Button_Click);
            ThreeButton.Click += new EventHandler(Button_Click);
            FourButton.Click += new EventHandler(Button_Click);
            FiveButton.Click += new EventHandler(Button_Click);
            SixButton.Click += new EventHandler(Button_Click);
            SevenButton.Click += new EventHandler(Button_Click);
            EightButton.Click += new EventHandler(Button_Click);
            NineButton.Click += new EventHandler(Button_Click);
            ZeroButton.Click += new EventHandler(Button_Click);
            DotButton.Click += new EventHandler(Button_Click);
            AddButton.Click += new EventHandler(Button_Click);
            SubtractButton.Click += new EventHandler(Button_Click);
            MultiplyButton.Click += new EventHandler(Button_Click);
            DivideButton.Click += new EventHandler(Button_Click);
            SqrtButton.Click += new EventHandler(Button_Click);
            RecipButton.Click += new EventHandler(Button_Click);
            PlusMinusButton.Click += new EventHandler(Button_Click);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                InputTextBox.Focus();
                InputTextBox.Select(InputTextBox.Text.Length, 0);

                var Button = sender as Button;
                var MaxLength = 16;

                if (InputTextBox.Text.Length < MaxLength)
                {
                    switch (Button.Name)
                    {
                        case "OneButton":
                            InputTextBox.Text += "1";
                            HistoryTextBox.Text += "1";
                            break;
                        case "TwoButton":
                            InputTextBox.Text += "2";
                            HistoryTextBox.Text += "2";
                            break;
                        case "ThreeButton":
                            InputTextBox.Text += "3";
                            HistoryTextBox.Text += "3";
                            break;
                        case "FourButton":
                            InputTextBox.Text += "4";
                            HistoryTextBox.Text += "4";
                            break;
                        case "FiveButton":
                            InputTextBox.Text += "5";
                            HistoryTextBox.Text += "5";
                            break;
                        case "SixButton":
                            InputTextBox.Text += "6";
                            HistoryTextBox.Text += "6";
                            break;
                        case "SevenButton":
                            InputTextBox.Text += "7";
                            HistoryTextBox.Text += "7";
                            break;
                        case "EightButton":
                            InputTextBox.Text += "8";
                            HistoryTextBox.Text += "8";
                            break;
                        case "NineButton":
                            InputTextBox.Text += "9";
                            HistoryTextBox.Text += "9";
                            break;
                        case "ZeroButton":
                            InputTextBox.Text += "0";
                            HistoryTextBox.Text += "0";
                            break;
                        case "DotButton":
                            if (!InputTextBox.Text.Contains("."))
                            {
                                InputTextBox.Text += ".";
                                HistoryTextBox.Text += ".";
                            }
                            else { /*doNothing()*/ }
                            break;
                        case "AddButton":
                            //HistoryTextBox.Text += InputTextBox.Text + " + ";
                            break;
                        case "SubtractButton":
                            //HistoryTextBox.Text += InputTextBox.Text + " - ";
                            break;
                        case "MultiplyButton":
                            //HistoryTextBox.Text += InputTextBox.Text + " * ";
                            break;
                        case "DivideButton":
                            //HistoryTextBox.Text += InputTextBox.Text + " / ";
                            break;
                        case "SqrtButton":
                            //HistoryTextBox.Text += "sqrt()";
                            break;
                        case "RecipButton":
                            //HistoryTextBox.Text += "recip()";
                            break;
                        case "PlusMinusButton":
                            //HistoryTextBox.Text += "negate()";
                            break;
                    }
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error!\n" + 
                                ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Add(DisplayValue);
            HistoryTextBox.Text += InputTextBox.Text + " + ";
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubtractButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Subtract(DisplayValue);
            HistoryTextBox.Text += InputTextBox.Text + " - ";
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiplyButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Multiply(DisplayValue);
            HistoryTextBox.Text += InputTextBox.Text + " * ";
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DivideButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Divide(DisplayValue);
            HistoryTextBox.Text += InputTextBox.Text + " / ";
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqrtButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.SquareRoot(DisplayValue);
            calculator.Equals(DisplayValue);
            InputTextBox.Text = Calculator.Operand1.ToString();
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecipButton_Click_1(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Reciprocal(DisplayValue);
            calculator.Equals(DisplayValue);
            InputTextBox.Text = Calculator.Operand1.ToString();
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Inverse(DisplayValue);
            calculator.Equals(DisplayValue);
            InputTextBox.Text = Calculator.Operand1.ToString();
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            HistoryTextBox.Clear();
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Equals(DisplayValue);
            InputTextBox.Clear();
            InputTextBox.Text = Calculator.Operand1.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            HistoryTextBox.Clear();
            InputTextBox.Clear();
            InputTextBox.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Clear();
            InputTextBox.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.TextLength != 0)
            {
                InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 1, 1);
            }
            else { /*doNothing*/ }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns></returns>
        private double StringToDouble(string DisplayValue)
        {
            var DoubleIsValid = double.TryParse(DisplayValue, out var NewDouble);

            if (DoubleIsValid)
            {
                return NewDouble;
            }
            else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Restricts user input to numeric, single-decimal input only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            InputTextBox.Focus();
            InputTextBox.Select(InputTextBox.Text.Length, 0);

            var c = e.KeyChar;

            if (c == 46 && InputTextBox.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }


            if (c == 43)
            {
                AddButton.PerformClick();
            }
            else if (c == 45)
            {
                SubtractButton.PerformClick();
            }
            else if (c == 42)
            {
                MultiplyButton.PerformClick();
            }
            else if (c == 47)
            {
                DivideButton.PerformClick();
            }

        }
    }
}