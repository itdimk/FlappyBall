using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves specified game object with constant speed
[RequireComponent(typeof(Rigidbody2D))]
public class HorizontalMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _physics;
    
    // Sets initial velocity
    void Start()
    {
        _physics = GetComponent<Rigidbody2D>();
        _physics.velocity = new Vector2(speed, 0);
    }
}
