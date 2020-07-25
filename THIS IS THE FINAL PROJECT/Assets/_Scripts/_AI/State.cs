using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public Action[] actions;
    public int cost;

    public abstract bool evaluate(FSM fsm);
}
