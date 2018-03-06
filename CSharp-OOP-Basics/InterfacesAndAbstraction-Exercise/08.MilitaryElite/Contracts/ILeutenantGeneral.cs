using System;
using System.Collections.Generic;
using System.Text;

public interface ILeutenantGeneral : IPrivate
{
    IReadOnlyCollection<ISoldier> Private { get; }

    void AddPrivate(ISoldier soldier);
}

