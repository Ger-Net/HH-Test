using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    private Inventory _inventory;
    private Weapon _weapon;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }
}
