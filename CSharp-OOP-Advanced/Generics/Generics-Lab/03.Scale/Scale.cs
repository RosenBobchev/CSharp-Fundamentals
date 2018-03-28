using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T>
    where T : IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        var compare = left.CompareTo(right);

        if (compare > 0)
        {
            return left;
        }
        else if (compare < 0)
        {
            return right;
        }

        return default(T);
    }
}

