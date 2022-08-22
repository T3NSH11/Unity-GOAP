using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanAction : ActionBase
{
    public override List<string> Prerequisites { get; set;}
    public override List<string> Effects { get; set;}

    public override void Setup()
    {
        Prerequisites = new List<string>();
        Effects = new List<string>();

        Prerequisites.Add("World Dirty");
        Prerequisites.Add("Working");
        Effects.Add("World Clean");
    }

    public override string DoAction(Agent agent)
    {
        // Move About 
        return "Completed";
    }

}
