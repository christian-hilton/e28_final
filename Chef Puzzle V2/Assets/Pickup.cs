using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pickup : MonoBehaviour {

    void OnTriggerEnter(Collider other) {

        // on colission with player
        if (other.gameObject.tag == "Player")
        {
            // remove question box
            Destroy(gameObject);
        }

        // 
        GameManager.getInstance().enterQuestionMode();

	}

}
