using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Weapon : Item
{
    [SerializeField] private int _damage;
    public override void Use()
    {
    }
}
