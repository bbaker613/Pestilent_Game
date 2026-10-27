using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Rat rat;
    [SerializeField] private PlayerController player;
    [SerializeField] private HandView handView;
    public TextMeshProUGUI winText;
    public Button endTurnButton;
    public Button returnToMapButton;

    public void EnemyTurn()
    {
        rat.Attack();
        player.health -= rat.damage;
        player.TakeDamage();
        handView.NewHand();
    }

    private void Update()
    {
        if(rat.health <= 0)
        {
            handView.DiscardAll();
            returnToMapButton.gameObject.SetActive(true);
            endTurnButton.gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
        }
    }

    public void ReturnToMap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}