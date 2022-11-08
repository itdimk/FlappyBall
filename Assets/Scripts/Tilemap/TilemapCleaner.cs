using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCleaner : MonoBehaviour
{
    public int height;
    public Tilemap target;

    // removes vertical line of tiles at current position X
    void FixedUpdate()
    {
        var pos = GetPos();
        int startY = pos.y - height / 2;
        int endY = pos.y + height / 2;

        for (int y = startY; y <= endY; ++y)
            target.SetTile(new Vector3Int(pos.x, y, 0), null);
    }

    Vector3Int GetPos()
    {
        return new Vector3Int((int) transform.position.x, (int) transform.position.y, 0);
    }
}