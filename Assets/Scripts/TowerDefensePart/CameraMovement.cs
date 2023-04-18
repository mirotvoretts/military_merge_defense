using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _boundaries;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraSpeed = 0.2f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.down);
        }
    }

    private void Move(Vector3 direction)
    {
        direction *= _cameraSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3
        (
            Mathf.Clamp(transform.position.x + direction.x, _boundaries.bounds.min.x, _boundaries.bounds.max.x),
            Mathf.Clamp(transform.position.y + direction.y, _boundaries.bounds.min.y, _boundaries.bounds.max.y),
            transform.position.z
        );
        transform.position = newPosition;
        newPosition = _camera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
