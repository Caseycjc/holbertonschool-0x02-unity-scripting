using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health;
    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        health = 5;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("Score: " + score);
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
    }
}
