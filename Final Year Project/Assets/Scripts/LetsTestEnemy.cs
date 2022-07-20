using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsTestEnemy : MonoBehaviour
{
    
    public WheelCollider wheelFR;
    public WheelCollider wheelFL;
    public WheelCollider wheelBR;
    public WheelCollider wheelBL;
    public GameObject wheelFRg;
    public GameObject wheelFLg;
    public GameObject wheelBRg;
    public GameObject wheelBLg;
    public float throttle;
    public float drivingforce;
    public float wheelangle;
    public Rigidbody rb;
    public Vector3 center;
    public Vector3 wheelpos;
    public Quaternion wheelrot;
    public Transform target;
    public Transform targeter;
    public float throttlecontrol;
    public float directional;
    public Vector3 reflection;
    public Transform right;
    public Transform left;
    public GameObject red;
    public GameObject blue;
    public bool lightchange;
    public float lighttime;
    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = center;
    }

    // Update is called once per frame
    void Update()
    {
        // This makes the car slow down if making a directional change more than 10 degrees
        if (Mathf.Abs(directional) < 10)
        {
            throttlecontrol = 1;
        }
        else
        {
            throttlecontrol = 0.7f;
        }
        // Targeter looks at player
        targeter.LookAt(target);
        // Figures out which direction the car is facing
        if (targeter.localEulerAngles.y <= 180)
        {
            directional = Mathf.Clamp(targeter.localEulerAngles.y, -25, 25);
        }
        else
        {
            directional = Mathf.Clamp(targeter.localEulerAngles.y - 360, -25, 25);
        }
        // Looks left and right for obstacles, if it finds any, it will make adjustments, adjustments are more intense the closer to the obstacle
        RaycastHit hit;
        if (Physics.Raycast(right.position, right.forward, out hit, 10))
        {
            directional = -25 / (hit.distance / 2);
        }
        if (Physics.Raycast(left.position, left.forward, out hit, 10))
        {
            directional = 25 / (hit.distance / 2);
        }
        // Puts the car into reverse if looking directly at a wall, throttle  increases to 5 times the normal value to help the process
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
        {
            directional = -directional;
            throttlecontrol = -5;
        }
        // Applies the throttle force
        drivingforce = throttlecontrol * throttle;
        wheelBR.motorTorque = drivingforce;
        wheelBL.motorTorque = drivingforce;
        // set the direciton of the wheels
        wheelangle = directional;

        wheelFR.steerAngle = wheelangle;
        wheelFL.steerAngle = wheelangle;

        // set the graphical model of the wheels to the correct positions/rotations
        wheelFR.GetWorldPose(out wheelpos, out wheelrot);
        wheelFRg.transform.position = wheelpos;
        wheelFRg.transform.rotation = wheelrot;


        wheelFL.GetWorldPose(out wheelpos, out wheelrot);
        wheelFLg.transform.position = wheelpos;
        wheelFLg.transform.rotation = wheelrot;


        wheelBR.GetWorldPose(out wheelpos, out wheelrot);
        wheelBRg.transform.position = wheelpos;
        wheelBRg.transform.rotation = wheelrot;


        wheelBL.GetWorldPose(out wheelpos, out wheelrot);
        wheelBLg.transform.position = wheelpos;
        wheelBLg.transform.rotation = wheelrot;
    }
    void FixedUpdate()
    {
        rb.AddForce(-transform.up * rb.velocity.magnitude * 700);
      
        //lighttime += 1;
        //if (lighttime > 10)
        //{
        //    lighttime = 0;
        //    if (lightchange == false)
        //    {
        //        lightchange = true;
        //        blue.SetActive(true);
        //        red.SetActive(false);
        //    }
        //    else
        //    {
        //        lightchange = false;
        //        blue.SetActive(false);
        //        red.SetActive(true);
        //    }
        //}
    }
}

