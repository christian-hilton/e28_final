 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    // non-Level Scenes
    string gameOverScene;
    string introScene;
    GameManager gameManager;

        // maximum Level supported for game, aka number of levels (0 indexed)
    
    public static SceneController instance = null;

    void Awake()
    {   
        //Check if instance already exists
        if (instance == null) {

            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this) {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);   
            
            // skip subsequent setup for an unnecessary instance
            return;
        }

        setup();

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        gameManager = GameManager.getInstance();
        gameManager.sceneController = this;
    }

    public static SceneController getInstance(){
        // if (instance == null) {
        //     instance = new SceneController();
        // }
        return instance;
    }


    // Start is called before the first frame update
    public void setup()
    {   
        // gameOverScene = "GameOver";
        introScene = "IntroScene";

        gameManager = GameManager.getInstance();
    }



    // fetch the string for the next level scene, or completion if reached max
    public string getNextLevel(){
        print(GameState.currentLevel);
        if (GameState.currentLevel > GameState.maxLevel) 
        {
            return introScene;
        }
        else 
        {
            return "Level" + (GameState.currentLevel);
        }
    }

    // load
    public void loadNextLevel(){
        string nextLevel = getNextLevel();
        print("loadnextlevel");
        print(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    // 
    public void loadGameOver(){
        SceneManager.LoadScene(introScene);
    }
}
