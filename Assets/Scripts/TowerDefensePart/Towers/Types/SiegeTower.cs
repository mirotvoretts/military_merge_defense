using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeTower : BaseTower
{
    [SerializeField] private float _stunDuration;
    [SerializeField] private int _stunChance;

    protected override IEnumerator Attack()
    {
        while (true)
        {
            float reload = 0;
            if (CurrentEnemy != null)
            {
                if(Random.Range(0,100) < _stunChance)
                {
                    StartCoroutine(StunEnemy());
                }
                CurrentEnemy.TakeDamage(BasicDamage);
                reload = 60 / FireRate;
                TowerGun.GunAnimator.SetTrigger("OnFire");
            }
            yield return new WaitForSeconds(reload);
        }
    }

    private IEnumerator StunEnemy()
    {
        CurrentEnemy.Speed = 0;
        yield return new WaitForSeconds(_stunDuration);
        if(CurrentEnemy != null)
            CurrentEnemy.UpdateStats();
    }

    protected override void UpdateStats()
    {
        FireRate = BasicFireRate + 0.5f * UpgradeSystem.FireRateMod;
        Damage = BasicDamage + UpgradeSystem.DamageMod;
    }
}
