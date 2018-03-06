using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMission
{
    public Mission(string codeName, string missionState)
    {
        this.CodeName = codeName;
        ParseMissionState(missionState);
    }

    private void ParseMissionState(string missionState)
    {
        bool missionIsValid = Enum.TryParse(typeof(MissionState), missionState, out object result);

        if (missionIsValid)
        {
            this.State = (MissionState)result;
        }
        else
        {
            throw new ArgumentException("Mission finished");
        }
    }

    public string CodeName { get; private set; }
    public MissionState State { get; private set; }

    public void Complete()
    {
        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
