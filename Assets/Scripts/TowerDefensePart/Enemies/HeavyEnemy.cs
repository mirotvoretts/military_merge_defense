using UnityEngine;

public class HeavyEnemy : BaseEnemy
{
    public override void UpdateStats()
    {
        Speed = Mathf.Clamp(BasicSpeed + WaveSystem.Wave * 0.1f, 0, MaxSpeed - 10);
        Health = BasicHealth + WaveSystem.Wave * 2f;
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
