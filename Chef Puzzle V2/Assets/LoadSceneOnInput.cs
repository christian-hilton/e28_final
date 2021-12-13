using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetAxis("Submit") == 1) {
			// Proceed from Title to Play Scene todo 
			if (SceneManager.GetActiveScene().name == "Intro Scene") {
				SceneManager.LoadScene("Level 1");
			}
			// Proceed from GameOver to Title Scene
			// else {
			// 	SceneManager.LoadScene("Title");
			// }
		}
	}
}
