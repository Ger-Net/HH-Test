using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : ScriptableObject
{
    [SerializeField] private Texture2D _icon;
    public Texture2D Icon => _icon;
    public abstract void Use();
}
