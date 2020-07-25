using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public int cost;
    public float Range;

    public abstract bool use(FSM fsm);

    public abstract int getCost(FSM fsm);
}
