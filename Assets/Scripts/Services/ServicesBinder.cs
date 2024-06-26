﻿using Services.Interfaces;
using UnityEngine;

namespace Services
{
    [RequireComponent(typeof(ISerivceContainer))]
    public class ServicesBinder : MonoBehaviour
    {
        [SerializeField] private ISerivceContainer _currentContainer;

        private void Awake()
        {
            TryGetComponent(out _currentContainer);
            if (_currentContainer == null) Debug.LogError("No service container found on the game object.");

            _currentContainer?.Bind();
        }
    }
}