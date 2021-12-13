using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Question is todo

public class Question {

    public string text;
    
    public string[] choices; 

    public int correctAnswer; 

    public Question(string newtext, string[] newchoices, int newcorrectAnswer)
    {
        text = newtext;
        choices = newchoices;
        correctAnswer = newcorrectAnswer;
    }
}
