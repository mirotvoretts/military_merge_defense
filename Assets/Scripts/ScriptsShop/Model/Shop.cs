using System.Collections.Generic;

public class Shop
{
    public List<Item> Inventory { get; }
    
    private static Shop _instance;

    private Shop()
    {
        Inventory = new List<Item>();
    }

    public static Shop GetInstance()
    {
        return _instance ??= new Shop();
    }

    public void PushToInventory(CraftMaterial material)
    {
        Inventory.Add(material);
    }
}