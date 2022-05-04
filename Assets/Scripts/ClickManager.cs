using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public TextMeshProUGUI apmText;

    private int apm; 

    // private float firstClick = 0;
    // private float lastClick = 0;
    private int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateAPM", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            counter++;
        }

        apmText.text = "APM: " + apm.ToString();
    }

    private void updateAPM(){
        float minConversion = Time.time/60; //time.time to min
        float timeInMin = counter/minConversion;
        apm = (int)timeInMin;
    }



    // void calculateAPM(){
        
        

        

    //     //calculates APM
    //     // float temp = lastClick - firstClick;
    //     counter++;
    //     float timeInMin = counter/minConversion;
    //     apm = (int)timeInMin;

    //     firstClick = lastClick; //sets the next click up

    // }
}
