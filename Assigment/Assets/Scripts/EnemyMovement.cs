using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]float movespeed= 1f;
    Rigidbody2D rb;
    bool right;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if(transform.position.x < -1.7)
        {   
          right= true;
        }
        else if(transform.position.x > 1.7)
        {   
          right= false;
        }
        if(right)
        {
            rb.velocity = new Vector2(movespeed,0f);
        }
        else
        {
            rb.velocity = new Vector2(-movespeed,0f);
        }
    }
}
