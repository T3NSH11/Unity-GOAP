using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ActionBase
{
    public abstract List<string> Prerequisites { get; set;}
    public abstract List<string> Effects { get; set; }

    public abstract void Setup();
    public abstract string DoAction(Agent agent);
}
