using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float ms;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ms = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, ms * Time.deltaTime);
        }
    }   
}
