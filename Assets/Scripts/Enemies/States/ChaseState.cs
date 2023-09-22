using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    private Player _player;
    private Enemy _enemy;

    public ChaseState(Enemy enemy, Player player, IStateSwither stateSwither) : base(stateSwither)
    {
        _enemy = enemy;
        _player = player;
    }

    public override void Action()
    {
        if (!_enemy.IsEnemyFinded)
        {
            _stateSwitcher.SwitchState<IdleState>();
            return;
        }
        Vector2 direction = _player.transform.position - _enemy.transform.position;
        if(direction.y <= 0.5 && direction.y >= -0.5 && direction.x <= 0.5 && direction.x >= -0.5)
        {
            _stateSwitcher.SwitchState<AttackState>();
            return;
        }
        _enemy.transform.position += (Vector3)(direction.normalized * Time.deltaTime * _enemy.chaseSpeed);
    }

    
}
