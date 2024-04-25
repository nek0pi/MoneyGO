using Services.Implementations;
using Services.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace Services.Containers
{
    public class ProdServicesContainer : MonoBehaviour, ISerivceContainer
    {
        [SerializeField] private ConfigsService _configsService;

        public void Bind()
        {
            AssignAllServices();
            ServiceLocator.Register<IConfigsService>(_configsService);
        }

        private void AssignAllServices()
        {
            if (TryGetComponent(out _configsService) == false)
                _configsService = this.AddComponent<ConfigsService>();
        }
    }
}