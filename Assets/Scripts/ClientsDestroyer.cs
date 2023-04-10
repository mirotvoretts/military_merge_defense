using UnityEngine;

public class ClientsDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<ClientView>(out _))
            Destroy(col.gameObject);
    }
}
