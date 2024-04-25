using Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CardConfig", fileName = "CardConfig", order = 0)]
public class CardConfig : ScriptableObject
{
    public string Name;
    public CardType CardType;
}