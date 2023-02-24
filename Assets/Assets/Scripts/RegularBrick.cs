using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBrick : MonoBehaviour
{
    public delegate void ScoreGainEventHandler();
    public static event ScoreGainEventHandler ScoreGainEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ScoreGainEvent?.Invoke();
            Destroy(gameObject);
            
        }
            
    }

    

}
