using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class Items : ScriptableObject
{
    [SerializeField] protected List<Item> _sequence;
    public List<Item> Sequence => _sequence;

    [Serializable]
    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected string _name;
        [SerializeField] protected Sprite _icon;
        
        public string Name => _name;
    }
}
