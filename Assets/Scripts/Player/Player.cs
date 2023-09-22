using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : Singleton<Player>, IDamageble
{
    [SerializeField] private int _health;
    //[SerializeField] private float _shootDistance;
    [SerializeField] private HealthBar _healthBar;
    
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    [SerializeField] private Inventory _inventory;

    public int Health 
    { 
        get => _health; 
        set
        {
            if (100 - _health < value)
                _health = 100;
            else
                _health = value;
        }
    }

    private void Start()
    {
        _healthBar.Init(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Debug.LogAssertion("GameOver");
        }
        _healthBar.UpdateSlider(_health);
    }
    public void Shoot()
    {
        if(_inventory.Weapon == null)
            return;
        Vector2 enemyPos;

        if (_enemies.Count > 0)
            enemyPos = _enemies[0].transform.position;
        else
            enemyPos = transform.position;

        var hit = Physics2D.Raycast(transform.position, enemyPos - new Vector2(transform.position.x,transform.position.y), 100);
        Debug.DrawRay(transform.position, enemyPos - new Vector2(transform.position.x, transform.position.y), Color.red,1);
        if(hit.collider != null)
        {
            Debug.Log($"Attacking {hit.collider.gameObject}");

            if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                Debug.Log($"Attack {enemy.name}");
                _inventory.Weapon.Attack(enemy);
            }
        }
    }
    public void DeleteItem(int index)
    {
        _inventory.DeleteItem(index);
    }
    public void UseItem(int index)
    {
        _inventory.UseItem(index);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Add(enemy);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemies.Remove(enemy);
        }
    }
}
