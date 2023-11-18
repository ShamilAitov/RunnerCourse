using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
