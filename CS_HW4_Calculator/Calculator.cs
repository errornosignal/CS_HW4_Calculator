﻿using System.Windows.Forms;

namespace CS_HW4_Calculator
{
    using System;

    /// <summary>
    /// Calculator Class
    /// </summary>
    internal class Calculator
    {
        //A decimal that stores the result currently displayed by the calculator.
        public static double CurrentValue = 0.0;

        //A double that stores the value of the first operand.
        public static double Operand1 = 0.0;

        //A double that stores the value of the second operand.
        private double Operand2 = 0.0;

        //An Operator type that stores a member of the Operator enumeration.
        public Operator Op = Operator.None;

        /// <summary>
        /// An enumeration with these constants: Add, Subtract, Multiply, Divide, and None.
        /// </summary>
        public enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            SquareRoot,
            Reciprocal,
            Inverse,
            None
        };
        
        /// <summary>
        /// Creates a Calculator object with default values. The default value for the op field is Operator.None.
        /// </summary>
        public Calculator()
        {
            Op = Operator.None;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Add.
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns></returns>
        public void Add(double DisplayValue)
        {
            //MessageBox.Show("Operand1 = " + Operand1 + "\n"
                            //+ "DisplayValue = " + DisplayValue);
            Operand1 = DisplayValue;
            Op = Operator.Add;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Subtract.
        /// </summary>
        /// <param name=" "></param>
        public void Subtract(double DisplayValue)
        {
            //MessageBox.Show("Operand1 = " + Operand1 + "\n"
            //+ "DisplayValue = " + DisplayValue);
            Operand1 = DisplayValue;
            Op = Operator.Subtract;
            //MessageBox.Show("Operand1 = " + Operand1 + "\n"
            //                + "DisplayValue = " + DisplayValue);
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Multiply.
        /// </summary>
        /// <param name=" "></param>
        public void Multiply(double DisplayValue)
        {
            Operand1 = DisplayValue;
            Op = Operator.Multiply;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Divide.
        /// </summary>
        /// <param name=" "></param>
        public void Divide(double DisplayValue)
        {
            Operand1 = DisplayValue;
            Op = Operator.Divide;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.SqareRoot.
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns></returns>
        public void SquareRoot(double DisplayValue)
        {
            Operand1 = DisplayValue;
            Op = Operator.SquareRoot;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Reciprocal.
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns></returns>
        public void Reciprocal(double DisplayValue)
        {
            Operand1 = DisplayValue;
            Op = Operator.Reciprocal;
        }

        /// <summary>
        /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Inverse.
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns></returns>
        public void Inverse(double DisplayValue)
        {
            Operand1 = DisplayValue;
            Op = Operator.Inverse;
        }

        /// <summary>
        /// Sets the operand2 field to the value that’s passed to it. Then, performs the operation specified by the op field on the operand1 and operand2 fields, and stores the result in the operand1 field.
        /// </summary>
        /// <param name="DisplayValue"></param>
        /// <returns>Operand1 as a decimal value</returns>
        public decimal Equals(double DisplayValue)
        {
            const double Zero = 0.0;
            const int RoundTo = 14;
            Operand1 = DisplayValue;
            Operand2 = CurrentValue;

            switch (Op)
            {
                case Operator.Add:
                    Operand1 += Operand2;
                    break;
                case Operator.Subtract:
                    Operand1 -= Operand2;
                    break;
                case Operator.Multiply:
                    Operand1 *= Operand2;
                    break;
                case Operator.Divide:
                    if (Operand2.Equals(Zero))
                    {
                        MessageBox.Show("Cannot divide by zero.");
                    }
                    else
                    {
                        Operand1 /= Operand2;
                    }
                    break;
                case Operator.SquareRoot:
                    Operand1 = Math.Sqrt(Operand1);
                    break;
                case Operator.Reciprocal:
                    Operand1 = Math.Round(1.0 / Operand1, RoundTo);
                    break;
                case Operator.Inverse:
                    Operand1 = Operand1 * -1;
                    break;
                case Operator.None:
                default:
                    //doNothing();
                    break;
            }
            CurrentValue = Operand1;
            return Convert.ToDecimal(CurrentValue);
        }

        /// <summary>
        /// Sets the private fields to their default values.
        /// </summary>
        public void Clear()
        {
            CurrentValue = 0.0;
            Operand1 = 0.0;
            Operand2 = 0.0;
            Op = Operator.None;
        }
    }
}