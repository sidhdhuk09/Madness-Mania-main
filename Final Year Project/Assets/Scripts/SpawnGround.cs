using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public Transform groundobject;
    public LayerMask groundLayer;

   
    public float groundTextureSpeed = -0.4f;
    internal Vector2 gameArea = new Vector2(10, 10);
    internal bool wrapAroundGameArea = false;
    public CarMovementTest playerObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (wrapAroundGameArea == true)
        //{
        //    if (playerObject.transform.position.x > gameArea.x * 0.5f) playerObject.transform.position -= Vector3.right * gameArea.x;
        //    if (playerObject.transform.position.x < gameArea.x * -0.5f) playerObject.transform.position += Vector3.right * gameArea.x;
        //    if (playerObject.transform.position.z > gameArea.y * 0.5f) playerObject.transform.position -= Vector3.forward * gameArea.y;
        //    if (playerObject.transform.position.z < gameArea.y * -0.5f) playerObject.transform.position += Vector3.forward * gameArea.y;
        //}
    }
    private void LateUpdate()
    {
        if (groundobject)
        {
           
            groundobject.position = playerObject.transform.position;

            groundobject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(playerObject.transform.position.x, playerObject.transform.position.z) * groundTextureSpeed);
        }
    }
}
