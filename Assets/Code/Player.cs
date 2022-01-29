using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int stepLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Moves the player based on keyboard input. The player can only move if they have enough moves left
    void Update()
    {
        if (stepLimit > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                gameObject.transform.position = TilemapController.Instance.MovePlayer(
                    Vector3Int.FloorToInt(gameObject.transform.position), new Vector3Int(0, 1, 0));
                stepLimit--;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position = TilemapController.Instance.MovePlayer(
                    Vector3Int.FloorToInt(gameObject.transform.position), new Vector3Int(-1, 0, 0));
                stepLimit--;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                gameObject.transform.position = TilemapController.Instance.MovePlayer(
                    Vector3Int.FloorToInt(gameObject.transform.position), new Vector3Int(0, -1, 0));
                stepLimit--;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position = TilemapController.Instance.MovePlayer(
                    Vector3Int.FloorToInt(gameObject.transform.position), new Vector3Int(1, 0, 0));
                stepLimit--;
            }
        }
    }
}
