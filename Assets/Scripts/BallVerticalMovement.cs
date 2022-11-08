using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallVerticalMovement : MonoBehaviour
{
    [Serializable]
    public class SpeedByDifficulty
    {
        public GameManager.Difficulty Difficulty;
        public float VecticalSpeed;
    }

    // Every speedInterval seconds speed increases
    public float speedupInterval = 15;
    // The value by which speed increases every speedupInterval seconds
    public float speedupValue = 1;
    
    public SpeedByDifficulty[] speedByDifficulty;

    private float _currentSpeedupValue = 1;
    private float _speedupTimestamp;

    private Rigidbody2D _physics;
    private GameManager _manager;

    private void Start()
    {
        _physics = GetComponent<Rigidbody2D>();
        _manager = FindObjectOfType<GameManager>();
        if (!_manager)
            Debug.LogError("Unable to find game manager on the scene");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float inputY = Input.GetAxisRaw("Vertical");
        float speed = GetVerticalSpeed();

        _physics.velocity = inputY > 0
            ? new Vector2(_physics.velocity.x, speed * inputY)
            : new Vector2(_physics.velocity.x, -speed);

        if (Time.timeSinceLevelLoad - _speedupTimestamp >= speedupInterval)
        {
            _currentSpeedupValue += speedupValue; 
            _speedupTimestamp = Time.timeSinceLevelLoad;
        }
    }

    private float GetVerticalSpeed()
    {
        var speed = Array.Find(speedByDifficulty, s => s.Difficulty == _manager.CurrentDifficulty);

        if (speed != null)
            return speed.VecticalSpeed + _currentSpeedupValue;
        else
            Debug.LogError($"Speed is not specified for difficulty {_manager.CurrentDifficulty}");
        return 0;
    }
}