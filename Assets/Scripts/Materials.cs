using System.Collections.Generic;

public static class Materials
{
    public static List<Material> Sequence { get; }

    static Materials()
    {
        Sequence = new List<Material> {new("Wood", 100), new("Stone", 150), new("Food", 200)};
    }

    public struct Material
    {
        public string Name { get; }
        public uint Price { get; }

        public Material(string name, uint price)
        {
            Name = name;
            Price = price;
        }
    }
}