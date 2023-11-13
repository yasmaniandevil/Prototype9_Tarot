using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunction : MonoBehaviour
{
    public Transform startTransform;
    public Transform endTransform;
    public float duration = 1.0f;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //float elapsed = (Time.time - startTime) / duration;

        //float easedTime = EaseInOutQuad(elapsed);
    }

    //public static float EaseInOutQuad(float t)
    //{
        //return t < 0.5f ? 2f * t * t : = -1f + (4f - 2f * t);
    //}
}
