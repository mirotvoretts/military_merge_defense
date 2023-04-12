using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : BaseEnemy
{
    protected override void UpdateStats()
    {
        Speed = BasicSpeed;
        Health = BasicHealth;
    }
}
