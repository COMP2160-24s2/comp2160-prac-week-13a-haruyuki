using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayerNavMesh : MonoBehaviour
{
    private PlayerActions _playerActions;
    private InputAction _mousePosition;
    private InputAction _mouseClick;
    
    [SerializeField] private LayerMask layerMask;
    private Vector3 _destination;
    private NavMeshAgent _navMeshAgent;
    private Camera _mainCamera;

    private void Awake()
    {
        _playerActions = new PlayerActions();
        _mousePosition = _playerActions.Movement.Position;
        _mouseClick = _playerActions.Movement.Click;
    }

    private void OnEnable()
    {
        _mousePosition.Enable();
        _mouseClick.Enable();
    }

    private void OnDisable()
    {
        _mousePosition.Disable();
        _mouseClick.Disable();
    }

    private void Start()
    {
        _mouseClick.performed += GetDestination;
        _destination = transform.position;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_destination);
    }

    private void GetDestination(InputAction.CallbackContext context)
    {
        Vector2 position = _mousePosition.ReadValue<Vector2>();
        Ray ray = _mainCamera.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            _destination = hit.point;
        }
    }
}
