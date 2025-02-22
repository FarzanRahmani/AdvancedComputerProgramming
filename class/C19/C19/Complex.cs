using System;

public class Complex 
{
    public double Img {get; private set;}
    public double Real{get; private set;}

    public double this[int n]
    {
        get => n == 0 ? Img: Real;

        set {
            if (n==0)
                this.Img = value;
            else
                this.Real = value; // n == 1
        } 
        
    }


    public double this[string p]
    {
        get => p.ToLower().Equals("img") ? Img: Real;

        set {
            if (p.ToLower().Equals("img"))
                this.Img = value;
            else
                this.Real = value;
        } 
        
    }
    public Complex(double img, double real)
    {
        this.Img = img;
        this.Real = real;
    }

    public static Complex operator+(Complex left, Complex right) => 
        new Complex(left.Img + right.Img, left.Real+right.Real);

    public static Complex operator+(Complex LHS, double RHS) => 
        new Complex(LHS.Img, LHS.Real + RHS);

    public static Complex operator*(Complex c1, double d) =>
        new Complex(c1.Img*d, c1.Real*d);

    public static Complex operator*(Complex c1, Complex c2) => // binary operator
        new Complex(c1.Real*c2.Img+c1.Img*c2.Real,c1.Real*c2.Real-c1.Img*c2.Img);
    
    public static Complex operator++(Complex c) // unary operator
    {
        c.Real++;
        return c;
    }

    public static Complex operator--(Complex c)
    {
        return new Complex(c.Img,c.Real-1);
    }

    public static implicit operator Complex(double from) => // cast kon gheir mostaghim (bedone parantez) --> Complex c = 5.5
        new Complex(0, from); // f(Complex c) --> f(5.5)

    // 5.5i+4
    public static implicit operator Complex(string str) // cast kon gheir mostaghim (bedone parantez) --> Complex c = "4.2i+9"  ... be tor zemni
    { //" 8.9 i + 7 "
        string[] toks = str.Split('+');
        string img = toks[0].Trim(new char[]{' ', 'i'});
        string real = toks[1].Trim(); // Trim('0')
        return new Complex(double.Parse(img), double.Parse(real));
        //*** vaghti implicit tarif mikoni explicit ham kar mikone
    }
    
    public static explicit operator double(Complex c) => c.Real; // cast kon mostaghim (ba parantez) --> double d = (double) Complex

    public override bool Equals(object obj)
    {
        if (obj is Complex)
        {
            Complex c = obj as Complex;
            return c == this;
        }

        if (obj is string)
        {
            string s = obj as string;
            return s == this; // chon implicit dare
        }

        else
            return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return this.Img.ToString() + "i+" + this.Real.ToString();
    }

    public static explicit operator string(Complex from) // cast kon mostaghim (ba parantez) --> string s = (string) Complex
    {
        return from.Img.ToString() + "i+" + from.Real.ToString();
    }

    public static bool operator ==(Complex lhs, Complex rhs)
    {
        if (lhs.Real != rhs.Real || lhs.Img != rhs.Img)
            return false;
        return true;
    }

    public static bool operator !=(Complex lhs, Complex rhs)
    {
        return !(lhs == rhs);
    }

}