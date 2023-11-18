using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected List<GameObject> _enemyPool = new List<GameObject>();
    protected List<GameObject> _healthBonusPool = new List<GameObject>();

    protected void Initialize(GameObject[] prefabs, List<GameObject> pool)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);

            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);

            spawned.SetActive(false);
            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result, List<GameObject> pool)
    {
        result = pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}