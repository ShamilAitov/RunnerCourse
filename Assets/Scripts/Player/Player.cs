using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealtChanged;
    public event UnityAction Died;
    private int _minHealth = 0;
    private int _maxHealth;

    private void Start()
    {
        HealtChanged?.Invoke(_health);
        _maxHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealtChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Die();
        }
    }

    public void IncreaseHealth(int replenishingHealth)
    {
        if (_health < _maxHealth) 
        {
            _health += replenishingHealth;
            HealtChanged?.Invoke(_health);
        }
        
    }

    private void Die()
    {
        Died?.Invoke();
    }


}
