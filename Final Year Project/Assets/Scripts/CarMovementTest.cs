using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementTest : MonoBehaviour
{
    public float health = 100; //health of the player
    private float healthMax; //to set the health of the player to max upon game start
    public float speed = 10;    //speed
    public float rotateSpeed = 200; //the speed at which the car rotates
    public float currentRotation = 0;   //the present rotation when the player is activly pressing the key to rotate the car. The value increments upon active rotation
    public float driftAngle = 50;   //the rotation a car gives upon extreme rotation thereby giving the feeling of a drift. Currently not working
    public Transform[] wheels;      // to assign the 4 wheels of the car in order to execute them in the code below to allow them to turn
    public int frontWheels = 2;     //to allow the frontwheels of the car to turn
    public Transform movement;      //to enable the movement
    public Transform Frameofcar;    //main front panel of the car. Used to give the effect of automatic tilt of the car upon rotation
    public float leanangle;
    private float rightangle;
    public CarMovementTest Player;
    private float PlayerDirection;





    private int index;//to iterate through the wheels for wheel movement effect upon rotating the car

    void Start()
    {
        if (Player)
        {
            //Player = Instantiate(Player);
            //Player.tag = "Player";
        }
        healthMax = health;
    }
    void Update()
    {
        movement.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        if (Player)
        {
            PlayerDirection = Input.GetAxis("Horizontal");
            Player.Rotate(PlayerDirection);


        }
    }


    public void Rotate(float rotateDirection)
    {



        if (rotateDirection != 0)
        {

            movement.localEulerAngles += Vector3.up * rotateDirection * rotateSpeed * Time.deltaTime;

            movement.eulerAngles = new Vector3(movement.eulerAngles.x, movement.eulerAngles.y, movement.eulerAngles.z);


            currentRotation += rotateDirection * rotateSpeed * Time.deltaTime;


            if (currentRotation > 360) currentRotation = currentRotation - 360; //if the rotation is greater then we subtract by 360 as it is the upper bound of a circle and then execute the below code for graphical fidelity purposes


            //        movement.Find("Body").localEulerAngles = new Vector3(rightangle, Mathf.LerpAngle(movement.Find("Body").localEulerAngles.y, rotateDirection * driftAngle + Mathf.Sin(Time.time * 50), Time.deltaTime), 0); //the front panel of the car will dift based on rotation


            //        if (Frameofcar) Frameofcar.localEulerAngles = Vector3.forward * Mathf.LerpAngle(Frameofcar.localEulerAngles.z, rotateDirection * leanangle, Time.deltaTime); //the front panel of the car will rotate sightly towards left or right depending upon the rotation




            //        for (index = 0; index < wheels.Length; index++) //we use index to iterate through all of the wheels on the car in order to allow for them to rotate based on the code below
            //        {

            //            if (index < frontWheels) wheels[index].localEulerAngles = Vector3.up * Mathf.LerpAngle(wheels[index].localEulerAngles.y, rotateDirection * driftAngle, Time.deltaTime * 10); //this will turn the wheels sideways approx 45 degrees upon rotation


            //            wheels[index].Find("WheelObject").Rotate(Vector3.right * Time.deltaTime * speed * 20, Space.Self); //used to spin the wheels. The wheelobject is an empty gameobject attached to the wheels in the in the hirerarchy in order to facilitate the rotation of the wheels
            //        }
            //    }
            //    else // if we stop rotating the car then the car will straighten
            //    {

            //        movement.Find("Body").localEulerAngles = Vector3.up * Mathf.LerpAngle(movement.Find("Body").localEulerAngles.y, 0, Time.deltaTime * 5); //car will return to normal 90 degree axis


            //        if (Frameofcar) Frameofcar.localEulerAngles = Vector3.forward * Mathf.LerpAngle(Frameofcar.localEulerAngles.z, 0, Time.deltaTime * 5);//  Mathf.LerpAngle(thisTransform.Find("Base").localEulerAngles.y, rotateDirection * driftAngle, Time.deltaTime); front panel will return to 90 degree angle



            //        // Go through all the wheels making them spin faster than when turning, and return the front wheels to their 0 angle
            //        for (index = 0; index < wheels.Length; index++)
            //        {
            //            // Return the front wheels to their 0 angle
            //            if (index < frontWheels) wheels[index].localEulerAngles = Vector3.up * Mathf.LerpAngle(wheels[index].localEulerAngles.y, 0, Time.deltaTime * 5);

            //            // Spin the wheel faster
            //            wheels[index].Find("WheelObject").Rotate(Vector3.right * Time.deltaTime * speed * 30, Space.Self); //rotate the wheels  
            //        }
            //    }
            //}
        }
    }
}
    



