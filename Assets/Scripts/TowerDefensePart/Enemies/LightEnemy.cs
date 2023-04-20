using UnityEngine;

public class LightEnemy : BaseEnemy
{
    public override void UpdateStats()
    {
        Speed = Mathf.Clamp(BasicSpeed + WaveSystem.Wave * 0.5f, 0, MaxSpeed);
        Health = BasicHealth + WaveSystem.Wave * 2f;
    }

    public override void TakeDamage(float damage)
    {
        if (Random.Range(0, 100) < 10)
            return;
        Health -= damage;
        HealthBar.fillAmount = Health / BasicHealth;
        if (Health <= 0)
        {
            Die();
        }
    }
}
