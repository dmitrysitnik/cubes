using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    GameObject player;
    UnityEngine.AI.NavMeshAgent nav;
    public Transform[] points;
    float distance;
    private UnityEngine.AI.NavMeshAgent agent;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.SetDestination(GetPointToMove());  
    }


    void Update()
    {
        if (!GameController.gameOver)
        { 
        if (isVisible(distance))
        {   
            nav.SetDestination(player.transform.position);
        }
        else
        {

            if (( !agent.pathPending && agent.remainingDistance < 0.5f) )
            {   
                nav.SetDestination(GetPointToMove());
            }
        }
        }
    }

    private void FixedUpdate()
    {
        distance = CalculateDistance(); 
    }


    private float CalculateDistance()
    {
        float x1 = transform.position.x;
        float y1 = transform.position.z;
        float x2 = player.transform.position.x;
        float y2 = player.transform.position.z;

        return Mathf.Sqrt(Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2));
    }

    bool isVisible(float distance)
    {
        const float MAX_DISTANCE = 5f;
        return true ? (distance < MAX_DISTANCE) : false;
    }

    Vector3 GetPointToMove()
    {      
        return points[Random.Range(0, points.Length)].position;
    }

}

