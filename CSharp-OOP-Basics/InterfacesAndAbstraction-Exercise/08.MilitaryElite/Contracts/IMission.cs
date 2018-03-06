using System;
using System.Collections.Generic;
using System.Text;

public interface IMission
{
    string CodeName { get; }

    MissionState State { get; }

    void Complete();
}

