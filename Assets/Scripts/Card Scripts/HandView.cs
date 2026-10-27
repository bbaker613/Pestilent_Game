using DG.Tweening;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class HandView : MonoBehaviour
{
    [SerializeField] int drawHandSize = 5;
    [SerializeField] int maxHandSize = 10;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private CardData cardData;
    private readonly List<CardView> cards = new();

    private void Start()
    {
        for (int i = 0; i < drawHandSize; i++)
        {
            Card card = new(cardData);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);
            StartCoroutine(AddCard(cardView));
        }
    }

    public void NewHand()
    {
        DiscardAll();

        for (int i = 0; i < drawHandSize; i++)
        {
            Card card = new(cardData);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);
            StartCoroutine(AddCard(cardView));
        }
    }

    public void DiscardAll()
    {
        foreach (CardView cardView in cards.ToList())
        {
            RemoveCard(cardView.Card);
            Destroy(cardView.gameObject);
        }
    }

    public IEnumerator AddCard (CardView cardView)
    {
        cards.Add(cardView);
        yield return UpdateCardPos(0.15f);
    }

    private IEnumerator UpdateCardPos(float duration)
    {
        if (cards.Count == 0) yield break;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPos = 0.5f - (cards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < cards.Count; i++)
        {
            float p = firstCardPos + i * cardSpacing;
            Vector3 splinePos = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);
            cards[i].transform.DOMove(splinePos + transform.position + 0.01f * i * Vector3.back, duration);
            cards[i].transform.DORotate(rotation.eulerAngles, duration);
        }
        yield return new WaitForSeconds(duration);
    }

    public CardView RemoveCard(Card card)
    {
        CardView cardView = GetCardView(card);
        if (cardView == null) return null;
        cards.Remove(cardView);
        if(cards.Count > 0)
        {
            StartCoroutine(UpdateCardPos(0.15f));
        }
        return cardView;
    }

    private CardView GetCardView(Card card)
    {
        return cards.Where(cardView => cardView.Card == card).FirstOrDefault();
    }
}
