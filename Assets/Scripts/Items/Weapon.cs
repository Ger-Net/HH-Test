using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Weapon : ItemData
{
    [SerializeField] private int _damage;
    [SerializeField] private int _magazine;

    public void Reload(int value)
    {
        _magazine = value;
    }
    public void Attack(Enemy enemy)
    {
        _magazine--;
        enemy.TakeDamage(_damage);
    }
}
