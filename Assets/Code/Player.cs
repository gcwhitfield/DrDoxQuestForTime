using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position = TilemapController.Instance.MovePlayer(gameObject.transform.position, new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position = TilemapController.Instance.MovePlayer(gameObject.transform.position, new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position = TilemapController.Instance.MovePlayer(gameObject.transform.position, new Vector3(0, -1, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position = TilemapController.Instance.MovePlayer(gameObject.transform.position, new Vector3(1, 0, 0));
        }
    }
}
