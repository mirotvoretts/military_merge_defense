using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private TMP_Text _waveText;
    [SerializeField] private TMP_Text _timerText;
    private int _wave, _enemyCount, _waveTimer;

    public Action OnWaveChanged;
    public int Wave
    {
        get => _wave; 
        private set 
        {
            _wave = value;
            OnWaveChanged?.Invoke();
        }
    }

    private void Start()
    {
        _enemyFactory.OnEnemySpawned += ListenEnemyDeath;
        OnWaveChanged += () => _waveText.text = Wave.ToString();
        Wave = 0;
        StartCoroutine(StartWave(10));
    }

    private void ListenEnemyDeath(BaseEnemy enemy)
    {
        enemy.OnDied += (enemy) =>
        {
            _enemyCount--;
            if(_enemyCount == 0)
            {
                StartCoroutine(StartWave(20));
            }
        };
    }

    private IEnumerator StartWave(int delay)
    {
        Wave++;
        _enemyCount = 10 + 5 * (Wave - 1);
        _waveTimer = delay;
        for (;_waveTimer >= 0; _waveTimer--)
        {
            _timerText.text = _waveTimer.ToString();
            yield return new WaitForSeconds(1);
        }

        _enemyFactory.SpawnEnemy(_enemyCount);
    }

    public void SkipWaiting()
    {
        _waveTimer = 1;
    }
}
