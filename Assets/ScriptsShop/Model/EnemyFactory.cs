using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public event Action EnemyDied;

    public void InvokeEnemyDied()
    {
        EnemyDied?.Invoke();
    }
}