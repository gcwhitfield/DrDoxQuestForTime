using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapController : Singleton<TilemapController>
{

    [System.Serializable]
    public enum TileType
    {
        WALL,
        OPEN,
        DOOR
    };

    // returns the type of the tile at 'location'
    TileType GetTile(Vector3 location)
    {
        // do a raycast at 'location' in scene to grab the tile
        Vector3 rayOrigin = new Vector3(location.x, location.y, 1);
        Vector3 rayDirection = new Vector3(0, 0, -1);
        float rayLength = 5;
        RaycastHit hitInfo;
        Physics.Raycast(rayOrigin, rayDirection, out hitInfo, rayLength);
        GameplayTile tile = null;
        if (hitInfo.collider) {
            tile = hitInfo.collider.gameObject.GetComponent<GameplayTile>();
        }
        if (!tile) // if there is no tile, just pretend that it's an 'open' tile
        {
            return TileType.OPEN;
        } else
        {
            return tile.tileType;
        }
    }

    // Given a current player position, and a movement vector returns the position
    // that the player moves to, given the constraints of the map. The player will
    // NOT intersect with walls
    public Vector3 MovePlayer(Vector3 playerLocation, Vector3 movement)
    {
        TileType nextTile = GetTile(playerLocation + movement);
        if (nextTile == TileType.WALL)
        {
            return playerLocation; // do not allow the player to move into or through walls
        } else if (nextTile == TileType.OPEN)
        {
            return playerLocation + movement;
        } else
        {
            Debug.Log("The player has collided with a door!");
            return playerLocation;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
