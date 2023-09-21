using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Player _player;

    [SerializeField] private int _count;
    [SerializeField] private int _minRadius;
    [SerializeField] private int _maxRadius;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            Enemy enemy = _enemyFactory.Get(GetRandomEnemy());
            enemy.Init();
            enemy.transform.position = GetRandomPosition();
        }
        

    }
    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(_player.transform.position.x + _minRadius,
                                        _player.transform.position.x + _maxRadius + 1),
                           Random.Range(_player.transform.position.x + _minRadius,
                                        _player.transform.position.x + _maxRadius + 1));
    }
    private EnemyType GetRandomEnemy()
    {
        int n = Random.Range(1, 3); //Enemies count
        switch (n)
        {
            case 1:
                return EnemyType.Zombie;
            case 2:
                return EnemyType.Flesh;
            default:
                return EnemyType.Zombie;
        }
    }
}
