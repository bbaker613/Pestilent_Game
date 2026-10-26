using DG.Tweening;
using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private HandView handView;
    [SerializeField] private GameManager gameManager;

    public CardView CreateCardView(Card card, Vector3 pos, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewPrefab, pos, rotation);
        cardView.handView = handView;
        cardView.gameManager = gameManager;
        cardView.transform.localScale = Vector3.zero;
        cardView.transform.DOScale(Vector3.one, 0.15f);
        cardView.Setup(card);
        return cardView;
    }
}
