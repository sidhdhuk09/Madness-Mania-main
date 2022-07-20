using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyone : MonoBehaviour
{

    [SerializeField]
    private float Speed = 25f, rotationSpeed = 180f;
    [SerializeField]
    private bool playerCar = false;
    [SerializeField]
    private GameObject explosion;
    private Rigidbody myBody;
    private float translation, rotation;


    private GameObject target;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }





    // private int Current_Angle;



    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }


    private void Update()
    {

        if (!playerCar && !target)
            return;
        if (playerCar)
        {
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
            {
                rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
                translation = Input.GetAxis("Vertical") * Speed;

            }
            else
            {
                rotation = 0f;
                translation = 0f;
            }
        }
        else
        {
            Vector3 targetDirection = transform.position - target.transform.position;
            targetDirection.Normalize();

            rotation = Vector3.Cross(targetDirection, transform.forward).y;

        }
    }

    void FixedUpdate()
    {
        if (playerCar)
        {
            myBody.velocity = transform.forward * translation;
            transform.Rotate(Vector3.up * rotation);
        }
        else
        {
            myBody.angularVelocity = rotationSpeed * rotation * new Vector3(0, 1, 0);
            myBody.velocity = transform.forward * Speed;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        //When collision with car
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        //When Collides with tower
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(gameObject);
        }
        //When one enemy collides with another enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}