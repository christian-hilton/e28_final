using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tracks user interactions and responses to text screens, such as Intro and Game over
public class IntroResponder : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        // submit with return or enter
        if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
        {
            print("next");
            gameManager.nextLevel();
        }
    }
}
