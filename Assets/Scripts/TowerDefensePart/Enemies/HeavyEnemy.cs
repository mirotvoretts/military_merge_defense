using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : BaseEnemy
{
    protected override void UpdateStats()
    {
        Speed = BasicSpeed;
        Health = BasicHealth;
    }
}
