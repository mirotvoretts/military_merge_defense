using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private int _startMoney = 0;
    public static int Value { get; private set; }

    public static event Action ValueChanged; 

    private void Awake()
    {
        ValueChanged += UpdateLabel;
    }

    private void Start()
    {
        Value = _startMoney;
        UpdateLabel();
        _enemyFactory.OnEnemySpawned += ListenEnemyDeath;
    }

    private void ListenEnemyDeath(BaseEnemy enemy)
    {
        enemy.OnDied += (enemy) =>
        {
            AddRandomMoney();
        };
    }


    private void UpdateLabel()
    {
        _label.text = Value.ToString();
    }
    
    public static void OnSell(Product product)
    {
        Value += product.Price + WaveSystem.Wave * 10;
        ValueChanged?.Invoke();
    }

    public static bool BuyAvailable(int price)
    {
        return Value >= price;
    }

    public static bool TryBuy(int price)
    {
        if(Value >= price)
        {
            Value -= price;
            ValueChanged?.Invoke();
            return true;
        }
        return false;
    }

    private void OnDestroy()
    {
        ValueChanged -= UpdateLabel;
    }

    private void AddRandomMoney()
    {
        Value = Value + UnityEngine.Random.Range(1, 10 + WaveSystem.Wave);
        ValueChanged?.Invoke();
    }
}