using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
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
    }

    private void UpdateLabel()
    {
        _label.text = Value.ToString();
    }
    
    public static void OnSell(Product product)
    {
        Value += product.Price;
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
}