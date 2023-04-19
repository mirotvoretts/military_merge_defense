using UnityEngine;

public class RouteMark : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BaseEnemy enemy))
        {
            enemy.RouteMovement.MoveNext();
        }
    }
}
