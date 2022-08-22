using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Planner
{
    public List<ActionBase> Actions = new List<ActionBase>();

    // check if action is doable when GetNextAction(goal) if not doable get prereq in result action that isnt in aprereqs then run GetNextAction(result)
    public List<ActionBase> GetActionList(string Goal, Agent agent)
    {
        List<ActionBase> ActionList = new List<ActionBase>();
        ActionBase GoalAction;

        GoalAction = GetNextAction(Goal, agent);

        ActionBase currentAction = GoalAction;

        if (CheckIfActionDoable(currentAction, agent))
        {
            ActionList.Add(currentAction);
            return ActionList;
        }

        while (!CheckIfActionDoable(currentAction, agent))
        {
            currentAction = GetNextAction(GetRequiredPrereq(currentAction, agent), agent);
            ActionList.Add(currentAction);
        }
        ActionList.Add(GoalAction);

        return ActionList;
    }

    ActionBase GetNextAction(string effect, Agent agent)
    {
        foreach (ActionBase a in Actions)
        {
            foreach (string e in a.Effects)
            {
                if (e == effect)
                {
                    return a;
                }
            }
        }
        return new ResetAction();
    }

    string GetRequiredPrereq(ActionBase action, Agent agent)
    {
        return action.Prerequisites.Except(agent.AquiredPrerequisites).FirstOrDefault();
    }

    bool CheckIfActionDoable(ActionBase action, Agent agent)
    {
        if(action.Prerequisites == null)
        {
            return true;
        }
        if (!action.Prerequisites.Except(agent.AquiredPrerequisites).Any())
        {
            return true;
        }
        //bool Doable = false;
        //
        //foreach (string p in action.Prerequisites)
        //{
        //    foreach (string ap in agent.AquiredPrerequisites)
        //    {
        //        if (ap == p)
        //        {
        //            Doable = true;
        //        }
        //    }
        //}

        return false;
    }
}
