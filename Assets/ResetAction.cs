using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAction : ActionBase
{
    public override List<string> Prerequisites { get; set; }
    public override List<string> Effects { get; set; }
    public override void Setup()
    {
        Prerequisites = new List<string>();
        Effects = new List<string>();

        Effects.Add("Working");
    }

    public override string DoAction(Agent agent)
    {
        return "Completed";
    }

}
