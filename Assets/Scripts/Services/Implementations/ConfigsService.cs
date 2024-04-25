using System.Collections.Generic;
using Enums;
using Services.Interfaces;
using UnityEngine;

namespace Services.Implementations
{
    public class ConfigsService : MonoBehaviour, IConfigsService
    {
        [SerializeField] private List<CardConfig> _cardConfigs;

        public CardConfig GetCardConfig(CardType type)
        {
            return _cardConfigs.Find(config => config.CardType == type);
        }
    }
}