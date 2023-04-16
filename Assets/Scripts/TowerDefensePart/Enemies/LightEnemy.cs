using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : BaseEnemy
{
    protected override void UpdateStats()
    {
        Speed = BasicSpeed;
        Health = BasicHealth;
    }
}
