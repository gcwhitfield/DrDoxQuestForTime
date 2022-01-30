using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TimeShadow controls the movement for the player's shadow during
// phase 2 of the gameplay sequence.
public class TimeShadow : Singleton<TimeShadow>
{
    public Queue<Vector3Int> moves;
    public ParticleSystem deathboom;

    // Pop from queue, do move. This function will be called from LevelController.cs
    public void DoMove()
    {
        if (moves.Count > 0)
		{
            Vector3Int move = moves.Dequeue();
            Vector3 _movement = TilemapController.Instance.MovePlayer(
                Vector3Int.FloorToInt(gameObject.transform.position), move, true);
            gameObject.transform.position += _movement;
		}
    }

    // called when another collider overlaps with the collider that is currently attached to
    // this gameobject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          if(LevelController.Instance.phase == LevelController.GamePhase.PHASE2)
          {
            deathboom.Play();
            Invoke("DeathScreen", 0.8f);
          }
        }
    }

    void DeathScreen()
    {
        LevelController.Instance.OnPlayerDied();    
    }
}
