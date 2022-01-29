using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public int stepLimit;
	private int stepLimitSave;

    public Queue<Vector3Int> movesLog { get; private set; } // queue of player movements, which will be given to the
    // time shadow once gomeplay enters phase 2

    // this function is called by LevelController when the player reaches the goal
    public void Phase2Begin()
	{
		stepLimit = stepLimitSave;
	}

    private void Start()
    {
        movesLog = new Queue<Vector3Int>();
		stepLimitSave = stepLimit;
    }

    void Move(Vector3Int movement)
    {
        Vector3 _movement = TilemapController.Instance.MovePlayer(
            Vector3Int.FloorToInt(gameObject.transform.position), movement, false);
        gameObject.transform.position += _movement;
        if (_movement != Vector3.zero)
        {
            LevelController.Instance.OnPlayerMoved();
            stepLimit--;
            MovesRemainingIndicator.Instance.ShowMoveIndicator(stepLimit);
            if (LevelController.Instance.phase == LevelController.GamePhase.PHASE1)
            {
                movesLog.Enqueue(movement);
            }
            // the player loses the game if they run out of moves and they haven't reached the goal
            if (stepLimit <= 0)
            {
                LevelController.Instance.OnPlayerDied();
            }
        }
    }
    // Update is called once per frame
    // Moves the player based on keyboard input. The player can only move if they have enough moves left
    void Update()
    {
        if (stepLimit > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(new Vector3Int(0, 1, 0));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(new Vector3Int(-1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(new Vector3Int(0, -1, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(new Vector3Int(1, 0, 0));
            }
        }
    }
}
