using System.Collections;
using System.Collections.Generic;
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
                Debug.Log("Ïèó");
                reload = BasicFireRate;
            }
            yield return new WaitForSeconds(reload);
        }
    }

    protected override void UpdateStats()
    {
    }
}
