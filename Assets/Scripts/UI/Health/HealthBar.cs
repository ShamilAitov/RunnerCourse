using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealtChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealtChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHeart = value - _hearts.Count;

            for (int i = 0; i < createHeart; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count != 0)
        {
            int deleteHeart = _hearts.Count - value;

            for (int i = 0; i < deleteHeart; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
