using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : Singleton<TilemapController>
{
    public Tilemap tilemap;

    public TileBase[] wallTiles;
    public TileBase[] floorTiles;
    public TileBase goalTile;

    [System.Serializable]
    public enum BackgroundTileType
    {
        WALL,
        OPEN
    };

    // returns the type of the tile at 'location'
    BackgroundTileType GetTile(Vector3Int location)
    {
        TileBase tile = tilemap.GetTile(location);
        foreach (TileBase t in wallTiles) {
            if (tile == t) return BackgroundTileType.WALL;
        }
        foreach (TileBase t in floorTiles)
        {
            if (tile == t) return BackgroundTileType.OPEN;
        }
        return BackgroundTileType.OPEN;
    }

    // Given a current player position, and a movement vector returns the direction
    // that the player moves to, given the constraints of the map. The player will
    // NOT intersect with walls
    public Vector3 MovePlayer(Vector3Int playerLocation, Vector3Int movement)
    {
        BackgroundTileType nextTile = GetTile(playerLocation + movement);
        //Vector3 offset = new Vector3(0.5f, 0.5f, 0);
        if (nextTile == BackgroundTileType.WALL)
        {
            return  Vector3.zero; // do not allow the player to move into or through walls
        } else
        {
            return  movement;
        } 
    }

    // Given the player's location, activate the tile that the player is standing on.
    // For example, if the player is standing on the goal, then the game logic for hitting the
    // goal will execute. If the player is standing on a door, then the door will open/close, etc.
    public void ActivateTile(Vector3Int playerLocation)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
