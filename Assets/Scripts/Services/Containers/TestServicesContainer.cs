using Services.Implementations;
using Services.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace Services.Containers
{
    public class TestServicesContainer : MonoBehaviour, ISerivceContainer
    {
        [SerializeField] private ConfigsService _testConfigsService;

        public void Bind()
        {
            AssignAllServices();
            ServiceLocator.Register<IConfigsService>(_testConfigsService);
        }

        private void AssignAllServices()
        {
            if (TryGetComponent(out _testConfigsService) == false)
                _testConfigsService = this.AddComponent<ConfigsService>();
        }
    }
}