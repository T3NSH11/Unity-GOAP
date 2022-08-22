using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeAction : ActionBase
{
    public override List<string> Prerequisites { get; set; }
    public override List<string> Effects { get; set; }

    public override void Setup()
    {
        Prerequisites = new List<string>();
        Effects = new List<string>();

        Prerequisites.Add("On Charge Pad");
        Prerequisites.Add("Working");
        Effects.Add("Charged");
    }

    public override string DoAction(Agent agent)
    {
        agent.ChargeStatus += 10 * Time.deltaTime;

        if(agent.ChargeStatus >= 100)
        {
            return "Completed";
        }
        else
        {
            return "Incomplete";
        }
    }
}
