using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;

    private string spriteTag = "Hex";

    public GameObject lover;
    public float maxDistance = 3.0f;
    public TMP_Text gameOverText;

    public GameObject greenCircle;
    public GameObject yellowCircle;
    public GameObject redCircle;

    public float activationDistanceGreen = 8f;
    public float activationDistanceYellow = 16f;

    private bool isGameOver = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //allows detection to happen but prevents it from responding to
        //physical forces like when it collides with the sprite it wont spin out of control
        rb2D.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        
            movement.Normalize();
            rb2D.velocity = new Vector2(movement.x * speed, movement.y * speed);
            
            
            if (lover != null)
            {
                float distance = Vector2.Distance(transform.position, lover.transform.position);
                Debug.Log(distance);
                if (distance > maxDistance)
                {
                    // Player is too far away, trigger game over
                    ShowGameTextOver();
                
                }

                if (distance <= activationDistanceGreen)
                {
                    greenCircle.SetActive(true);
                    yellowCircle.SetActive(false);
                    redCircle.SetActive(false);
                }

                else if (distance <= activationDistanceYellow)
                {
                    greenCircle.SetActive(false);
                    yellowCircle.SetActive(true);
                    redCircle.SetActive(false);
                }
                else
                {
                    greenCircle.SetActive(false);
                    yellowCircle.SetActive(false);
                    redCircle.SetActive(true);
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(spriteTag))
        {
            Debug.Log("collided");
            //collision.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(collision.gameObject);
            Debug.Log("destroy");
        }
        
    }

    private void ShowGameTextOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        rb2D.isKinematic = true;
    }

    
    
}
