using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private float _timeReamaining = 3;
    public bool IsIdleEnd { get; private set; }
    public IdleState(IStateSwither stateSwither) : base(stateSwither)
    {
    }

    public override void Action()
    {
        if(_timeReamaining > 0)
        {
            _timeReamaining -= Time.deltaTime;
        }
        else
        {
            _stateSwitcher.SwitchState<SearchState>();
        }
    }
}
