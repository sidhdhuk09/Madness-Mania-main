using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabs;
    [SerializeField]
    private Queue<GameObject> pools = new Queue<GameObject>();
    [SerializeField]
    private int poolSize = 5;
    private void Start()
    {
        for(int i=0; i < poolSize; i++)
        {
            GameObject cars = Instantiate(prefabs);
            pools.Enqueue(cars);
            cars.SetActive(false);
        }
    }
    public GameObject getCars()
    {
        if (pools.Count > 0)
        {
            GameObject cars = pools.Dequeue();
            cars.SetActive(true);
            return cars;
        }
        else
        {
            Vector3 spawnpos = new Vector3(Random.Range(-100, 100), 10, Random.Range(-100, 100));
            GameObject cars = Instantiate(prefabs);
            return cars;
        }
    }
    public void ReturnToPool(GameObject cars)
    {
        pools.Enqueue(cars);
        cars.SetActive(false);

    }
}
