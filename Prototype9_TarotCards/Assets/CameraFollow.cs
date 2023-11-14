using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // the player's transform to follow
    public float smoothSpeed = .125f; //smoothing factor for cam movement
    public Vector3 offset; //offset from players pos
    //public bool clampToBounds; //whether to clamp the camera's position

    //min and max cam pos if clamped
    //public Vector2 minBounds;
    //public Vector2 maxBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            //float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            //float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);
            //desiredPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
            // Smoothly interpolate the camera's current position toward the desired position
            Vector3 smoothPosition = Vector3.Lerp
                (transform.position, desiredPosition, smoothSpeed);

            //update camera's position
            transform.position = smoothPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
