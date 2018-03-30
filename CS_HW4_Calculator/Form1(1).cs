using System;
using System.Collections;
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
        List<string> HistoryList = new List<string>();

        double Value = 0.0;
        string Operation = "";
        string Function = "";
        bool OperatorPressed = false;
        private bool EqualsPressed = false;
        string LastOperation = "";


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            InputTextBox.Text = "0";
            InputTextBox.Select(InputTextBox.Text.Length, 0);

            Value = 0;
            Operation = "";
            Function = "";
            OperatorPressed = false;

            OneButton.Click += new EventHandler(Num_Click);
            TwoButton.Click += new EventHandler(Num_Click);
            ThreeButton.Click += new EventHandler(Num_Click);
            FourButton.Click += new EventHandler(Num_Click);
            FiveButton.Click += new EventHandler(Num_Click);
            SixButton.Click += new EventHandler(Num_Click);
            SevenButton.Click += new EventHandler(Num_Click);
            EightButton.Click += new EventHandler(Num_Click);
            NineButton.Click += new EventHandler(Num_Click);
            ZeroButton.Click += new EventHandler(Num_Click);
            DotButton.Click += new EventHandler(Num_Click);

            AddButton.Click += new EventHandler(Operator_Click);
            SubtractButton.Click += new EventHandler(Operator_Click);
            MultiplyButton.Click += new EventHandler(Operator_Click);
            DivideButton.Click += new EventHandler(Operator_Click);

            SqrtButton.Click += new EventHandler(Function_Click);
            RecipButton.Click += new EventHandler(Function_Click);
            PlusMinusButton.Click += new EventHandler(Function_Click);

            EqualsButton.Click += new EventHandler(EqualsButton_Click);
            BackButton.Click += new EventHandler(BackButton_Click);
            CEButton.Click += new EventHandler(CEButton_Click);
            ClearButton.Click += new EventHandler(ClearButton_Click);
            HistoryButton.Click += new EventHandler(HistoryButton_Click);
        }


        private void Num_Click(object sender, EventArgs e)
        {
            if ((InputTextBox.Text == "0") || OperatorPressed || EqualsPressed)
            {
                InputTextBox.Clear();
                
            } else { /*doNothing();*/ }

            OperatorPressed = false;
            var Button = sender as Button;
            const int MaxLength = 16;

            if (InputTextBox.Text.Length < MaxLength)
            {
                if ((Button.Text == ".") && InputTextBox.Text.Contains("."))
                {
                    SystemSounds.Beep.Play();
                }
                else
                {
                    InputTextBox.Text += Button.Text;
                }
            }
            else
            {
                SystemSounds.Beep.Play();
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            var Button = sender as Button;
            

            if (!Value.Equals(0.0))
            {
                OperatorPressed = true;
                Operation = Button.Text;

                LastOperation = InputTextBox.Text + " " + Operation + " ";
                HistoryTextBox.Text += LastOperation;

                EqualsPressed = false;
                ResolveOperators();
            }
            else
            {
                OperatorPressed = true;
                Operation = Button.Text;

                LastOperation = InputTextBox.Text + " " + Operation + " ";
                HistoryTextBox.Text += LastOperation;

                Value = Double.Parse(InputTextBox.Text);

                EqualsPressed = false;
                //ResolveOperators();
            }
        }

        private void Function_Click(object sender, EventArgs e)
        {

            var Button = sender as Button;
            var LastOperation = "";
            Function = Button.Text;
            
            switch (Function)
            {

                case "√":
                    LastOperation = "sqrt(" + InputTextBox.Text + ") ";
                    break;
                case "1/x":
                    LastOperation = "recip(" + InputTextBox.Text + ") ";
                    break;
                case "+/-":
                    LastOperation = "negate(" + InputTextBox.Text + ") ";
                    break;
                default:
                    //doNothing();
                    break;
            }
            //HistoryList.Add(LastOperation);
            HistoryTextBox.Text = LastOperation;

            EqualsPressed = false;
            ResolveOperators();
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            EqualsPressed = true;
            ResolveOperators();
        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "0";
            InputTextBox.Select(InputTextBox.Text.Length, 0);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.TextLength != 0)
            {
                InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 1, 1);
                if (InputTextBox.TextLength == 0)
                {
                    InputTextBox.Text = "0";
                }
                else { /*doNothing();*/ }
            }
            else
            {
                InputTextBox.Text = "0";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Value = 0.0;
            Operation = "";
            Function = "";
            OperatorPressed = false;
            LastOperation = "";
            
            HistoryTextBox.Clear();
            InputTextBox.Text = "0";
            InputTextBox.Select(InputTextBox.Text.Length, 0);
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Form2 HistoryForm = new Form2();
            var message = string.Join(Environment.NewLine, HistoryList);
            HistoryForm.HistoryRichTextBox.Text = message;
            HistoryForm.Show();
        }

        private void ResolveOperators()
        {
            var HiddenValue = Double.Parse(InputTextBox.Text);

            if (Operation != "")
            {
                var DivByZero = false;
                InputTextBox.Clear();
                switch (Operation)
                {
                    case "+": 
                        Value += HiddenValue;
                        break;
                    case "-":
                        Value -= HiddenValue;
                        break;
                    case "*":
                        Value *= HiddenValue;
                        break;
                    case "/":
                        if (HiddenValue.Equals(0.0))
                        {
                            DivByZero = true;
                            MessageBox.Show("Cannot divide by zero");
                            ClearButton.PerformClick();
                        }
                        else
                        {
                            Value /= HiddenValue;
                        }
                        break;
                    default:
                        //doNothing();
                        break;
                }

                if (EqualsPressed && !DivByZero)
                {
                    HistoryTextBox.Text += (HiddenValue.ToString() + " = " + Value.ToString());
                    HistoryList.Add(HistoryTextBox.Text);
                    HistoryTextBox.Clear();
                }
                else { /*doNothing();*/ }
            }
            else if (Function != "")
            {
                switch (Function)
                {
                    case "√":
                        Value = Math.Sqrt(Double.Parse(InputTextBox.Text));
                        InputTextBox.Text = Value.ToString();
                        break;
                    case "1/x":
                        Value = (1.0 / Double.Parse(InputTextBox.Text));
                        InputTextBox.Text = Value.ToString();
                        break;
                    case "+/-":
                        Value = (-1 * Double.Parse(InputTextBox.Text));
                        InputTextBox.Text = Value.ToString();
                        break;
                    default:
                        //doNothing();
                        break;
                }
                HistoryList.Add(HistoryTextBox.Text + " = " + InputTextBox.Text);
            }

            if ((Operation == "") && (Function == ""))
            {
                InputTextBox.Text = HiddenValue.ToString();
            }
            else
            {
                InputTextBox.Text = Value.ToString();
            }
            

            if (Function != "" || EqualsPressed)
            {
                Value = 0;
            } else { /*doNothing();*/ }

        }

        
        private void InputTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //ASCII Values as int constants
            const int BS = 8;        //BS
            const int Dot = 46;      //'.'
            const int Add = 43;      //'+'
            const int Sub = 45;      //'-'
            const int Mult = 42;     //'*'
            const int Div = 47;      //'/'

            var c = e.KeyChar;

            InputTextBox.Focus();
            InputTextBox.Select(InputTextBox.Text.Length, 0);

            if (c == Dot && InputTextBox.Text.Contains("."))
            {
                SystemSounds.Beep.Play();
            }
            else { /*doNothing();*/ }

            if (c == Dot && InputTextBox.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            else { /*doNothing();*/ }

            if (!char.IsDigit(c) && c != BS && c != '.')
            {
                e.Handled = true;
            }
            else { /*doNothing();*/ }

            if (char.IsDigit(c))
            {
                FixTextBox();
            }
            else { /*doNothing();*/ }

            if (c == Add)
            {
                AddButton.PerformClick();
            }
            else if (c == Sub)
            {
                SubtractButton.PerformClick();
            }
            else if (c == Mult)
            {
                MultiplyButton.PerformClick();
            }
            else if (c == Div)
            {
                DivideButton.PerformClick();
            }
            else { /*doNothing();*/ }
        }

        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                InputTextBox.Text= "0";
            }
            else { /*doNothing();*/ }
        }

        private void FixTextBox()
        {
            if ((InputTextBox.Text == "0") || OperatorPressed)
            {
                InputTextBox.Clear();
            }
            else { /*doNothing();*/ }

            OperatorPressed = false;
        }
    }
}