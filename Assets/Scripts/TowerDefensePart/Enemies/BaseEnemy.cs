using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Transform Body;
    [SerializeField] protected Image HealthBar;


    protected const float MaxSpeed = 25;
    [SerializeField] protected float BasicSpeed = 1f;
    [SerializeField] protected float BasicHealth = 10f;
    [HideInInspector]public float Speed;

    protected float Health;
    protected RouteMark[] RouteMarks;
    public IEnumerator RouteMovement;
    private Vector3 _movementDirection;
    private RouteMark _mark;

    public Action<BaseEnemy> OnDied;

    public void Init(RouteMark[] routeMarks)
    {
        RouteMarks = routeMarks;
        RouteMovement = MoveOnRoute();
        RouteMovement.MoveNext();
        UpdateStats();
        StartCoroutine("Movement");
    }

    protected IEnumerator MoveOnRoute()
    {
        foreach(var mark in RouteMarks)
        {
            _mark = mark;
            Body.LookAt2D(mark.transform);
            _movementDirection = (mark.transform.position - transform.position).normalized;
            yield return null;
        }
    }

    protected IEnumerator Movement()
    {
        while(true)
        {
            Body.LookAt2D(_mark.transform);
            _movementDirection = (_mark.transform.position - transform.position).normalized;
            Vector3 direction = _movementDirection * Time.deltaTime * Speed/3.3f;
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

    public void ForceKill()
    {
        HealthBar.fillAmount = 0;
        OnDied?.Invoke(this);
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        HealthBar.fillAmount = Health / BasicHealth;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        OnDied?.Invoke(this);
        gameObject.SetActive(false);
        Destroy(gameObject, 3);
    }
    public abstract void UpdateStats();
}
