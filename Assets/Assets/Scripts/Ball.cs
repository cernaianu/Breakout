using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D ballRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public Rigidbody2D GetRigidbody()
    {
        return ballRigidBody;
    }
}
