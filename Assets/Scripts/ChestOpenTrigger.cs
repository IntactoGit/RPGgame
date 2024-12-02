using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenTrigger : MonoBehaviour
{
    // Событие используется для оповещения о том, что игрок вошел в область триггера
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
