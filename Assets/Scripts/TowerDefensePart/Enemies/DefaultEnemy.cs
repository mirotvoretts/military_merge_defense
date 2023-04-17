using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : BaseEnemy
{
    public override void UpdateStats()
    {
        Speed = Mathf.Clamp(BasicSpeed + WaveSystem.Wave * 0.15f, 0, MaxSpeed - 5);
        Health = BasicHealth + WaveSystem.Wave * 1.5f;
    }
}
