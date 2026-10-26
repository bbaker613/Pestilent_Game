using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] public int health = 50;
    [SerializeField] private int energy = 5;

    public TextMeshProUGUI playerHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void TakeDamage()
    {
        playerHealth.text = "Health: " + health.ToString();

        if (health > 0)
        {
            animator.SetBool("isDamaged", true);
        }
        else
        {
            animator.SetBool("isDead", true);
        }
    }

    void disableAnim()
    {
        animator.SetBool("isDamaged", false);
        animator.SetBool("isAttacking", false);
    }
}
