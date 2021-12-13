using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// QuestionResponder handles responding to the user interactions for questions
public class QuestionResponder : MonoBehaviour
{
    public int selected;
    GameManager gameManager;
    Question question;

    static int numberQuestions = 4; 
    
    void Awake()
    {
        print("question awake");
        gameManager = GameManager.getInstance();
        gameManager.questionResponder = this;
        reset();
    }


    // Update is called once per frame
    void Update(){
        // Don't listen for updates unless game is paused and GameController asks to listen for updates
    }

    public void listen()
    {
        if (Input.GetKeyDown("up"))
        {
            selected = (selected - 1) % numberQuestions; 
            GameManager.getInstance().selectAnswer(selected);
        }

        if (Input.GetKeyDown("down"))
        {
            selected = (selected + 1) % numberQuestions; 
            GameManager.getInstance().selectAnswer(selected);
        }

        // todo remove
        if (Input.GetKeyDown("right"))
        {
            gameManager.unPause();
        }

        // submit question with return or enter
        if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
        {
            submit();
        }
    }

    void submit(){
        // relay correctness to gameManager
        gameManager.answerQuestion(selected == question.correctAnswer);
    }

    public void setQuestion(Question newQuestion){
        question = newQuestion;
    }

    public void reset(){
        selected = 0;
    }

    // hide the question for exploration mode.  this is the default state
    
}
