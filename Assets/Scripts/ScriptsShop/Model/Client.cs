using System;
using Random = UnityEngine.Random;

public class Client
{
    public event Action ProductReceived;
    public void InvokeOnProductReceived() => ProductReceived?.Invoke();

    public Product RequestedProduct { get; }

    private readonly ProductsData _productsData;
    
    public Client(ProductsData productsData)
    {
        _productsData = productsData;
        RequestedProduct = GetRandomProduct();
    }

    private Product GetRandomProduct()
    {
        var products = _productsData.Sequence;
        var productIndex = Random.Range(0, products.Count);

        return (Product)_productsData.Sequence[productIndex];
    }
}