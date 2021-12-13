using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // MODEL : DATA
    public QuestionDataSource questionDataSource;
    public Character character;
    // public GameState gameState; 

    // VIEW LAYER : UI ELEMENTS
    public GameUI gameUI; 

    // CONTROLLERS : LOGIC 
    public QuestionResponder questionResponder;
    public IntroResponder introResponder;
    public SceneController sceneController;

    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    // Awake is always called before any Start functions
    void Awake()
    {   
        //Check if instance already exists
        if (instance == null) {

            //if not, set instance to this
            instance = this;
        }

        // If instance already exists and it's not this:
        else if (instance != this) {

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);   
            
            // skip subsequent setup for an unnecessary instance
            return;
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        questionDataSource = QuestionDataSource.getInstance();
        print("awake");

    }

    public void setupLevel(){
        // gameUI = GetComponent<GameUI>();
        gameUI.hideQuestion();
        int hp = character.healthpoints;
        gameUI.updateHP(hp);
        print("setupLevel");
    }

    public void selectAnswer(int answer){
        gameUI.selectAnswer(answer);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.paused) {
            questionResponder.listen();
        }
    }

    // return the instance of gameManager
    public static GameManager getInstance(){
        return instance;
    }

    // fetch the character's hp
    public int getHP(){
        return character.healthpoints;
    }

    // increment the character's hp by an amount
    public void incrementHP(int increment){
        character.incrementHP(increment);
        gameUI.updateHP(character.healthpoints);
    }

    // enter question mode
    public void enterQuestionMode(){
        pause();
        Question question = questionDataSource.getQuestion();
        print(question.text);
        questionResponder.setQuestion(question); 
        gameUI.setQuestion(question);
        gameUI.showQuestion();
    }

    // exit question mode to regular gameplay
    public void exitQuestionMode(){
        gameUI.hideQuestion();
        questionResponder.reset();
        unPause();
    }

    // pause the game
    public void pause() {
        Time.timeScale = 0f;
        GameState.paused = true;
    }

    // resume or unpause the game
    public void unPause() {
        Time.timeScale = 1f;
        GameState.paused = false;
    }

    public void nextLevel(){
        GameState.incrementLevel();
        print(GameState.currentLevel);
        sceneController.loadNextLevel();
    }

    public void gameOver(){
        sceneController.loadGameOver();
    }

    public void answerQuestion(bool correct){
        print(questionDataSource);
        if (correct){
            incrementHP(questionDataSource.questionCorrectValue);
        }
        else {
            incrementHP(questionDataSource.questionIncorrectValue);
        }
        GameState.incrementGoal();
        exitQuestionMode();
    }

    public void resetCharacter(){
        character.reset();
    }
}
