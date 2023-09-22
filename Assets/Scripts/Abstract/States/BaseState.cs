using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{

    protected readonly IStateSwither _stateSwitcher;
    public BaseState(IStateSwither stateSwither)
    {
        _stateSwitcher = stateSwither;
    }
    
    public abstract void Action();
}
