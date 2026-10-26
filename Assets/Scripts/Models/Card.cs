using UnityEngine;

public class Card
{
    public string Title => data.name;
    public string Description => data.Description;
    public Sprite Image => data.Image;
    public int Energy { get; private set; }

    private readonly CardData data;

    public Card(CardData cardData)
    {
        data = cardData;
        Energy = cardData.Energy;
    }
}
