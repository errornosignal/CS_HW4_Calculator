using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace CS_HW4_Calculator
{
    public partial class Form1 : Form
    {
        List<string> HistoryList = new List<string>();
        double Value = 0.0;
        string Operation = "";
        string Function = "";
        string LastOperation = "";
        bool OperatorPressed = false;
        bool FunctionPressed = false;
        bool EqualsPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets initial form state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// EventHandler for Num_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_Click(object sender, EventArgs e)
        {
            if ((InputTextBox.Text == "0") || OperatorPressed || EqualsPressed)
            {
                InputTextBox.Clear();
                
            } else { /*doNothing();*/ }

            OperatorPressed = false;
            FunctionPressed = false;
            EqualsPressed = false;

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

        /// <summary>
        /// EventHandler for Operator_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operator_Click(object sender, EventArgs e)
        {
            if (!Value.Equals(0.0))
            {
                ResolveOperators();

                var Button = sender as Button;
                OperatorPressed = true;
                EqualsPressed = false;
                Operation = Button.Text;
                LastOperation = InputTextBox.Text + " " + Operation + " ";
                HistoryTextBox.Text += LastOperation; 
            }
            else
            {
                var Button = sender as Button;
                OperatorPressed = true;
                EqualsPressed = false;
                Operation = Button.Text;
                LastOperation = InputTextBox.Text + " " + Operation + " ";
                HistoryTextBox.Text += LastOperation;

                Value = Double.Parse(InputTextBox.Text);
            }

            InputTextBox.Text = Value.ToString();
        }

        /// <summary>
        /// EventHandler for FunctionClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Function_Click(object sender, EventArgs e)
        {
            FunctionPressed = true;
            OperatorPressed = false;
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
            HistoryTextBox.Text = LastOperation;
            EqualsPressed = false;
            ResolveOperators();
        }

        /// <summary>
        /// Performs "Equals" Calculations
        /// </summary>
        private void ResolveOperators()
        {
            bool InputValid = Double.TryParse(InputTextBox.Text, out var HiddenValue);

            if (InputValid)
            {
                if (Operation != "")
                {
                    var DivByZero = false;

                    switch (Operation)
                    {
                        case "+":
                            Value += HiddenValue;
                            InputTextBox.Text = Value.ToString();
                            break;
                        case "-":
                            Value -= HiddenValue;
                            InputTextBox.Text = Value.ToString();
                            break;
                        case "*":
                            Value *= HiddenValue;
                            InputTextBox.Text = Value.ToString();
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
                                InputTextBox.Text = Value.ToString();
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
                    } else { /*doNothing();*/ }
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

                if (!OperatorPressed && !FunctionPressed)
                {
                    InputTextBox.Text = HiddenValue.ToString();
                } else { /*doNothing();*/ }
                
                if (!OperatorPressed && EqualsPressed)
                {
                    InputTextBox.Text = Value.ToString();
                } else { /*doNothing();*/ }
                
                if (FunctionPressed || EqualsPressed)
                {
                    InputTextBox.Text = Value.ToString();
                    Value = 0;
                }  else { /*doNothing();*/ }
            }
            else
            {
                MessageBox.Show("You broke it  :'( ");
            }
        }

        /// <summary>
        /// EventHandler for EqualsButton_Click
        /// Calls method to perform "Equals" calculations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            EqualsPressed = true;
            ResolveOperators();
        }

        /// <summary>
        /// EventHandler for CEButton_Click
        /// Resets state of text box to default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CEButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "0";
            InputTextBox.Select(InputTextBox.Text.Length, 0);
        }

        /// <summary>
        /// EventHandler for BackButton_Click
        /// Allows user to delete one character per click from the input text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// EventHandler for ClearButton_Click
        /// Resets the form to default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// EventHandler for HistoryButton_Click
        /// Shows calculation history.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Form2 HistoryForm = new Form2();
            var message = string.Join(Environment.NewLine, HistoryList);
            HistoryForm.HistoryRichTextBox.Text = message;
            HistoryForm.Show();
        }



        /// <summary>
        /// EventHandler for InputTextBox_KeyPress_1
        /// Allows use of NumPad for calculator control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// EventHandler for InputTextBox_KeyUp
        /// Resets state of text box to default values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (InputTextBox.Text.Length == 0)
            {
                InputTextBox.Text= "0";
            }
            else { /*doNothing();*/ }
        }

        /// <summary>
        /// Resets state of text box to default values.
        /// </summary>
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