using System.Collections.Generic;

public class Shop
{
    public List<Items.Item> Inventory { get; }
    
    private static Shop _instance;

    private Shop()
    {
        Inventory = new List<Items.Item>();
    }

    public static Shop GetInstance()
    {
        return _instance ??= new Shop();
    }

    public void PushToInventory(MaterialsData.Material material)
    {
        Inventory.Add(material);
    }
    
    public void RemoveFromInventory(MaterialsData.Material material)
    {
        Inventory.Remove(material);
    }
}