using System;
using Random = UnityEngine.Random;

public class Client
{
    public event Action ReachedEndOfQueue;
    public void InvokeOnReachedEndOfQueue() => ReachedEndOfQueue?.Invoke();
    
    public event Action ProductReceived;
    public void InvokeOnProductReceived() => ProductReceived?.Invoke();

    public ProductsData.Product RequestedProduct { get; }

    private readonly ProductsData _productsData;
    
    public Client(ProductsData productsData)
    {
        _productsData = productsData;
        RequestedProduct = GetRandomProduct();
    }

    private ProductsData.Product GetRandomProduct()
    {
        var products = _productsData.GetProducts();
        var productIndex = Random.Range(0, products.Count);

        return _productsData.GetProducts()[productIndex];
    }
}