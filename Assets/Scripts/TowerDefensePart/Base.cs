using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private int _maxHealth;

    private int _health;
    private void Awake()
    {
        _health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
        {
            TakeDamage();
            enemy.ForceKill();
        }
    }

    private void TakeDamage()
    {
        _health--;
        _healthBar.fillAmount = _health / (float)_maxHealth;
        if(_health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
