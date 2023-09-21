using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyFactory : BaseFactory
{
    [SerializeField] private Enemy _zombie;
    [SerializeField] private Enemy _flesh;
    //Add more 

    public Enemy Get(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Zombie:
                return Get(_zombie);
            case EnemyType.Flesh:
                return Get(_flesh);
            default:
                return null;
        }
    }
    private Enemy Get(Enemy prefab)
    {
        return CreateGameObjectInstance<Enemy>(prefab);
    }
}
