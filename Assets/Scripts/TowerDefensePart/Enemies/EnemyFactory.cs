using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] protected RouteMark[] RouteMarks;
    public BaseEnemy enemyPrefab;

    public Action<BaseEnemy> OnEnemySpawned;

    private void Start()
    {
    }

    public void SpawnEnemy(int count)
    {
        StartCoroutine(SpawnEnemy(count, 2));
    }

    private IEnumerator SpawnEnemy(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            BaseEnemy enemy = Instantiate(enemyPrefab, position: transform.position, Quaternion.Euler(0, 0, 0));
            enemy.Init(RouteMarks);
            OnEnemySpawned?.Invoke(enemy);
            Debug.Log($"Враг {i}");
            yield return new WaitForSeconds(delay);
        }
    }
}
