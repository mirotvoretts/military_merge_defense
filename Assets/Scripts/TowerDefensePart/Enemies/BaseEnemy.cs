using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float Speed = 1f;
    protected RouteMark[] RouteMarks;
    public IEnumerator RouteMovement;
    private Vector3 _movementDirection;

    public void Init(RouteMark[] routeMarks)
    {
        RouteMarks = routeMarks;
        RouteMovement = MoveOnRoute();
        RouteMovement.MoveNext();
        StartCoroutine("Movement");
    }

    protected IEnumerator MoveOnRoute()
    {
        foreach(var mark in RouteMarks)
        {
            transform.LookAt2D(mark.transform);
            _movementDirection = (mark.transform.position - transform.position).normalized;
            yield return null;
        }
    }

    protected IEnumerator Movement()
    {
        while(true)
        {
            Vector3 direction = _movementDirection * Speed/1000;
            transform.position += direction;
            yield return null;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<BaseTower>(out BaseTower tower))
        {
            tower.AddTargetEnemy(this);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BaseTower>(out BaseTower tower))
        {
            tower.RemoveTargetEnemy(this);
        }
    }
}
