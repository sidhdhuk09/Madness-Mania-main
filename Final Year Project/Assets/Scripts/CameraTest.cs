using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{

	public Transform car; //to hold car object
	public float distance = 6.4f;	//TO CALCULATE DISTANCE FROM THE CAR
	public float height = 1.4f;		//to calculate height
	public float rotationDamping = 3.0f;	//to induce rotation effecft
	public float heightDamping = 2.0f;		//to induce height changing effect
	public float zoomRatio = 0.5f;			//
	public float defaultFOV = 60f;			//fov of the car

	private Vector3 rotationVector;			//rotation vector

	void LateUpdate()
	{
		float wantedAngle = rotationVector.y;		
		float wantedHeight = car.position.y + height;	
		float myAngle = transform.eulerAngles.y;
		float myHeight = transform.position.y;

		myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
		myHeight = Mathf.Lerp(myHeight, wantedHeight, heightDamping * Time.deltaTime);

		Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
		transform.position = car.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		Vector3 temp = transform.position; 
		temp.y = myHeight;
		transform.position = temp;
		transform.LookAt(car);
	}

	void FixedUpdate()
	{
		Vector3 localVelocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity);
		if (localVelocity.z < -0.1f)
		{
			Vector3 temp = rotationVector;
			temp.y = car.eulerAngles.y + 180;
			rotationVector = temp;
		}
		else
		{
			Vector3 temp = rotationVector;
			temp.y = car.eulerAngles.y;
			rotationVector = temp;
		}
		float acc = car.GetComponent<Rigidbody>().velocity.magnitude;
		GetComponent<Camera>().fieldOfView = defaultFOV + acc * zoomRatio * Time.deltaTime; 
	}
}