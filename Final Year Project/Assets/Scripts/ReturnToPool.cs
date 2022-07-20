using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    private ObjectPooling poolthisobject;
    private void Start()
    {
        poolthisobject = FindObjectOfType<ObjectPooling>();
    }
    private void OnDisable()
    {
        if(poolthisobject != null)
        {
            poolthisobject.ReturnToPool(this.gameObject);
        }
    }
}
