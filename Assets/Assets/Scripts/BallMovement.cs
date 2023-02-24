using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 100f;
    
    private Ball ball;
    public delegate void LifeLostEventHandler();
    public static event LifeLostEventHandler LifeLostEvent;

    private Vector2 startPosition;
    private Vector2 direction;


    
    private bool IsMoving = false;
    private int HorizontalIdentifier;
    private int VerticalIdentifier;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
        ball = GetComponent<Ball>();
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rigidBody = GetComponent<Rigidbody2D>();

        if (IsMoving)
        {
            rigidBody.isKinematic = false;
            rigidBody.velocity = direction;
        }
        else
        {
            rigidBody.isKinematic = true;
            StartMoving();
        }
        
    }

    private void StartDirection()
    {
        HorizontalIdentifier = Random.Range(0, 2);
        if (HorizontalIdentifier == 0)
            direction = Vector2.up + Vector2.left * movementSpeed * Time.deltaTime;
        else if (HorizontalIdentifier == 1)
            direction = Vector2.up + Vector2.right * movementSpeed * Time.deltaTime;
    }

    private void Bounce(Rigidbody2D rigidBody, Vector2 impactNormal)
    {
        var BouncingDirection = Vector2.Reflect(direction, impactNormal);
        direction = BouncingDirection.normalized * movementSpeed * Time.deltaTime;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") 
            || collision.gameObject.CompareTag("Player") 
            || collision.gameObject.CompareTag("Brick"))
        {
            Bounce(GetComponent<Rigidbody2D>(), collision.GetContact(0).normal);
        }
        else if(collision.gameObject.CompareTag("LoseZone"))
        {
            LifeLostEvent?.Invoke();
            Destroy(gameObject);
        }
    }

    public void StartMoving()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.parent = null;
            StartDirection();
            IsMoving = true;
        }
    }


}
