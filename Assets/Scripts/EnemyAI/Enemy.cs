using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public GameObject ball;

    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    /// <summary>
    /// Provided the ball and enemy positions, this will compute the sqrMagnitude between them
    /// </summary>
    /// <param name="ballPosition"></param>
    /// <param name="enemyPosition"></param>
    /// <returns>sqrMagnitude of distance between Vector3s</returns>
    public float GetSquareMagnitudeDistanceOfObject(Vector3 ballPosition, Vector3 enemyPosition)
    {
        return (ballPosition - enemyPosition).sqrMagnitude;
    }

    /// <summary>
    /// Provide destination point and use the navMeshAgent to move enemy to destination
    /// </summary>
    /// <param name="destinationPoint"></param>
    public void MoveToPointInGameWorld(Vector3 destinationPoint)
    {
        enemyAgent.SetDestination(destinationPoint);
    }

    /// <summary>
    /// Generate random position in world within patrol radius
    /// </summary>
    /// <param name="poi"></param>
    /// <param name="patrolRadius"></param>
    /// <returns>New Destination Vector3</returns>
    public Vector3 GetRandomPositionWithinRadius(Vector3 poi, float patrolRadius)
    {
        // generate random position
        Vector3 randomPositionInWorld = Random.insideUnitSphere * patrolRadius;
        // add poi to random position
        randomPositionInWorld += poi;

        return randomPositionInWorld;
    }
}
