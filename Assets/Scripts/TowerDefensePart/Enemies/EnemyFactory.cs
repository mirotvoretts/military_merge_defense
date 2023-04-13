using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] protected RouteMark[] RouteMarks;
    public BaseEnemy enemyPrefab;

    private void Start()
    {
        //Instantiate(enemyPrefab, position: transform.position, Quaternion.Euler(0,0,0)).Init(RouteMarks);
    }

    public void SpawnEnemy(int count)
    {
        StartCoroutine(SpawnEnemy(count, 3));
    }

    private IEnumerator SpawnEnemy(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, position: transform.position, Quaternion.Euler(0, 0, 0)).Init(RouteMarks);
            yield return new WaitForSeconds(delay);
        }
    }
}
