using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public GameObject[] obstacles;

    private float _gameTime = 0f;

    void Update()
    {
        _gameTime += Time.deltaTime;

        for(int i = 0; i < obstacles.Length; i++)
        {
            if (_gameTime < 7)
            {
                if (i % 2 == 0)
                {
                    obstacles[i].transform.position += Vector3.right * 0.1f;
                }
                else
                {
                    obstacles[i].transform.position += Vector3.left * 0.1f;
                }
            }
            else if (_gameTime >= 7 && _gameTime < 21)
            {
                if (i % 2 == 0)
                {
                    obstacles[i].transform.position += Vector3.left * 0.1f;
                }
                else
                {
                    obstacles[i].transform.position += Vector3.right * 0.1f;
                }
            }
            else
            {
                _gameTime = -7;
            }
        }
        
    }
}
