using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player;
    private float smoothSpeed = 8f;

    public Vector3 offset;
    public Vector3 SmoothPosition;
    

    private void Start()
    {
        



           // offset = Vector3.Lerp(1.4f,1.94f,-6.74f);
    }


     void FixedUpdate()
    {
            
        // OFFSET FROM YOUR CAMERA
        offset = new Vector3(1.4f, 1.94f, -6.74f);

        // FINAL CAMERA POSITION
        Vector3 AdjustedPosition = offset + player.position;

        // THE TRANSFORM WHERE OUR CAMERA WILL MOVE FROM POSITION A TO B FOR OUR EXAMPLE IT WILL MOVE FROM "transform.position" to "AdjustedPosition"
        SmoothPosition = Vector3.Lerp(transform.position, AdjustedPosition, smoothSpeed * Time.deltaTime);

        // SET THE CAMERA'S POSITION TO "SmoothPosition"
        transform.position = SmoothPosition;

       
    }


}
