using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;
    public TextMeshProUGUI goalScored;
    public Button continueButton;
    public Text buttonText;
    public Text boostPower;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
   
    void Update()
    {
        if (GameManagerScript.instance.isGoalScored)
        {
            continueButton.gameObject.SetActive(true);

            if (!GameManagerScript.instance.isYourGoal)
            {
                buttonText.text = "Retry?";
            }
        }
        if (TimeController.instance.isTimeUp)
        {
            continueButton.gameObject.SetActive(true);
            goalScored.text = "Time is up";
            buttonText.text = "Retry?";
        }
        if (BoostPowerUp.instance.isBoostActive)
        {
            boostPower.text = "Boost Active";
        }
        else
        {
            boostPower.text = "";

        }
    }
}
