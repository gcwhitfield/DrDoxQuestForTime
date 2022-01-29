using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : Singleton<TilemapController>
{
    public Tilemap tilemap;

    public TileBase[] wallTiles;
    public TileBase[] floorTiles;

    [System.Serializable]
    public enum TileType
    {
        WALL,
        OPEN
    };

    // returns the type of the tile at 'location'
    TileType GetTile(Vector3Int location)
    {
        TileBase tile = tilemap.GetTile(location);
        foreach (TileBase t in wallTiles) {
            if (tile == t) return TileType.WALL;
        }
        foreach (TileBase t in floorTiles)
        {
            if (tile == t) return TileType.OPEN;
        }
        return TileType.OPEN;
    }

    // Given a current player position, and a movement vector returns the position
    // that the player moves to, given the constraints of the map. The player will
    // NOT intersect with walls
    public Vector3 MovePlayer(Vector3Int playerLocation, Vector3Int movement)
    {
        TileType nextTile = GetTile(playerLocation + movement);
        Vector3 offset = new Vector3(0.5f, 0.5f, 0);
        if (nextTile == TileType.WALL)
        {
            return playerLocation + offset; // do not allow the player to move into or through walls
        } else if (nextTile == TileType.OPEN)
        {
            return playerLocation + movement + offset;
        } else
        {
            Debug.Log("The player has collided with a door!");
            return playerLocation + offset;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
