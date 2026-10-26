using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text energy;
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private GameObject wrapper;
    [SerializeField] public HandView handView;
    [SerializeField] public GameManager gameManager;

    public Card Card { get; private set; }

    public void Setup(Card card)
    {
        Card = card;
        title.text = card.Title;
        description.text = card.Description;
        energy.text = card.Energy.ToString();
        image.sprite = card.Image;
    }

    private void OnMouseEnter()
    {
        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, 0, 0);
        CardViewHoverSystem.Instance.Show(Card, pos);
    }

    private void OnMouseExit()
    {
        CardViewHoverSystem.Instance.Hide();
        wrapper.gameObject.SetActive(true);
    }

    public void OnMouseDown()
    {
        Debug.Log("click");
        handView.RemoveCard(Card);
        Destroy(gameObject);
        gameManager.rat.TakeDamage(5);
    }
}