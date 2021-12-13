using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameState
{   
    static public bool paused;
    static public bool questionMode;
    static public int currentLevel;
    static int goalsLeft; 
    static public GameManager gameManager;
    static public int maxLevel = 2;

    static string newGameText = "Start a new game";
    public static string feedbackText = newGameText;
    static string gameOverText = "Game Over";
    static string winText = "You completed the game, congradulations!";

    static GameState(){        
        resetAll();
    }

    static public void incrementLevel(){
        currentLevel += 1;

        if (currentLevel > maxLevel) {
            currentLevel = 0;
            feedbackText = winText;
        }
    }

    static public void incrementGoal(){
        goalsLeft -= 1;

        if (goalsLeft == 0) {
            GameManager.getInstance().nextLevel();
        }
    }

    static public void setGameOver(){
        currentLevel = 0;
        feedbackText = gameOverText;
    }

    static public void resetAll(){
        paused = false;
        currentLevel = 0;
        questionMode = false;
        goalsLeft = 1;
    }

    static public void resetForNextLevel(){
        paused = false;
        questionMode = false;
        goalsLeft = 1;
    }
}
