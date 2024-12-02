using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    [SerializeField] private BridgeBreakTrigger _bridgeBreakTrigger;
    [SerializeField] private FireLampTrigger _fireLampOnBridgeTrigger;
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    
    private GameObject _player;
    private Outline _outline;
    private GameObject _bridgeFire;
   
    
    
    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
       
        _player = GameObject.FindGameObjectWithTag("Player");
        
        _outline = _player.GetComponent<Outline>();
        _bridgeFire = GameObject.FindGameObjectWithTag("BridgeFire");
        _bridgeFire.SetActive(false);
        _bridgeBreakTrigger.PlayerEntered += Break;
        _fireLampOnBridgeTrigger.PlayerEntered += BridgeLampsTurnOn;
    }

    private void Update()
    {
        if ( _outline.OutlineWidth  >= 2f  )
        {
            _bridgeBreakTrigger.PlayerEntered -= Break;
            
        }
    }

    private void BridgeLampsTurnOn()
    {
        _bridgeFire.gameObject.SetActive(true);
        _fireLampOnBridgeTrigger.PlayerEntered -= BridgeLampsTurnOn;
    }
    public void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
            rigidbody.AddForce(direction * forceValue);
        }
    }
}