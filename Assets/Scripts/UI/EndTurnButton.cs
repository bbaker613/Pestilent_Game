using UnityEngine;

public class EndTurnButton : MonoBehaviour
{

    public void OnClick()
    {
        GameManager gameManager = GameManager.Instance;
        gameManager.EnemyTurn();
    }
}
