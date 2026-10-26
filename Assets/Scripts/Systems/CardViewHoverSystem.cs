using UnityEngine;

public class CardViewHoverSystem : Singleton<CardViewHoverSystem>
{
    [SerializeField] private CardView cardViewHover;

    public void Show(Card card, Vector3 pos)
    {
        cardViewHover.gameObject.SetActive(true);
        cardViewHover.Setup(card);
        cardViewHover.transform.position = pos;
    }

    public void Hide()
    {
        cardViewHover.gameObject.SetActive(false);
    }
}
