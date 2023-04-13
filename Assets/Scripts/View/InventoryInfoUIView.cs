using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoUIView : UIView
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TextMeshProUGUI _materialsList;
    [SerializeField] private TextMeshProUGUI _productsList;

    public override void Show()
    {
        ResetButtonWith(_closeButton, Close);

        var materialsNames = new List<string> {Config.SteelName, Config.GunpowderName, Config.GlassName};
        var materialsCount = CountElementsByNames(materialsNames);

        var productsNames = new List<string> {Config.WeaponName, Config.ScopeName, Config.AmmoName};
        var productsCount = CountElementsByNames(productsNames);

        _materialsList.text =
            $"- {Config.SteelName}: {materialsCount[Config.SteelName]}x\n-" +
            $"{Config.GunpowderName}: {materialsCount[Config.GunpowderName]}x\n-" +
            $"{Config.GlassName}: {materialsCount[Config.GlassName]}x";

        _productsList.text =
            $"- {Config.WeaponName}: {productsCount[Config.WeaponName]}x\n-" +
            $"{Config.ScopeName}: {productsCount[Config.ScopeName]}x\n-" +
            $"{Config.AmmoName}: {productsCount[Config.AmmoName]}x";

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private Dictionary<string, int> CountElementsByNames(List<string> elementsNames)
    {
        var result = new Dictionary<string, int>(elementsNames.Count);

        foreach (var elementName in elementsNames)
            result[elementName] = CountItemInInventoryByName(elementName);

        return result;
    }

    private int CountItemInInventoryByName(string itemName)
    {
        return ShopView.Instance.Inventory.Count(item => item.Name == itemName);
    }
}