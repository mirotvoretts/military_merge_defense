using System.Collections;
using UnityEngine;

public class DefaultTower : BaseTower
{

    protected override IEnumerator Attack()
    {
        while(true)
        {
            float reload = 0;
            if(CurrentEnemy != null)
            {
                TowerGun.GunAnimator.SetTrigger("OnFire");
                CurrentEnemy.TakeDamage(Damage);
                reload = 60/FireRate;
            }
            yield return new WaitForSeconds(reload);
        }
    }

    protected override void UpdateStats()
    {
        FireRate = BasicFireRate + 1 * UpgradeSystem.FireRateMod;
        Damage = BasicDamage + 0.7f * UpgradeSystem.DamageMod;
    }
}
