using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    
    [SerializeField] private ChestOpenTrigger _chestOpenTrigger;
  

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _chestOpenTrigger.PlayerEntered += Open;
    }

    private void Open()
    {
        _animator.SetTrigger("open");
    }
}