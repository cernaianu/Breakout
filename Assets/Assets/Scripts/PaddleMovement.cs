using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 5f;
    
    private Vector2 direction;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
            MoveHorizontally();


            GetComponent<Rigidbody2D>().velocity = direction;
        
    }

    private void MoveHorizontally()
    {
        
        //var xAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left * movementSpeed * Time.deltaTime;

        else if (Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right * movementSpeed * Time.deltaTime;

        else direction = Vector2.zero;
    }

 
}
