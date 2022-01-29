using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LevelController is responsible for the overall flow of the game. It will
// handle things like pausing, moving between scenes, ending and beginning levels, etc.
//
// The gameplay is divided into two phases. In the first phase, the player is trying to
// reach the goal. In the second phase, the player is trying to return back to the start
// location. 
public class LevelController : Singleton<LevelController>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called then the player starts the game
    void Phase1Begin()
    {
        // TODO: play level begin sound?
        // TODO: begin phase 1 music
    }

    // called when the player reaches the goal and and begins the second phase,
    // where they must return to the beginning
    void Phase2Begin()
    {
        // TODO: stop playing phase 1 music, play phase 2 music
        // TODO: play phase 2 begin sound?
        // TODO: 
    }
}
