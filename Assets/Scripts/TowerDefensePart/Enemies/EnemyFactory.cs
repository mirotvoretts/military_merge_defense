using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] protected RouteMark[] RouteMarks;
    public BaseEnemy enemyPrefab;

    private void Start()
    {
        Instantiate(enemyPrefab, position: transform.position, Quaternion.Euler(0,0,0)).Init(RouteMarks);
    }
}
