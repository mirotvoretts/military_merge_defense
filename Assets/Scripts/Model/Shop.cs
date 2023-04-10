using System.Collections.Generic;

public class Shop
{
    public List<Materials.Material> Inventory { get; }
    
    private static Shop _instance;

    private Shop()
    {
        Inventory = new List<Materials.Material>();
    }

    public static Shop GetInstance()
    {
        return _instance ??= new Shop();
    }

    public void PushToInventory(Materials.Material material)
    {
        Inventory.Add(material);
    }
}