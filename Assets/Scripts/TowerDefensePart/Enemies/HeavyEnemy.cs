using UnityEngine;

public class HeavyEnemy : BaseEnemy
{
    public override void UpdateStats()
    {
        Speed = Mathf.Clamp(BasicSpeed + WaveSystem.Wave * 0.2f, 0, MaxSpeed - 7);
        Health = BasicHealth + WaveSystem.Wave * 4f;
    }

    public override void TakeDamage(float damage)
    {
        damage *= 0.75f;
        Health -= damage;
        HealthBar.fillAmount = Health / BasicHealth;
        if (Health <= 0)
        {
            Die();
        }
    }
}
