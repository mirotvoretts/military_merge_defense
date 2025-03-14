using System;
using System.Collections;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] protected RouteMark[] RouteMarks;
    public BaseEnemy[] enemyPrefabs;

    public Action<BaseEnemy> OnEnemySpawned;

    public void SpawnEnemy(int count)
    {
        StartCoroutine(SpawnEnemy(count, 2));
    }

    private IEnumerator SpawnEnemy(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            BaseEnemy enemy = Instantiate(enemyPrefabs.GetRandomValue(), position: transform.position, Quaternion.Euler(0, 0, 0));
            enemy.Init(RouteMarks);
            OnEnemySpawned?.Invoke(enemy);
            yield return new WaitForSeconds(delay);
        }
    }
}
