using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScored : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green Goal"))
        {
            GameManagerScript.instance.isGoalScored = true;
            GameManagerScript.instance.isYourGoal = true;
            UIManagerScript.instance.goalScored.text = "Level Complete!";
        }
        if (other.CompareTag("Red Goal"))
        {
            GameManagerScript.instance.isGoalScored = true;
            UIManagerScript.instance.goalScored.text = "Level Failed!";
        }
    }
   
}
