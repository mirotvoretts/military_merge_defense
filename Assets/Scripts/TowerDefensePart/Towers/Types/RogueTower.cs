using System.Collections;
using UnityEngine;

public class RogueTower : BaseTower
{
    [SerializeField] private float _critModifier;
    [SerializeField] private int _critChance;
    protected override IEnumerator Attack()
    {
        while (true)
        {
            float reload = 0;
            if (CurrentEnemy != null)
            {
                float damage = Damage;
                if (Random.Range(0, 100) < _critChance)
                {
                    damage *= _critModifier;    
                }
                TowerGun.GunAnimator.SetTrigger("OnFire");
                CurrentEnemy.TakeDamage(damage);
                reload = 60 / FireRate;
            }
            yield return new WaitForSeconds(reload);
        }
    }

    protected override void UpdateStats()
    {
        FireRate = BasicFireRate + 1.2f * UpgradeSystem.FireRateMod;
        Damage = BasicDamage + 0.5f * UpgradeSystem.DamageMod;
    }
}
