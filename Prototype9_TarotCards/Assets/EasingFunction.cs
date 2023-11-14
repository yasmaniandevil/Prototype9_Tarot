using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunction : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float duration = 10.0f;

    public float frequency = 2.0f; //speed
    public float amplitude = 8f; //how high and low the sign wave goes
    
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = (Time.time - startTime) / duration;

        float easedTime = EaseInOutQuad(0, 1, elapsed, frequency, amplitude);
        Debug.Log("easedTime: " + easedTime);
        transform.position = Vector2.Lerp(
            startTransform.position, endTransform.position, easedTime);
        Debug.Log("Position" + transform.position);
        /*if (elapsed >= 1.0f)
        {
            
        }*/
    }

    public static float EaseInOutQuad(float start, float end, float value, float frequency, float amplitude)
    {
        value /= 5f;
        end -= start;

        float oscillation = Mathf.Sin(value * frequency) * amplitude;
        
        if (value < 1) return end * 0.5f * value * value + start + oscillation;
        
        value--;
        
        return -end * 0.5f * (value * (value - 2) - 1) + start + oscillation;
    }
}
