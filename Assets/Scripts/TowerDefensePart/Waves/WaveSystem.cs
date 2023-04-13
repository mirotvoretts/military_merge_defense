using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private TMP_Text _waveText;
    private int _wave;

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
        OnWaveChanged += () => _waveText.text = Wave.ToString();
        Wave = 1;
        _enemyFactory.SpawnEnemy(Wave * 3);
    }
}
