using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    public int minutes = 5;
    public float seconds = 0;
    public bool isTimeUp = false;
    public TextMeshProUGUI timer;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    void Update()
    {
        
        if (!GameManagerScript.instance.isGoalScored)
        {
            if (seconds - Time.deltaTime <= 0 && minutes == 0)
            {
                isTimeUp = true;
            }
            if (!isTimeUp)
            {
                seconds -= Time.deltaTime;
                if (seconds <= 0)
                {
                    minutes -= 1;
                    seconds = 59;
                }
                timer.text = minutes + ":" + seconds.ToString("00");
            }
            
        }
        
    }
}
