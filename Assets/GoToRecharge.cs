using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRecharge : ActionBase
{
    public override List<string> Prerequisites { get; set; }
    public override List<string> Effects { get; set; }

    public override void Setup()
    {
        Prerequisites = new List<string>();
        Effects = new List<string>();

        Effects.Add("On Charge Pad");
    }

    public override string DoAction(Agent agent)
    {
        agent.gameObject.transform.position += Vector3.MoveTowards(agent.gameObject.transform.position, agent.RechargeStation.transform.position, 5 * Time.deltaTime);

        if (Vector3.Distance(agent.gameObject.transform.position, agent.RechargeStation.transform.position) < 0.2)
        {
            return "Completed";
        }
        else
        {
            return "incomplete";
        }
    }

}
