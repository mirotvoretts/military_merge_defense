using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    [SerializeField] protected float BasicFireRate, BasicDamage;
    [SerializeField] protected uint TowerLevel;
    [SerializeField] protected Gun TowerGun;
    public uint Level { get => TowerLevel; }

    protected float FireRate, Damage;
    protected CircleCollider2D RangeCollider;
    protected Vector3 BasicRangeScale;
    protected List<BaseEnemy> Enemies;
    protected BaseEnemy CurrentEnemy;

    protected Action OnEnemyNoticed;
    protected Action OnEnemyLost;
    protected Action OnCurrentEnemyChoosed;
    protected Action OnCurrentEnemyLost;


    protected void Start()
    {
        Enemies = new List<BaseEnemy>();
        RangeCollider = GetComponent<CircleCollider2D>();
        BasicRangeScale = RangeCollider.transform.localScale;
        UpgradeSystem.onUpgraded += UpdateStats;
        UpdateStats();

        StartCoroutine("FollowEnemy");
        StartCoroutine("Attack");
        OnEnemyNoticed += () => ChooseEnemy();
        OnCurrentEnemyLost += () => ChooseEnemy();
    }

    protected virtual void ChooseEnemy()
    {
        if (CurrentEnemy == null && Enemies.Count > 0)
        {
            CurrentEnemy = Enemies[0];
            OnCurrentEnemyChoosed?.Invoke();
        }
    }

    public void AddTargetEnemy(BaseEnemy enemy)
    {
        Enemies.Add(enemy);
        OnEnemyNoticed?.Invoke();
    }

    public void RemoveTargetEnemy(BaseEnemy enemy)
    {
        Enemies.Remove(enemy);
        OnEnemyLost?.Invoke();

        if (enemy == CurrentEnemy)
        {
            CurrentEnemy = null;
            OnCurrentEnemyLost?.Invoke();
        }
    }

    protected abstract IEnumerator Attack();
    private IEnumerator FollowEnemy()
    {
        while(true) 
        {
            if(CurrentEnemy != null)
                TowerGun.Body.LookAt2D(CurrentEnemy.transform);
            yield return new WaitForSeconds(0.01f);
        }
    }
    protected abstract void UpdateStats();
}
