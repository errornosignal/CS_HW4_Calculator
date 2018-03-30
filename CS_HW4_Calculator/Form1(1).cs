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
        public Form1()
        {
            InitializeComponent();
        }

        Calculator calculator = new Calculator();
        double Value = 0;
        string userInput = "";
        bool OperatorPressed = false;
        bool FunctionPressed = false;

        ///USED FOR UPDATED LIST TOTAL to
        double RunningTotal = 0.0;


        private void Form1_Load_1(object sender, EventArgs e)
        {
            InputTextBox.Text = "0";
        	InputTextBox.Select(InputTextBox.Text.Length, 0);

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
        }

      
        private void Num_Click(object sender, EventArgs e)
        {
            try
            {
                ClearZeroInTextBox();
                InputTextBox.Focus();
                InputTextBox.Select(InputTextBox.Text.Length, 0);

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
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error!\n" + ex.Message);
            }
        }


        
        private void Operator_Click(object sender, EventArgs e)
        {
            //ClearZeroInTextBox();
            InputTextBox.Focus();
            InputTextBox.Select(InputTextBox.Text.Length, 0);

            var Button = sender as Button;
            var Operation = Button.Text;
            Value = StringToDouble(InputTextBox.Text);
            OperatorPressed = true;

            HistoryTextBox.Text += InputTextBox.Text + " " + Operation + " ";

            InputTextBox.Clear();

            switch (Operation)
            {
                case "+":
                    calculator.Add(Value);
                    break;
                case "-":
                    calculator.Subtract(Value);
                    break;
                case "*":
                    calculator.Multiply(Value);
                    break;
                case "/":
                    calculator.Divide(Value);
                    break;
                default:
                    //doNothing();
                    break;
            }
        }


        private void Function_Click(object sender, EventArgs e)
        {
            var Button = sender as Button;
            var Function = Button.Text;
            var DisplayValue = StringToDouble(InputTextBox.Text);
            FunctionPressed = true;

            switch (Function)
            {
                case "√":
                    HistoryTextBox.Text += "sqrt(" + InputTextBox.Text + ") ";
                    calculator.SquareRoot(DisplayValue);
                    break;
                case "1/x":
                    HistoryTextBox.Text += "recip(" + InputTextBox.Text + ") ";
                    calculator.Reciprocal(DisplayValue);
                    break;
                case "+/-":
                    calculator.Inverse(DisplayValue);
                    break;
                default:
                    //doNothing();
                    break;
            }

            calculator.Equals(DisplayValue);

            InputTextBox.Text = Calculator.Operand1.ToString();
        }

            private void EqualsButton_Click(object sender, EventArgs e)
        {
            HistoryTextBox.Clear();
            var DisplayValue = StringToDouble(InputTextBox.Text);
            calculator.Equals(DisplayValue);
            InputTextBox.Clear();
            InputTextBox.Text = Calculator.Operand1.ToString();
        }

    
        private void ClearButton_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            HistoryTextBox.Clear();
            InputTextBox.Clear();
            ResetText();

            InputTextBox.Focus();
            InputTextBox.Select(InputTextBox.Text.Length, 0);
        }

       
        private void CEButton_Click(object sender, EventArgs e)
        {
            ResetText();
        }

     
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.TextLength != 0)
            {
                InputTextBox.Text = InputTextBox.Text.Remove(InputTextBox.Text.Length - 1, 1);
            }
            else { /*doNothing*/ }
        }


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
                ClearZeroInTextBox();
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
            if(InputTextBox.Text.Length == 0)
            {
                ResetText();
            }
            else { /*doNothing();*/ }
        }


        private void ClearZeroInTextBox()
        {
            if (InputTextBox.Text == "0")
            {
                InputTextBox.Clear();
            }
            else { /*doNothing();*/ }
        }

 
        public override void ResetText()
        {
            InputTextBox.Text = "0";
        }

        


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void AddButton_Click_1(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(userInput);
        //    calculator.Add(DisplayValue);
        //    HistoryTextBox.Text += InputTextBox.Text + " + ";
        //    InputTextBox.Clear();


        //    //var DisplayValue = StringToDouble(InputTextBox.Text);
        //    //InputTextBox.Clear();

        //    //calculator.Add(DisplayValue);

        //    //ValueList.Add(DisplayValue);
        //    //OperatorList.Add("+");

        //    //HistoryTextBox.Text += ValueList[ValueList.Count - 1] + " " + OperatorList[OperatorList.Count - 1] + " ";



        //    ////InputTextBox.Text = RunningTotal.ToString();

        //    ////InputTextBox.Clear();

        //    //if (RunningTotal > 0 && ValueList.Count > 1)
        //    //{
        //    //    for (int i = 0; i < ValueList.Count; i++)
        //    //    {
        //    //        RunningTotal += ValueList[i];
        //    //    }




        //    //    InputTextBox.Text = RunningTotal.ToString();
        //    //}
        //    //else { /*doNothing();*/ }
        //}





        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SubtractButton_Click_1(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.Subtract(DisplayValue);
        //    HistoryTextBox.Text += InputTextBox.Text + " - ";
        //    InputTextBox.Clear();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void MultiplyButton_Click_1(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.Multiply(DisplayValue);
        //    HistoryTextBox.Text += InputTextBox.Text + " * ";
        //    InputTextBox.Clear();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DivideButton_Click_1(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.Divide(DisplayValue);
        //    HistoryTextBox.Text += InputTextBox.Text + " / ";
        //    InputTextBox.Clear();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SqrtButton_Click_1(object sender, EventArgs e)
        //{
        //    HistoryTextBox.Text += "sqrt(" + InputTextBox.Text + ")";
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.SquareRoot(DisplayValue);
        //    calculator.Equals(DisplayValue);
        //    InputTextBox.Text = Calculator.Operand1.ToString();
        //    InputTextBox.Clear();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void RecipButton_Click_1(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.Reciprocal(DisplayValue);
        //    calculator.Equals(DisplayValue);
        //    InputTextBox.Text = Calculator.Operand1.ToString();
        //    InputTextBox.Clear();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void PlusMinusButton_Click(object sender, EventArgs e)
        //{
        //    var DisplayValue = StringToDouble(InputTextBox.Text);
        //    calculator.Inverse(DisplayValue);
        //    calculator.Equals(DisplayValue);
        //    InputTextBox.Text = Calculator.Operand1.ToString();
        //    InputTextBox.Clear();
        //}
    }
}