using System;
using System.Collections.Generic;
using System.Text;

public class Tuple<T1, T2>
{
    private T1 firstProp;
    private T2 secondProp;

    public Tuple(T1 firstProp, T2 secondProp)
    {
        this.firstProp = firstProp;
        this.secondProp = secondProp;
    }

    public override string ToString()
    {
        return $"{this.firstProp.ToString()} -> {this.secondProp.ToString()}";
    }
}

