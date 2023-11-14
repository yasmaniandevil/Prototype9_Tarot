using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Lover1 : MonoBehaviour
{
    
    public float minMoveSpeed = 1f;
    public float maxMoveSpeed = 3f;
    public float minFrequency = 1f;
    public float maxFrequency = 3f;
    public float minMagnitude = .2f;
    public float maxMagnitude = 1f;
    
    private Vector3 pos;
    private float moveSpeed;
    private float frequency;
    private float magnitude;
    
    // Start is called before the first frame update
    void Start()
    {
        magnitude = Random.Range(minMagnitude, maxMagnitude);
        frequency = Random.Range(minFrequency, maxFrequency);
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
