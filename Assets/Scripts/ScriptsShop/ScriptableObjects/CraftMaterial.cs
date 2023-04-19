using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft Material", menuName = "Craft Material", order = 54)]
public class CraftMaterial : Item
{
    public bool ContainsIn(IEnumerable<Item> materials)
    {
        return materials.Contains(this);
    }
}
