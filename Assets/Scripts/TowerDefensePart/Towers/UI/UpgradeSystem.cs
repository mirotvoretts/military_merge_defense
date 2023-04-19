using System;
using TMPro;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private int _basicPrice;

    [SerializeField] private TMP_Text _fireRateLevelText;
    [SerializeField] private TMP_Text _fireRatePriceText;
    [SerializeField] private TMP_Text _damageLevelText;
    [SerializeField] private TMP_Text _damagePriceText;

    public static Action onUpgraded;
    private static float s_fireRateMod = 1, s_damageMod = 1;
    private static int s_fireRateLevel = 1, s_damageLevel = 1;
    private static int s_fireRatePrice, s_damagePrice;

    public static float FireRateMod
    { 
        get => s_fireRateMod; 
        private set 
        { 
            s_fireRateMod = value;
            onUpgraded?.Invoke();
        }
    }

    public static float DamageMod
    {
        get => s_damageMod;
        private set
        {
            s_damageMod = value;
            onUpgraded?.Invoke();
        }
    }

    private void Awake()
    {
        s_fireRatePrice = CalculatePrice(s_fireRateLevel);
        _fireRateLevelText.text = "Уровень: " + s_fireRateLevel;
        _fireRatePriceText.text = s_fireRatePrice.ToString();

        s_damagePrice = CalculatePrice(s_damageLevel);
        _damageLevelText.text = "Уровень: " + s_damageLevel;
        _damagePriceText.text = s_damagePrice.ToString();
    }

    public void BuyClick(int index)
    {
        if(index == 0)
        {
            if (!Score.TryBuy(s_fireRatePrice))
                return;

            FireRateMod = FireRateMod + 0.1f;
            s_fireRateLevel++;

            s_fireRatePrice = CalculatePrice(s_fireRateLevel);
            _fireRateLevelText.text = "Уровень: " + s_fireRateLevel;
            _fireRatePriceText.text = s_fireRatePrice.ToString();
        }
        else
        {
            if (!Score.TryBuy(s_damagePrice))
                return;

            DamageMod = DamageMod + 0.1f;
            s_damageLevel++;

            s_damagePrice = CalculatePrice(s_damageLevel);
            _damageLevelText.text = "Уровень: " + s_damageLevel.ToString();
            _damagePriceText.text = s_damagePrice.ToString();
        }
    }

    private int CalculatePrice(int level)
    {
        return level * _basicPrice;
    }
}
