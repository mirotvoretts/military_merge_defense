using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueTower : BaseTower
{
    protected override IEnumerator Attack()
    {
        while (true)
        {
            float reload = 0;
            if (CurrentEnemy != null)
            {
                CurrentEnemy.TakeDamage(BasicDamage);
                reload = BasicFireRate;
                TowerGun.GunAnimator.SetTrigger("OnFire");
            }
            yield return new WaitForSeconds(reload);
        }
    }

    protected override void UpdateStats()
    {
    }
}
