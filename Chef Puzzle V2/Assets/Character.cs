using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int healthpoints;

    int defaultHP = 100; 
    int hpLimit = 150;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.getInstance().character = this;
        reset();
    }

    public void incrementHP(int increment){
        healthpoints += increment;

        if (healthpoints <= 0){
            expire();
        }

        healthpoints = Math.Min(hpLimit, healthpoints);
    }

    void expire(){
        GameManager.getInstance().gameOver();
    }

    public void reset(){
        healthpoints = defaultHP;
    }
}
