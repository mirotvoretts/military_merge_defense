using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private TMP_Text _waveText;
    [SerializeField] private TMP_Text _enemyText;
    [SerializeField] private TMP_Text _timerText;
    private static int s_wave; 
    private int _enemyCount, _waveTimer;

    public static Action OnWaveChanged;
    public static int Wave
    {
        get => s_wave; 
        private set 
        {
            s_wave = value;
            OnWaveChanged?.Invoke();
        }
    }

    public int EnemyCount
    {
        get => _enemyCount;
        private set
        {
            _enemyCount = value;
            _enemyText.text = _enemyCount.ToString();
        }
    }

    private void Start()
    {
        _enemyFactory.OnEnemySpawned += ListenEnemyDeath;
        OnWaveChanged += () => _waveText.text = "Волна " + Wave;
        Wave = 0;
        StartCoroutine(StartWave(10));
    }

    private void ListenEnemyDeath(BaseEnemy enemy)
    {
        enemy.OnDied += (enemy) =>
        {
            EnemyCount--;
            if(EnemyCount == 0)
            {
                StartCoroutine(StartWave(20));
            }
        };
    }

    private IEnumerator StartWave(int delay)
    {
        Wave++;
        EnemyCount = 10 + 5 * (Wave - 1);
        _waveTimer = delay;
        for (;_waveTimer >= 0; _waveTimer--)
        {
            _timerText.text = _waveTimer.ToString();
            yield return new WaitForSeconds(1);
        }

        _enemyFactory.SpawnEnemy(EnemyCount);
    }

    public void SkipWaiting()
    {
        _waveTimer = 1;
    }
}
