using Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs", fileName = "CardConfig")]
public class CardConfig : ScriptableObject
{
    public string Name;
    public CardType CardType;
}