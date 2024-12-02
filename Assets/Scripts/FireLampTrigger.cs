using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLampTrigger : MonoBehaviour
{
    public event Action PlayerEntered;
    private void OnTriggerEnter(Collider collider)
    {
        // Проверяем была ли коллизия с тегом
        if (collider.CompareTag("Player"))
        {
            PlayerEntered?.Invoke();
        }
    }
}
