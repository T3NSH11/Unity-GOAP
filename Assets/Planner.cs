using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Planner
{
    public List<ActionBase> Actions = new List<ActionBase>();
    List<string> AquiredPrereqs = new List<string>();

    // check if action is doable when GetNextAction(goal) if not doable get prereq in result action that isnt in aprereqs then run GetNextAction(result)
    public Stack<ActionBase> GetActionList(string Goal, Agent agent)
    {
        Stack<ActionBase> ActionList = new Stack<ActionBase>();

        ActionBase GoalAction;
        GoalAction = GetNextAction(Goal, agent);
        ActionBase currentAction = GoalAction;

        foreach (string s in agent.AquiredPrerequisites)
        {
            AquiredPrereqs.Add(s);
        }

        foreach (string s in World_States.AquiredPrerequisites)
        {
            AquiredPrereqs.Add(s);
        }

        if (CheckIfActionDoable(currentAction, agent))
        {
            ActionList.Push(currentAction);
            return ActionList;
        }

        ActionList.Push(GoalAction);

        while (!CheckIfActionDoable(currentAction, agent))
        {
            ActionBase Observing = currentAction;

            while (GetRequiredPrereqs(Observing, agent).Count != 0 || GetRequiredPrereqs(Observing, agent) == null)
            {
                currentAction = GetNextAction(GetRequiredPrereqs(Observing, agent).FirstOrDefault(), agent);

                foreach (string s in currentAction.Effects)
                {
                    AquiredPrereqs.Add(s);
                }
                ActionList.Push(currentAction);
            }
        }

        AquiredPrereqs.Clear();
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
        return new GoToRecharge();
    }

    List<string> GetRequiredPrereqs(ActionBase action, Agent agent)
    {
        List<string> prereqs = new List<string>(action.Prerequisites.Except(AquiredPrereqs));
        return prereqs;
        //return (List<string>)action.Prerequisites.Except(agent.AquiredPrerequisites);
    }

    bool CheckIfActionDoable(ActionBase action, Agent agent)
    {
        if (!action.Prerequisites.Except(AquiredPrereqs).Any() || action.Prerequisites == null)
        {
            return true;
        }
        else
            return false;

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
    }
}
