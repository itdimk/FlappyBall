using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ObstacleGenerator : MonoBehaviour
{
    public Tilemap target;
    public Tile obstacleTile;
    
    // Obstacle will be spawner every intervalDistance units
    public float intervalDistance;
    // Obstacle will be spawner between position + spawnDistanceY / 2 and position - spawnDistanceY / 2
    public float spawnDistanceY;
    // X position of last spawned obstacle
    private int _lastObstacleX;

    private void Update()
    {
        float myX = transform.position.x;
        if (myX - _lastObstacleX > intervalDistance)
        {
            var obstaclePos = GetObstaclePosition();
            target.SetTile(obstaclePos, obstacleTile);
            _lastObstacleX = obstaclePos.x;
        }
    }

    private Vector3Int GetObstaclePosition()
    {
        int x = (int)transform.position.x;
        float maxY = transform.position.y + spawnDistanceY / 2;
        float minY = transform.position.y - spawnDistanceY / 2;
        int y = (int)Mathf.Round(Random.Range(minY, maxY));
        return new Vector3Int(x, y, 0);
    }
}