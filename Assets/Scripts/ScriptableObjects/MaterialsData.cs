using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "New Materials Data", menuName = "Materials Data", order = 53)]
public class MaterialsData : Items
{
    [CreateAssetMenu(fileName = "New Material", menuName = "Craft Material", order = 54)]
    public class Material : Item
    {
        public bool ContainsIn(IEnumerable<Item> materials)
        {
            return materials.Contains(this);
        }
    }
}