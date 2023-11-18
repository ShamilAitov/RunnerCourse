using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthRecoveryBonus : MonoBehaviour
{
    [SerializeField] private int _numberHealthRecovery;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.IncreaseHealth(_numberHealthRecovery);
        }

        Destoy();
    }

    private void Destoy()
    {
        gameObject.SetActive(false);
    }
}
