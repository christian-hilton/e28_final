using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{

    public Text feedbackText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        feedbackText.text = GameState.feedbackText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
