using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public bool isGoalScored = false;
    public bool isYourGoal = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

   public void NextLevel()
    {
       
        if (isYourGoal)
        {
            // if on last level, return to homescreen
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
           
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
