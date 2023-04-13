using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    public static int Value { get; private set; }

    private static event Action ValueChanged; 

    private void Awake()
    {
        ValueChanged += UpdateLabel;
    }

    private void Start()
    {
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        _label.text = Value.ToString();
    }
    
    public static void OnSell(ProductsData.Product product)
    {
        Value += product.Price;
        ValueChanged?.Invoke();
    }

    private void OnDestroy()
    {
        ValueChanged -= UpdateLabel;
    }
}