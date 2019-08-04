using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
    public GameObject moveTo;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        moveTo = GameObject.FindGameObjectWithTag("Goal");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = moveTo.transform.position;
    }
}
