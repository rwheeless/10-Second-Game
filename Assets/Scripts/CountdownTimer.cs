﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;

    public Text countdownText;
    public Text loseText;

    void Start()
    {
        currentTime = startingTime; 
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            loseText.text = "If there wasn't a win screen, then yikes buddy. YOU LOSE.";
        }
    }


}
