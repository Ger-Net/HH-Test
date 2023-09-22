using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SearchState : BaseState
{
    private Enemy _enemy;

    private float _timeBetweenSearch = 1;
    private bool _isSearching = false;

    public SearchState(Enemy enemy,IStateSwither stateSwither) : base(stateSwither)
    {
        _enemy = enemy;
    }

    public override void Action()
    {
        if (_enemy.IsEnemyFinded)
        {
            _stateSwitcher.SwitchState<ChaseState>();
            _enemy.gameObject.transform.DOKill();
            _isSearching = false;
            return;
        }
        if (_isSearching)
            return;
        if (_timeBetweenSearch > 0)
        {
            _timeBetweenSearch -= Time.deltaTime;
        }
        else
        {
            _isSearching = true;
            var transform = _enemy.gameObject.transform;
            transform.DOMove(new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f)), _enemy.SearchDuration).SetEase(Ease.Linear).OnComplete(() => _isSearching = false); 
        }
    }
    
}
