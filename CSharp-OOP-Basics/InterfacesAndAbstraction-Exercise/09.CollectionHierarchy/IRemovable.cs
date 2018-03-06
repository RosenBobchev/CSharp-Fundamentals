using System;
using System.Collections.Generic;
using System.Text;

public interface IRemovable
{
    string RemovedElements { get; }

    void Remove();
}

