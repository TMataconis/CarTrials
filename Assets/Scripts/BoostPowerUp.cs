using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerUp : MonoBehaviour
{
    public static BoostPowerUp instance;
    public bool isBoostActive;

    // Car Movement variable
    public GameObject car;
    private CarMovement _car;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        _car = car.GetComponent<CarMovement>(); 
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            isBoostActive = true;
            _car.forwardAcceleration = 15000f;
            _car.maxVelocity = 150f;
        }
        else if (Input.GetKey(KeyCode.B)) // allows user to hold down boost
        {
            isBoostActive = true;
            _car.forwardAcceleration = 15000f;
            _car.maxVelocity = 150f;
        }
        else // resets values to normal
        {
            isBoostActive = false;
            _car.forwardAcceleration = 8000f;
            _car.maxVelocity = 50f;
        }
    }
}
