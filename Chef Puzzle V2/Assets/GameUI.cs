using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// GameUI include the user interface elements, in particular the Text elements
// This is the UI layer and only functions to show, hide, and update UI
public class GameUI : MonoBehaviour
{
    public Text[] answerText;
    public Text questionText;
    public Text hpText;

    public GameManager gameManager;

    void Awake(){
        if (gameManager == null){
            gameManager = GameManager.getInstance();
        }
        gameManager.gameUI = this;
        print("gameUI awake");

        hideQuestion();
    }

    void Start(){
        int hp = GameManager.getInstance().getHP();
        updateHP(hp);
    }

    public void setQuestion(Question question){
        questionText.text = question.text;
        //

        for (int i = 0; i < 4; i++) 
        {
            Text answer = answerText[i];
            answer.text = question.choices[i];
        }
    }

    public void hideQuestion(){
        toggleQuestion(false);
    }

    public void showQuestion(){
        toggleQuestion(true);
    }

    public void toggleQuestion(bool enabled){
        print("toggle question");
        questionText.enabled = enabled;

        for (int i = 0; i < 4; i++) 
        {
            Text currentText = answerText[i];
            currentText.enabled = enabled;
        }
    }

    public void selectAnswer(int selected){
        for (int i = 0; i < 4; i++) 
        {
            // print(selected);
            if (i == selected) {
                answerText[i].color = Color.green;
            }
            else {
                answerText[i].color = Color.black;
            }
        }
    }

    public void updateHP(int newHP){
        hpText.text = "HP: " + newHP;
    }
}
