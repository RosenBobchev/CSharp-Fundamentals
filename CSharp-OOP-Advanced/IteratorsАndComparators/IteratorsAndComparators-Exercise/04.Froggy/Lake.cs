using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake<T> : IEnumerable<T>
{
    private List<T> stones;

    public Lake(IEnumerable<T> stones)
    {
        this.stones = new List<T>(stones);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return stones[i];
            }
        }

        for (int i = stones.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

