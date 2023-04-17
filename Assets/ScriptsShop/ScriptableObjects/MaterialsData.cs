using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "New Materials Data", menuName = "Materials Data", order = 53), System.Serializable]
public class MaterialsData : Items
{
    [CreateAssetMenu(fileName = "New Material", menuName = "Craft Material", order = 54), System.Serializable]
    public class Material : Item
    {
        public bool ContainsIn(IEnumerable<Item> materials)
        {
            return materials.Contains(this);
        }
    }
}