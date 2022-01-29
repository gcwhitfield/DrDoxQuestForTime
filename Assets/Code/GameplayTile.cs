using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this component should be attached to all of the tiles that are involved with gameplay in our scene
// walls, background tiles, doors, etc.
public class GameplayTile : Component
{
    public TilemapController.TileType tileType;
}
