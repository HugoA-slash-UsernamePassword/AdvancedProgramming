using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Seek
    }

    public State currentState = State.Patrol;

    private int health = 2000000;
    
    public int Health
    {
        get
        {
            return health;
        }
    }

    public NavMeshAgent agent;
    public Transform target;
    public float DistanceToWaypoint = 1;
    public Transform waypointParent;

    private Transform[] waypoints;
    private GameObject[] players;
    private int currentIndex = 1;

    private void Start()
    {
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                break;
        }
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
            System.Array.Reverse(waypoints);
        }
        Transform point = waypoints[currentIndex];
        if (Closeness(point.position, DistanceToWaypoint)) currentIndex++;
        bool isFollowingPlayer = false;
        foreach (GameObject item in players)
        {
            point = item.transform;
            if (Closeness(point.position, DistanceToWaypoint * 2))
            {
                isFollowingPlayer = true;
                break;
            }
        }
        if (!isFollowingPlayer)
        {
            point = waypoints[currentIndex];
        }
        agent.SetDestination(point.position);
    }

    void Patrol()
    {

    }
    void Seek()
    {

    }

    public void DealDamage(int damageDealt)
    {
        health -= damageDealt;
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }

    public bool Closeness(Vector3 p1, float D)
    {
        float distance = Vector3.Distance(transform.position, p1);
        if (distance <= D)
        {
            return true;
        }
        return false;
    }
}
