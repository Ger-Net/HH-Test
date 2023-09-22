using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStationBehaviour: IStateSwither
{
    private BaseState _currentState;
    private List<BaseState> _allStates;

    public EnemyStationBehaviour(Enemy enemy)
    {
        _allStates = new List<BaseState>()
        {
            new IdleState(this),
            new SearchState(enemy,this),
            new ChaseState(enemy,Player.Instance,this),
            new AttackState(enemy,Player.Instance,this)
        };
        SwitchState<IdleState>();
    }

    
    public void Action()
    {
        _currentState.Action();
    }
    public void SwitchState<T>() where T : BaseState
    {
        var state = _allStates.FirstOrDefault(t => t is T);
        _currentState = state;
    }
}
