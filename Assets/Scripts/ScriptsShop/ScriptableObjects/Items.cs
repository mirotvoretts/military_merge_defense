using System.Collections.Generic;
using UnityEngine;

public abstract class Items : ScriptableObject
{
    [SerializeField] protected List<Item> _sequence;
    public List<Item> Sequence => _sequence;
}
