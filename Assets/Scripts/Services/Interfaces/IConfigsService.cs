using Enums;

namespace Services.Interfaces
{
    public interface IConfigsService
    {
        public CardConfig GetCardConfig(CardType type);
    }
}