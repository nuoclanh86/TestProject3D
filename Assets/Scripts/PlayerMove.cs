using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent nmAgent;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = this.GetComponent<NavMeshAgent>();
        if (nmAgent != null)
            nmAgent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
