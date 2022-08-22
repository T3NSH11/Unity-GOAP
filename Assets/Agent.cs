using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Agent : MonoBehaviour
{
    public float ChargeStatus;
    public GameObject RechargeStation;
    Planner planner;

    public List<string> AquiredPrerequisites;
    ActionBase CurrentState;

    private void Awake()
    {
        planner = new Planner();
        planner.Actions.Add(new GoToRecharge());
        planner.Actions.Add(new ResetAction());
        planner.Actions.Add(new CleanAction());
        planner.Actions.Add(new RechargeAction());

        foreach(ActionBase a in planner.Actions)
        {
            a.Setup();
        }
    }

    void Start()
    {
        CurrentState = new GoToRecharge();
        foreach (ActionBase a in planner.GetActionList("World Clean", this))
        {
            Debug.Log(a);
        }
    }
    
    void Update()
    {
        //if (AquiredPrerequisites.Contains("Working"))
        //{
        //    planner.GetActionList("World Clean", this);
        //}
        //else
        //{
        //    planner.GetActionList("Working", this);
        //}
    }
}
