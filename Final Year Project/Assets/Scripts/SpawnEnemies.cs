using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
   

  
    public float timeToSpawn = 5f;

    

    private Transform spawnPoint;
    private float timeSinceSpawn = 0f;
    [SerializeField]
    private ObjectPooling objectpool;

    

    private void Awake()
    {
        spawnPoint = GetComponent<Transform>();
    }

    // Use this for initialization
     void Start()
    {
    }
    void start()

    {
        objectpool=FindObjectOfType<ObjectPooling>();
    }
    // Update is called once per frame
    private void Update()
    {
       Vector3 spawnpos=new Vector3(Random.Range(-100,100),10,Random.Range(-100,100));
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > timeToSpawn)
        {
            // Spawn an enemy exactly on the spawn point
            GameObject newCar = objectpool.getCars();
            newCar.transform.position=this.transform.position;
            timeSinceSpawn = 0f;
        }
        
    }
    

    
}