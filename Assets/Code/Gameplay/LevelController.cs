using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// LevelController is responsible for the overall flow of the game. It will
// handle things like pausing, moving between scenes, ending and beginning levels, etc.
//
// The gameplay is divided into two phases. In the first phase, the player is trying to
// reach the goal. In the second phase, the player is trying to return back to the start
// location.
public class LevelController : Singleton<LevelController>
{

    private static FMOD.Studio.EventInstance Music; // init FMOD

    public enum GamePhase
    {
        PHASE1, // the player is trying to reach the goal
        PHASE2  // the player is trying to avoid their past self and reach the
                // beginning of the level
    };

    public GamePhase phase { get; private set; }

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseMenu;
    public InvertColorPostProcessEffect colorIversionEffect;
    public ParticleSystem confetti;

    public string musicPath; // choose what BGM track plays on this level

    // Start is called before the first frame update
    void Start()
    {
        // more FMOD setup
        Music = FMODUnity.RuntimeManager.CreateInstance(musicPath);
        Music.start();
        Music.release();

        phase = GamePhase.PHASE1;
        Phase1Begin();
    }

    // Called when the player starts the game
    void Phase1Begin()
    {
        // disable the time shadow
        TimeShadow.Instance.transform.Find("Art").gameObject.SetActive(false);
        // TODO: play level begin sound?
        // TODO: begin phase 1 music
    }

    // Called when the player reaches the goal and and begins the second phase,
    // where they must return to the beginning
    void Phase2Begin()
    {
        phase = GamePhase.PHASE2;

        // enable the time shadow
        TimeShadow.Instance.transform.Find("Art").gameObject.SetActive(true);

        Player.Instance.Phase2Begin();
        // TODO: stop playing phase 1 music, play phase 2 music
        // TODO: play phase 2 begin sound?
        // TODO:

        if (colorIversionEffect)
        {
            colorIversionEffect.PlayEffect();
        }
    }

    // Called when the player reaches the goal
    public void OnGoalReached()
    {
        if (phase == GamePhase.PHASE1)
        {
            Music.setParameterByName("hasCloneAppeared", 1);
            TimeShadow.Instance.moves = Player.Instance.movesLog;
            Debug.Log("The player has reached the goal.");
            Phase2Begin();
        }
    }

    public void OnLadderReached()
    {
        if (phase == GamePhase.PHASE2)
        {
            if (confetti)
            {
                confetti.Play();
            }
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Invoke("YouWon",0.8f);
        }
    }

    void YouWon()
    {
      Debug.Log("You win!");
      winScreen.SetActive(true);
    }


    // called when the player fails a puzzle
    public void OnPlayerDied()
    {
        Debug.Log("You lose!");
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Player.Instance.GetComponent<Animator>().SetTrigger("Die");
        loseScreen.SetActive(true);
    }

    // Called when the player moves in the game
    public void OnPlayerMoved()
    {
        // bad implementation
        FMOD.Studio.EventInstance PlayerMoveSFX;
        PlayerMoveSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Player Move");
        PlayerMoveSFX.start();
        PlayerMoveSFX.release();

        if (phase == GamePhase.PHASE2)
        {
            // move the shadow
            TimeShadow.Instance.DoMove();
        }
    }

    // resets the current level to the default state
    public void ResetLevel()
    {
        // TODO: add implementation
        SceneTransitionManager.Instance.TransitionToScene(SceneManager.GetActiveScene().name);
    }
}
