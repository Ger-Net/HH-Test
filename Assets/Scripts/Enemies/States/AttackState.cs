using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private Player _player;
    private Enemy _enemy;

    private bool _isAttacking;
    public AttackState(Enemy enemy, Player player, IStateSwither stateSwither) : base(stateSwither)
    {
        _enemy = enemy;
        _player = player;
    }

    public override void Action()
    {
        if (_isAttacking)
            return;
        Vector2 direction = _player.transform.position - _enemy.transform.position;
        if ((direction.y <= 0.5 && direction.y >= -0.5 && direction.x <= 0.5 && direction.x >= -0.5) == false)
        {
            _stateSwitcher.SwitchState<ChaseState>();
            return;
        }
        Attack();
        
    }
    private void Attack()
    {
        _isAttacking = true;
        _player.TakeDamage(_enemy.Damage);
        _enemy.transform.DOShakePosition(_enemy.AttackDuration, 0.1f, 5, 1).OnComplete(() => _isAttacking = false);
        
    }
   
}
