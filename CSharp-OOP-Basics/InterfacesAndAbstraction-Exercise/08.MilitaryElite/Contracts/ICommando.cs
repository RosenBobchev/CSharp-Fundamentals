﻿using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }

    void AddMissions(IMission mission);

    void CompleteMission(string missionCodeName);
}

