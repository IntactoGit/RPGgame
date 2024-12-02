using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PotionBuff : MonoBehaviour
{
    private Action _potionTaken;
    private GameObject _player;

    private void Awake()
    {
        _potionTaken += OnDestroy;
       _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _potionTaken?.Invoke();
            var outline = _player.GetComponent<Outline>();
            outline.OutlineWidth += 2f;
        }
    }
    
    private void OnDestroy ()
    {
        Destroy(gameObject);
        _potionTaken -= OnDestroy;
        
    }
}
