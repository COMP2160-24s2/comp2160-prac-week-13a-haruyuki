using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveDroneNavMesh : MonoBehaviour
{   
    [SerializeField] private MovePlayerNavMesh player;
    private Vector3 _destination;
    private NavMeshAgent _navMeshAgent;
    
    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        _destination = player.transform.position;
        _navMeshAgent.SetDestination(_destination);
    }
}
