using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TimeShadow controls the movement for the player's shadow during
// phase 2 of the gameplay sequence. 
public class TimeShadow : Singleton<TimeShadow>
{
    public Queue<Vector3Int> moves;

    // Pop from queue, do move. This function will be called from LevelController.cs
    public void DoMove()
    {
        Debug.Log("Moving shadow...");
        Vector3Int move = moves.Dequeue();
        Vector3 _movement = TilemapController.Instance.MovePlayer(
            Vector3Int.FloorToInt(gameObject.transform.position), move);
        gameObject.transform.position += _movement;
    }
}
