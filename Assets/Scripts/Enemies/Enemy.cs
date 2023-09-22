using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private float _searchDuration;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _attackDuration;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    [SerializeField] private HealthBar _healthBar;

    private EnemyStationBehaviour _stationBehaviour;

    public int Damage => _damage;
    public float AttackDuration => _attackDuration;
    public float SearchDuration => _searchDuration;
    public float chaseSpeed => _chaseSpeed;
    public bool IsEnemyFinded { get; private set; }
    
    public void Init()
    {
        _stationBehaviour = new EnemyStationBehaviour(this);
        _healthBar.Init(_health);
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
        _healthBar.UpdateSlider(_health);
    }
    private void FixedUpdate()
    {
        _stationBehaviour.Action();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            IsEnemyFinded = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            IsEnemyFinded = false;
        }
    }

    
}
