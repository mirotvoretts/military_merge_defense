using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _boundaries;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>(); 
    }
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
        direction /= 3.8f;
        Vector3 newPosition = new Vector3
        (
            Mathf.Clamp(_transform.position.x + direction.x, _boundaries.bounds.min.x, _boundaries.bounds.max.x),
            Mathf.Clamp(_transform.position.y + direction.y, _boundaries.bounds.min.y, _boundaries.bounds.max.y),
            _transform.position.z
        );
        _transform.position = newPosition;
    }
}
