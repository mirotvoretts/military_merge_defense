using System;
using Random = UnityEngine.Random;

public class Client
{
    public event Action ReachedEndOfQueue;

    public Materials.Material RequestedResource { get; }
    
    public Client()
    {
        RequestedResource = GetRandomMaterial();
    }

    private Materials.Material GetRandomMaterial()
    {
        var resourceIndex = Random.Range(0, Materials.Sequence.Count - 1);

        return Materials.Sequence[resourceIndex];
    }

    public void InvokeOnReachedEndOfQueue()
    {
        ReachedEndOfQueue?.Invoke();
    }
}