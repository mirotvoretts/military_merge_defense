using UnityEngine;

public class ClientsDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ClientView>(out _))
            Destroy(collision.gameObject);
    }
}
