using System;


/// <summary>
/// Calculator Class
/// </summary>
public class Calculator
{
    //A decimal that stores the result currently displayed by the calculator.
    public decimal CurrentValue = 0.0m;

    //A double that stores the value of the first operand.
    public double Operand1 = 0.0;

    //A double that stores the value of the second operand.
    private double Operand2 = 0.0;

    //An Operator type that stores a member of the Operator enumeration.
    public Operator Op = Operator.None;

    //An enumeration with these constants: Add, Subtract, Multiply, Divide, and None.
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

    //Creates a Calculator object with default values. The default value for the op field is Operator.None.
    public Calculator()
    {
        Op = Operator.None;
    }

    /// <summary>
    /// Gets the value of the CurrentValue field.
    /// </summary>
    //public decimal CurrentValue { get; }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Add.
    /// </summary>
    /// <param name="DisplayValue"></param>
    /// <returns></returns>
    public void Add(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Add;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Subtract.
    /// </summary>
    /// <param name=""></param>
    public void Subtract(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Subtract;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Multiply.
    /// </summary>
    /// <param name=""></param>
    public void Multiply(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Multiply;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Divide.
    /// </summary>
    /// <param name=""></param>
    public void Divide(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Divide;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.SqareRoot.
    /// </summary>
    /// <param name="DisplayValue"></param>
    /// <returns></returns>
    public void SquareRoot(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.SquareRoot;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Reciprocal.
    /// </summary>
    /// <param name="DisplayValue"></param>
    /// <returns></returns>
    public void Reciprocal(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Reciprocal;
    }

    /// <summary>
    /// Sets the operand1 and currentValue fields to the value that’s passed to it, and sets the op field to Operation.Inverse.
    /// </summary>
    /// <param name="DisplayValue"></param>
    /// <returns></returns>
    public void Inverse(string DisplayValue)
    {
        Operand1 = DisplayValue;
        Op = Operator.Inverse;
    }

    ///// <summary>
    ///// Performs the operation specified by the op field on the operand1 and operand2 fields, and stores the result in the operand1 field.
    ///// </summary>
    //public bool Equals()
    //{
    //    if (1==1) //NEED TO FIX!!!
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    /// <summary>
    /// Sets the operand2 field to the value that’s passed to it. Then, performs the operation specified by the op field on the operand1 and operand2 fields, and stores the result in the operand1 field.
    /// </summary>
    /// <param name=""></param>
    public decimal Equals(string DisplayValue)
    {
        const double Zero = 0.0;

        Operand2 = DisplayValue;
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
                    MessageBox.Show("DIVIDE BY ZERO not allowed!");
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
                Operand1 = 1 / Operand1;
                break;
            case Operator.Inverse:
                Operand1 = Operand1 * -1;
                break;
            default:
                //doNothing();
                break;
        }

        return Convert.ToDecimal(Operand1);
    }

    /// <summary>
    /// Sets the private fields to their default values.
    /// </summary>
    public void Clear()
    {
        this.CurrentValue = 0.0m;
        this.Operand1 = 0.0;
        this.Operand2 = 0.0;
        this.Op = Operator.None;
    }
}