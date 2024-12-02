using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var Bridge = GameObject.Find("Bridge");
        Bridge.GetComponent<Bridge>();
        
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            if (Input.GetMouseButtonDown(0))
            {
               _destination = hit.point;

            }
            
        }
        
    }
}