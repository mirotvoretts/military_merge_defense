using UnityEngine;

public class DefaultEnemy : BaseEnemy
{
    public override void UpdateStats()
    {
        Speed = Mathf.Clamp(BasicSpeed + WaveSystem.Wave * 0.25f, 0, MaxSpeed - 5);
        Health = BasicHealth + WaveSystem.Wave * 3f;
    }
}
