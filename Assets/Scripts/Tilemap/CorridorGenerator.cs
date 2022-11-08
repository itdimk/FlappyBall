using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Generates ceiling & floor on corridor tilemap
public class CorridorGenerator : MonoBehaviour
{
    public Tilemap target;
    public Tile wallTile;
    public int drawDistance = 20;
    public int ceilingOffsetY = 1;
    public int floorOffsetY = -1;
    public float generateInterval = 1;

    private float _generatedTimestamp;

    void Start()
    {
       Generate(); 
    }

    // Calls generate every "RegenerateInterval" sec
    private void Update()
    {
        if (Time.time - _generatedTimestamp >= generateInterval)
        {
            Generate();
            _generatedTimestamp = Time.time;
        }
    }

    // Draws ceiling & floor on the tilemap
    public void Generate()
    {
        int myX = (int)transform.position.x;
        int myY = (int)transform.position.y;
        int ceilingY = myY + ceilingOffsetY;
        int floorY = myY + floorOffsetY;

        for (int x = myX - drawDistance; x < myX + drawDistance; ++x)
        {
            target.SetTile(new Vector3Int(x, ceilingY), wallTile);
            target.SetTile(new Vector3Int(x, floorY), wallTile);
        }
    }
}