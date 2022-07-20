using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraTarget; //to hold camera target
    private float CameraRotate=0; //to rotate the camera
    public CarMovementTest CamPlayer; 
     void lATEUpdate()
    {
        if(CamPlayer)
        {
            if(CameraTarget)
            {
                CameraTarget.position = CamPlayer.transform.position;
                if (CameraRotate > 0) CameraTarget.eulerAngles = Vector3.up * Mathf.LerpAngle(CameraTarget.eulerAngles.y, CamPlayer.transform.eulerAngles.y, Time.deltaTime * CameraRotate);
            }
        }
    }

}
